using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class ViewAllTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                Global.Designation = Session["Designation"].ToString();
                GetAllCreatedTask(userId, Global.RoleIdSession, Global.Designation);
            }
        }
        public void GetAllCreatedTask(int userId, int roleID, string Designation)
        {
            addTaskBusinessObj.RoleID = Global.RoleIdSession;
            addTaskBusinessObj.Designation = Global.Designation;
            addTaskBusinessObj.LoginUserID = userId;
            DataSet ds = assigntaskBLL.GetAllCreatedTask(addTaskBusinessObj);
            DataTable dt = ds.Tables[0];
            dt.TableName = "ViewAllTask";
            ViewState["ViewAllTask"] = dt;
            grvViewAllTask.DataSource = dt;
            grvViewAllTask.DataBind();
        }

        protected void grvViewAllTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = Session["UserID"].ToString();
                string projectID = commandArgs[2];
                string editID = "1";
                Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&UserId=" + userID.Trim() + "&ProjectId=" + projectID.Trim() + "&EditId=" + editID.Trim());
            }
            if (e.CommandName == "DeleteTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = Session["UserID"].ToString();
                string projectID = commandArgs[2];
                string clientID = commandArgs[3];
                addTaskBusinessObj.ClientID = clientID;
                addTaskBusinessObj.ProjectID = projectID;
                addTaskBusinessObj.TaskID = Convert.ToInt32(taskID);
                addTaskBusinessObj.EmployeeName = Session["UserID"].ToString();
                int response = assigntaskBLL.DeleteTaskDetails(addTaskBusinessObj);
                if (response > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task deleted sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('You are already working on this task.');", true);
                }
                GetAllCreatedTask(Convert.ToInt32(userID), Global.RoleIdSession, Global.Designation);
            }
            if (e.CommandName == "ViewAssignedTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                string clientID = commandArgs[3];
                string statusID = commandArgs[4];
                Response.Redirect("TaskDetails.aspx?TaskId=" + taskID.Trim() + "&ProjectId=" + projectID.Trim() + "&ClientId=" + clientID.Trim() + "&StatusId=" + statusID.Trim());
            }
        }

        protected void btnSearchEmp_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.RoleID = Convert.ToInt32(Session["RoleId"].ToString());
            addTaskBusinessObj.EmployeeName = Session["UserID"].ToString();
            addTaskBusinessObj.Designation = Session["Designation"].ToString();
            if (!string.IsNullOrEmpty(txtTaskStartDateSearch.Text))
            {
                addTaskBusinessObj.StartDate = DateTime.Parse(txtTaskStartDateSearch.Text);
            }
            if (!string.IsNullOrEmpty(txtTaskEndDateSearch.Text))
            {
                addTaskBusinessObj.EndDate = Convert.ToDateTime(txtTaskEndDateSearch.Text);
            }
            if (!string.IsNullOrEmpty(txtSearchEmp.Text))
            {
                addTaskBusinessObj.SearchResult = txtSearchEmp.Text;
            }
            else
            {
                addTaskBusinessObj.SearchResult = "0";
            }
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchTask(addTaskBusinessObj);
            if (addTaskBusinessObj.dsResult.Tables.Count > 0)
            {
                grvViewAllTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
                grvViewAllTask.DataBind();
            }
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            grvViewAllTask.EditIndex = -1;
            txtSearchEmp.Text = "";
            txtTaskStartDateSearch.Text = "";
            txtTaskEndDateSearch.Text = "";
            GetAllCreatedTask(userId, Global.RoleIdSession, Global.Designation);
        }
    }
}