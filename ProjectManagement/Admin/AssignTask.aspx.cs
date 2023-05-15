using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;

namespace ProjectManagement.Admin
{
    public partial class AssignTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        TeamBusinessObject createTeam = new TeamBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                Global.Designation = Session["Designation"].ToString();
                GetAssignedTask(Global.RoleIdSession, Global.Designation, userId);
            }
        }

        protected void grvAssignedTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ProjectName")
            {
                int projectID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ProjectDetail.aspx?ProjectId=" + projectID);
            }
            if (e.CommandName == "UserName")
            {
                int userID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EmployeeDetail.aspx?UserId=" + userID);
            }
            if (e.CommandName == "ViewAssignedTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                string clientID = commandArgs[3];
                //string teamID = commandArgs[4];
                Response.Redirect("TaskDetails.aspx?TaskId=" + taskID.Trim() + "&UserId=" + userID.Trim()  + "&ProjectId=" + projectID.Trim() + "&ClientId=" + clientID.Trim());
            }
            if (e.CommandName == "ReAssign")
            {
                string pauseReasonStatus = "Reassign";
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                addTaskBusinessObj.TaskID = Convert.ToInt32(taskID);
                addTaskBusinessObj.EmployeeName = userID;
                addTaskBusinessObj.PauseReasonStatus = pauseReasonStatus;
                DataSet dtResult = assigntaskBLL.AssignTask(addTaskBusinessObj);
                if (dtResult.Tables[0].Rows[0]["StatusId"].ToString() == "3")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Already working on this task.');", true);
                    return;
                }
                addTaskBusinessObj.response = assigntaskBLL.UpdateUserTaskStatusPause(addTaskBusinessObj);
                if (pauseReasonStatus == "Reassign")
                {
                    Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&UserId=" + userID.Trim() + "&ProjectId=" + projectID.Trim());
                }
            }
            if (e.CommandName == "Assign")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                //string teamID = commandArgs[3];
                Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&ProjectId=" + projectID.Trim());
            }
        }

        protected void GetAssignedTask(int roleId, string designation, int userId)
        {
            addTaskBusinessObj.Designation = designation;
            addTaskBusinessObj.RoleID = roleId;
            addTaskBusinessObj.LoginUserID = userId;
            DataSet ds = assigntaskBLL.GetAssignedTask(addTaskBusinessObj);
            //DataSet ds = assigntaskBLL.GetAllCreatedTask(addTaskBusinessObj);
            pnlDisplayAssignTask.Visible = true;
            pnlDisplayTaskDetails.Visible = false;
            grvAssignedTaskDetails.DataSource = ds.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void lnkbtnClientName_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewClient.aspx");
        }

        protected void grvAssignedTaskDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            grvAssignedTaskDetails.PageIndex = e.NewPageIndex;
            GetAssignedTask(Global.RoleIdSession, Global.Designation, userId);
        }

        protected void btnSearchEmp_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.LoginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.RoleID = Global.RoleIdSession;
            addTaskBusinessObj.Designation = Global.Designation;
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.SearchResult = txtSearchEmp.Text;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByUser(addTaskBusinessObj);
            grvAssignedTaskDetails.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            //   ddlSearchClient.SelectedItem.Text = "Select Client";
            //  ddlSerachProject.SelectedItem.Text = "Select Project";
            grvAssignedTaskDetails.EditIndex = -1;
            txtSearchEmp.Text = "";
            GetAssignedTask(Global.RoleIdSession, Global.Designation, userId);
        }
    }
}