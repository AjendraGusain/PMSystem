using BusinessLogicLayer;
using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class ViewAllEmployee : System.Web.UI.Page
    {
        EmployeeBusinessLogic viewEmployee = new EmployeeBusinessLogic();
        EmployeeBusinessObject viewEmployeeBO = new EmployeeBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClientList();
            }
        }
        private void BindClientList()
        {
            EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
            DataSet ds = addEmployeeLogic.GetAllEmployee();
            grvEmployeeDetails.DataSource = ds.Tables[0];
            grvEmployeeDetails.DataBind();
        }

        protected void grvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEmployee")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                Response.Redirect("EmployeeDetail.aspx?UserId=" + Id);
            }
            else if (e.CommandName == "EditEmployee")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                Response.Redirect("AddEmployee.aspx?UserId=" + Id);
            }
            else if (e.CommandName == "DeleteEmployee")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["Id"] = Id;
                DataSet dsResult = viewEmployee.GetAllTeamMember();
                DataRow[] foundClient = dsResult.Tables[0].Select("UserId = '" + Id + "'");
                if (foundClient.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('A team is assigned to this user. Please remove the team before deleting the user.');", true);//location.href = 'AddTeamEmployee.aspx';
                }
                else
                {
                    int dataout = viewEmployee.DeleteEmployee(Id);
                    if (dataout > 0)
                    {
                        grvEmployeeDetails.EditIndex = -1;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                        BindClientList();
                    }
                }
            }
        }

        protected void grvEmployeeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEmployeeDetails.PageIndex = e.NewPageIndex;
            BindClientList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            viewEmployeeBO.EmployeeName = txtEmpNameSearch.Text.Trim();
            DataSet response = viewEmployee.SearchEmployee(viewEmployeeBO);
            grvEmployeeDetails.DataSource = response.Tables[0];
            grvEmployeeDetails.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            grvEmployeeDetails.EditIndex = -1;
            txtEmpNameSearch.Text = "";
            BindClientList();
        }
    }
}