﻿using System;
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
    public partial class TaskDetails : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string statusId = Request.QueryString["StatusId"];
                pnlDisplayTaskDetails.Visible = true;
                DisplayTaskDetails();
                GetTaskDetailsByTaskID();
                DisplayPlayPause();
                GetChatHistory();
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                Global.Designation = Session["Designation"].ToString();
            }
        }

        protected void grvDisplayTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void DisplayTaskDetails()
        {
            addTaskBusinessObj.EmployeeName = Request.QueryString["UserId"];
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.RoleID = Global.RoleIdSession;
            addTaskBusinessObj.Designation = Global.Designation;
            DataSet dtResult = addTaskDetails.UserTaskTime(addTaskBusinessObj);
            DataTable table = dtResult.Tables[0];
            object sumObject;
            sumObject = table.Compute("Sum(Break)", "");
            Session["BreakTime"] = sumObject;
            pnlDisplayTaskDetails.Visible = true;
            grvDisplayTaskDetails.DataSource = dtResult.Tables[0];
            grvDisplayTaskDetails.DataBind();
            DataSet dsBugHistory = addTaskDetails.TaskBugHistory(addTaskBusinessObj);
            gvDisplayBugHistory.DataSource = dsBugHistory.Tables[0];
            gvDisplayBugHistory.DataBind();
        }
        private void GetTaskDetailsByTaskID()
        {
            addTaskBusinessObj.StatusID = Request.QueryString["StatusId"];
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.AssignTask(addTaskBusinessObj);
            DataTable dt = dtResult.Tables[0];
            dt.TableName = "AssignTask";
            ViewState["AssignTask"] = dt;
            lblClientName.Text = dtResult.Tables[0].Rows[0]["ClientName"].ToString();
            lblProjectName.Text = dtResult.Tables[0].Rows[0]["ProjectName"].ToString();
            lblTaskName.Text = dtResult.Tables[0].Rows[0]["TaskName"].ToString();
            lblTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            lblTaskDetails.Text = dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            lblTaskCreatedBy.Text = dtResult.Tables[0].Rows[0]["CreatedByUser"].ToString();
            lblTaskAssigedTo.Text = dtResult.Tables[0].Rows[0]["AssignedTo"].ToString();
            lblTaskCreatedDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["TaskCreatedDate"].ToString()).ToShortDateString();
            if (dtResult.Tables[0].Rows[0]["UserId"].ToString() != "")
            {
                string estimatedTime = "";
                if (dtResult.Tables[0].Rows[0]["RevisedEstimateTime"].ToString() == "")
                {
                    estimatedTime = dtResult.Tables[0].Rows[0]["EstimateTime"].ToString();
                }
                else
                {
                    estimatedTime = dtResult.Tables[0].Rows[0]["RevisedEstimateTime"].ToString();
                }
                int estimatedMin = 0;
                if (estimatedTime != "")
                {
                    string[] estimatedTimeSplit = estimatedTime.Split(':');
                    int estimatedhours = Convert.ToInt32(estimatedTimeSplit[0]) * 60;
                    int estimatedminutes = Convert.ToInt32(estimatedTimeSplit[1]);
                    estimatedMin = (estimatedhours + estimatedminutes);
                }
                TimeSpan finalestimatedTime = TimeSpan.FromMinutes(estimatedMin);
                //lblTimeEstimate.Text = finalestimatedTime.ToString("hh':'mm");
                txtEstimatedTime.Text = finalestimatedTime.ToString("hh':'mm");

                if (dtResult.Tables[0].Rows[0]["StartDate"].ToString() != "")
                    lblStartDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()).ToShortDateString();
                if (dtResult.Tables[0].Rows[0]["EndDate"].ToString() != "" && dtResult.Tables[0].Rows[0]["StatusId"].ToString() == "5")
                    lblEndDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["EndDate"].ToString()).ToShortDateString();
                int totalTime = 0;
                int breakTime = 0;
                if (dtResult.Tables[0].Rows[0]["TotalTime"].ToString() != "")
                    totalTime += Convert.ToInt32(dtResult.Tables[0].Rows[0]["TotalTime"].ToString());
                if (Session["BreakTime"].ToString() != "")
                    breakTime += Convert.ToInt32(Session["BreakTime"].ToString());
                int actualTime = totalTime - breakTime;
                if (actualTime != 0)
                {
                    TimeSpan finalActualTime = TimeSpan.FromMinutes(actualTime);
                    lblActualTime.Text = finalActualTime.ToString("hh':'mm");
                    int estimatedError = actualTime - estimatedMin;
                    TimeSpan finalEstimatedError = TimeSpan.FromMinutes(estimatedError);
                    if (finalEstimatedError.Ticks < 0)
                    {
                        lblEstimatedError.Text = "-" + finalEstimatedError.ToString("hh':'mm");
                    }
                    else
                    {
                        lblEstimatedError.Text = finalEstimatedError.ToString("hh':'mm");
                    }
                    TimeSpan finalPauseDuration = TimeSpan.FromMinutes(breakTime);
                    lblPause.Text = finalPauseDuration.ToString("hh':'mm");
                }
            }
        }

        protected void btnSendDescription_Click(object sender, EventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.TaskDescription = txtChatDescription.Text;
            if (addTaskBusinessObj.TaskDescription == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please write any message.');", true);
                return;
            }
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.response = addTaskDetails.InsertChatDetails(addTaskBusinessObj);
            GetChatHistory();
            txtChatDescription.Text = "";
        }

        protected void GetChatHistory()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.GetChatDetails(addTaskBusinessObj);
            lstViewChatBox.DataSource = dtResult;
            lstViewChatBox.DataBind();
        }
        protected void btnOpenHistoryStatus_Click(object sender, EventArgs e)
        {
            txtHistoryStatus.Text = ddlStatus.SelectedItem.Text;
            string pauseReasonStatus = txtHistoryStatus.Text;
            addTaskBusinessObj.EmployeeName = Request.QueryString["UserId"];
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.PauseReasonStatus = pauseReasonStatus;
            DataTable dt = (DataTable)ViewState["AssignTask"];
            if (dt.Rows[0]["StatusId"].ToString() == "3" && addTaskBusinessObj.PauseReason != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Already working on this task.');", true);
                return;
            }
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatusPause(addTaskBusinessObj);
            if (pauseReasonStatus == "Reassign")
            {
                Response.Redirect("AddTask.aspx?TaskId=" + addTaskBusinessObj.TaskID + "&UserId=" + addTaskBusinessObj.EmployeeName + "&ProjectId=" + addTaskBusinessObj.ProjectID + "&checkIf=" + true);
            }
            if (pauseReasonStatus == "Completed")
            {
                btnPlayTask.Visible = false;
                btnPauseTask.Visible = false;
                ddlStatus.Enabled = false;
            }
            txtHistoryStatus.Text = "";
            DisplayTaskDetails();
            GetTaskDetailsByTaskID();
        }

        protected void btnCloseHistoryStatus_Click(object sender, EventArgs e)
        {
            pnlConfirmwindowHistoryStatus.Visible = false;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = false;
            ddlStatus.SelectedItem.Text = "Select";
        }

        protected void btnSaveReason_Click(object sender, EventArgs e)
        {
            string reason = ddlReason.SelectedItem.Text + " " + txtReason.Text.Trim();
            if (reason == "--Select Reason-- ")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please select any reason first.');", true);
                return;
            }
            addTaskBusinessObj.PauseReason = reason.Trim();
            addTaskBusinessObj.EmployeeName = Request.QueryString["UserId"];
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatusPause(addTaskBusinessObj);
            DisplayTaskDetails();
            btnPlayTask.Visible = true;
            btnPauseTask.Visible = false;
            GetTaskDetailsByTaskID();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlConfirmwindowHistoryStatus.Visible = true;
            txtHistoryStatus.Text = ddlStatus.SelectedItem.Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "PopHistory", "OpenConfirmationStatusHistory();", true);
        }

        protected void gvDisplayBugHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void btnPlayTask_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.EmployeeName = Request.QueryString["UserId"];
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatus(addTaskBusinessObj);
            DisplayTaskDetails();
            btnPlayTask.Visible = false;
            btnPauseTask.Visible = true;
            GetTaskDetailsByTaskID();
        }

        protected void Display(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "OpenConfirmationBox();", true);
        }
        protected void btnPauseTask_Click(object sender, EventArgs e)
        {
            Display(null, null);
        }

        public void DisplayPlayPause()
        {
            DataTable dt = (DataTable)ViewState["AssignTask"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["StatusId"].ToString() == "3")
                {
                    btnPlayTask.Visible = false;
                    btnPauseTask.Visible = true;
                    ddlStatus.Enabled = true;
                }
                else if (dt.Rows[i]["StatusId"].ToString() == "4")
                {
                    btnPlayTask.Visible = true;
                    btnPauseTask.Visible = false;
                    ddlStatus.Enabled = true;
                }
                else if (dt.Rows[i]["StatusId"].ToString() == "1" || dt.Rows[i]["StatusId"].ToString() == "5")
                {
                    btnPlayTask.Visible = false;
                    btnPauseTask.Visible = false;
                    ddlStatus.Enabled = false;
                    txtEstimatedTime.Visible = false;
                    btnEditEstimate.Visible = false;
                    btnUpdateEstimate.Visible = false;
                }

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            GetChatHistory();
            ScriptManager.RegisterStartupScript(this, GetType(), "scrollDown", "setTimeout(function() { window.scrollTo(0,document.body.scrollHeight); }, 25);", true);
        }

        protected void btnEditEstimate_Click(object sender, EventArgs e)
        {
            btnUpdateEstimate.Visible = true;
            btnEditEstimate.Visible = false;
            txtEstimatedTime.Enabled = true;
        }

        protected void btnUpdateEstimate_Click(object sender, EventArgs e)
        {
            btnUpdateEstimate.Visible = false;
            btnEditEstimate.Visible = true;
            txtEstimatedTime.Enabled = false;
            addTaskBusinessObj.RevisedEstimateTime = txtEstimatedTime.Text.Trim();
            addTaskBusinessObj.EmployeeName = Request.QueryString["UserId"];
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatus(addTaskBusinessObj);
        }
    }
}