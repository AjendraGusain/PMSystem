using BusinessLogicLayer;
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
                //int COLIEnhancedPolicyDollarsID = Convert.ToInt32(e.CommandArgument);
                int dataout = viewEmployee.DeleteEmployee(Id);
                if (dataout > 0)
                {
                    grvEmployeeDetails.EditIndex = -1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    BindClientList();

                }
            }
        }

        protected void grvEmployeeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEmployeeDetails.PageIndex = e.NewPageIndex;
            BindClientList();
        }

        //protected void btnViewEmployee_Click(object sender, EventArgs e)
        //{
        //    Response.Write("Hello");
        //    BindClientList();
        //    Response.Redirect("AddEmployee.aspx ?firstname= ajay" );
        //}
    }
}