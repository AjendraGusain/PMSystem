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
    public partial class EmployeeDetail : System.Web.UI.Page
    {
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        EmployeeBusinessObject addEmployee = new EmployeeBusinessObject();
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                
                GetEmployee(UserId);
                gridViewList(UserId);
            }
        }
        private void gridViewList(int UserId)
        {

            dtResult = addEmployeeLogic.GetProjectCurrent(UserId, 1);
            grvCurrentProject.DataSource = dtResult.Tables[0];
            grvCurrentProject.DataBind();
            dtResult.Reset();
            dtResult = addEmployeeLogic.GetProjectCurrent(UserId, 0);
            grvPreviousProject.DataSource = dtResult.Tables[0];
            grvPreviousProject.DataBind();
            dtResult.Reset();
            //ds.Tables[0].Clear();
            //grvViewManager
        }

        private void GetEmployee(int UserId)
        {
            dtResult = addEmployeeLogic.GetEmployeeById(UserId);
            lblEmployeeCode.Text = dtResult.Tables[0].Rows[0]["EmployeeCode"].ToString();
            lblEmployeeName.Text = dtResult.Tables[0].Rows[0]["UserName"].ToString();
            lblName.Text = dtResult.Tables[0].Rows[0]["UserName"].ToString();
            lblPhoneNo.Text = dtResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
            lblEmail.Text = dtResult.Tables[0].Rows[0]["Email"].ToString();
            lblRole.Text = dtResult.Tables[0].Rows[0]["Role"].ToString();
            lblDesignation.Text = dtResult.Tables[0].Rows[0]["Designation"].ToString();
            dtResult.Reset();
        }

        protected void grvCurrentProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewProject")
            {
               
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string projectId = commandArgs[0];
                string clientId = commandArgs[1];
                string userId = commandArgs[2];
                Session["ProjectId"] = projectId;
                Session["ClientId"] = clientId;
                Session["UserId"] = userId;
                Response.Redirect("EmployeeTask.aspx");
                //dtResult = addEmployeeLogic.GetAllTaskByUserEmployeeTask(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
            }
        }
    }
}