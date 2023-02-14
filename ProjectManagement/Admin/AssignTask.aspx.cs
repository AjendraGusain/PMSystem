using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
//using DataAccessLayer.Interface;
//using DataAccessLayer;
using BusinessLogicLayer.Interface;
using DataAccessLayer;

namespace ProjectManagement.Admin
{
    public partial class AssignTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAssignedTask();
            }
        }

        protected void grvAssignedTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ProjectName")
            {
                int projectID = Convert.ToInt32(e.CommandArgument);
                //Response.Redirect("ProjectDetail.aspx?ProjectId=" + projectID);
            }

            if (e.CommandName == "UserName")
            {
                int userID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EmployeeDetail.aspx?UserId=" + userID);
            }

            if (e.CommandName == "ViewAssignedTask")
            {
                string taskID= Convert.ToInt32(e.CommandArgument).ToString();
                Response.Redirect("TaskDetails.aspx?TaskId=" + taskID);
              //  Response.Redirect("TaskDetails.aspx");
            }

            if (e.CommandName == "ReAssign")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                Response.Redirect("AddTask.aspx?TaskId=" + taskID + "&UserId=" + userID);
            }

            if (e.CommandName == "Assign")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                Response.Redirect("AddTask.aspx?TaskId=" + taskID);
            }
        }

        protected void GetAssignedTask()
        {
            DataSet ds = assigntaskBLL.GetAssignedTask();
            pnlDisplayAssignTask.Visible = true;
            pnlDisplayTaskDetails.Visible = false;
            grvAssignedTaskDetails.DataSource = ds.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void GetTaskDetails()
        {
            DataSet ds = assigntaskBLL.GetAssignedTask();
            pnlDisplayTaskDetails.Visible = true;
            pnlDisplayAssignTask.Visible = false;
            gvTaskDetails.DataSource = ds.Tables[0];
            gvTaskDetails.DataBind();
        }

        protected void lnkbtnClientName_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewClient.aspx");
        }

        protected void lnkbtnProjectName_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void lnkbtnTaskName_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        //protected void lnkbtnEmployeeName_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("EmployeeDetail.aspx?UserName=" + Request.QueryString["UserID"]);
        //}
    }
}