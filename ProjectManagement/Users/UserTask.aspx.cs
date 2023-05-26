using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Users
{
    public partial class UserTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetUserTaskDetails();
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
            }
        }

        protected void GetUserTaskDetails()
        {
            addTaskBusinessObj.RoleID = Global.RoleId;
            addTaskBusinessObj.Designation = Global.Designation;
            addTaskBusinessObj.EmployeeName = Session["UserID"].ToString();
            DataSet ds = assigntaskBLL.GetAllCreatedTaskByUser(addTaskBusinessObj);
            DataTable dt = ds.Tables[0];
            dt.TableName = "AllTask";
            ViewState["AllTask"] = dt;
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = ds.Tables[0];
            gvDisplayUserTask.DataBind();
        }
        protected void gvDisplayUserTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            if (e.CommandName == "ViewUserTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string projectID = commandArgs[1];
                string clientID = commandArgs[2];
                Response.Redirect("ViewTaskDetails.aspx?taskID=" + taskID.Trim() + "&ProjectId=" + projectID.Trim() + "&ClientId=" + clientID.Trim());
            }
            if (e.CommandName == "AssignUserTask")
            {
                try
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string taskID = commandArgs[0];
                    string taskNumber = commandArgs[1];
                    string projectID = commandArgs[2];
                    string clientID = commandArgs[3];
                    Session["TaskID"] = taskID;
                    addTaskBusinessObj.TaskID = Convert.ToInt32(Session["TaskID"].ToString());
                    addTaskBusinessObj.AssignedDate = DateTime.Now;
                    addTaskBusinessObj.ProjectID = projectID;
                    addTaskBusinessObj.TaskNumber = taskNumber;
                    addTaskBusinessObj.ClientID = clientID;
                    addTaskBusinessObj.LoginUserID = loginUserID;
                    addTaskBusinessObj.EmployeeName = loginUserID.ToString();
                    DataSet ds = assigntaskBLL.GetTeamMemberID(addTaskBusinessObj);
                    addTaskBusinessObj.TeamMemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["TeamMemberId"].ToString());
                    addTaskBusinessObj.TeamId = ds.Tables[0].Rows[0]["TeamId"].ToString();
                    addTaskBusinessObj.response = assigntaskBLL.InsertAssignedTaskDetails(addTaskBusinessObj);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                if (addTaskBusinessObj.response > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task assigned sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Task not assigned.');", true);
                }
                GetUserTaskDetails();
            }
            if (e.CommandName == "PlayTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                Session["TaskID"] = taskID;
                string projectID = commandArgs[1];
                Session["ProjectID"] = projectID;
                string clientID = commandArgs[2];
                Session["ClientID"] = clientID;
                // DisplayEstimate(null, null);
                lnkbtnPlay_Click(taskID, null);
            }
            if (e.CommandName == "PauseTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                Session["TaskID"] = taskID;
                string projectID = commandArgs[1];
                Session["ProjectID"] = projectID;
                string clientID = commandArgs[2];
                Session["ClientID"] = clientID;
                Display(null, null);
            }
        }

        public void DisplayEstimate(object sender, EventArgs e)
        {
            pnlEstimatedTime.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "PopEstimate", "OpenConfirmationBoxEstimateTime();", true);
            //lnkbtnPlay_Click(null, null);
        }
        protected void gvDisplayUserTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbAssign = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnAssign");
                LinkButton lbPlay = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnPlay");
                LinkButton lbPause = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnPause");
                if (e.Row.Cells[10].Text.ToString() == "Unassigned")
                {
                    lbAssign.Visible = true;
                    lbPlay.Visible = false;
                    lbPause.Visible = false;
                }
                else if (e.Row.Cells[10].Text.ToString() == "Assigned")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = true;
                    lbPause.Visible = false;
                }
                else if (e.Row.Cells[10].Text.ToString() == "In Process")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = false;
                    lbPause.Visible = true;
                }
                else if (e.Row.Cells[10].Text.ToString() == "Pause")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = true;
                    lbPause.Visible = false;
                }
            }
        }

        protected void lnkbtnPlay_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["AllTask"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TaskId"].ToString()==(sender).ToString())
                {
                    if (dt.Rows[i]["EstimateTime"].ToString() == "")
                    {
                        DisplayEstimate(null, null);
                        return;
                    }
                }
            }
            if (addTaskBusinessObj.EstimateTime == null)
            {
                addTaskBusinessObj.EstimateTime="0";
            }
            else
            {
                addTaskBusinessObj.EstimateTime = (sender).ToString();
            }
            //addTaskBusinessObj.EstimateTime = (sender).ToString();// ViewState["EstimatedTime"].ToString();
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Session["TaskID"].ToString());
            addTaskBusinessObj.ProjectID = Session["ProjectID"].ToString();
            addTaskBusinessObj.ClientID = Session["ClientID"].ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["StatusName"].ToString() == "In Process")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Already worked on a Task.');", true);
                    return;
                }
            }
            addTaskBusinessObj.response = assigntaskBLL.UpdateUserTaskStatus(addTaskBusinessObj);
            GetUserTaskDetails();
        }

        protected void lnkbtnPause_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.PauseReason = (sender).ToString();
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Session["TaskID"].ToString());
            addTaskBusinessObj.ProjectID = Session["ProjectID"].ToString();
            addTaskBusinessObj.ClientID = Session["ClientID"].ToString();
            addTaskBusinessObj.response = assigntaskBLL.UpdateUserTaskStatusPause(addTaskBusinessObj);
            GetUserTaskDetails();
        }

        protected void Display(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "OpenConfirmationBox();", true);
        }

        protected void btnSaveReason_Click(object sender, EventArgs e)
        {
            string reason = ddlReason.SelectedItem.Text + " " + txtReason.Text.Trim();
            if (reason == "--Select Reason-- ")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please select any reason first.');", true);
                return;
            }
            lnkbtnPause_Click(reason, null);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = false;
        }


        protected void btnSearchStartEnd_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.RoleID = Convert.ToInt32(Session["RoleId"].ToString());
            addTaskBusinessObj.EmployeeName = Session["UserID"].ToString();
            if (!string.IsNullOrEmpty(txtSearchStartDate.Text))
            {
                addTaskBusinessObj.StartDate = DateTime.Parse(txtSearchStartDate.Text);
            }
            if (!string.IsNullOrEmpty(txtSearchEndDate.Text))
            {
                addTaskBusinessObj.EndDate = Convert.ToDateTime(txtSearchEndDate.Text);
            }

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                addTaskBusinessObj.SearchResult = txtSearch.Text;
            }
            else
            {
                addTaskBusinessObj.SearchResult = "0";
            }
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchTask(addTaskBusinessObj);
            if (addTaskBusinessObj.dsResult.Tables.Count > 0)
            {
                gvDisplayUserTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
                gvDisplayUserTask.DataBind();
            }
        }

        protected void btnCancelStartEnd_Click(object sender, EventArgs e)
        {
            gvDisplayUserTask.EditIndex = -1;
            txtSearchEndDate.Text = "";
            txtSearchStartDate.Text = "";
            txtSearch.Text = "";
            GetUserTaskDetails();
        }

        protected void btnCloseEstimateTime_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveEstimateTime_Click(object sender, EventArgs e)
        {
            string reason = txtEstimateTime.Text.Trim();
            if (reason == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please enter reason.');", true);
                return;
            }
            addTaskBusinessObj.EstimateTime = reason;
            lnkbtnPlay_Click(reason, null);
        }
    }
}