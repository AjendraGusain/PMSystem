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
    public partial class ViewTaskDetails : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());

        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayUserTaskDetails();
                GetTaskDetailsByTaskID();
                DisplayPlayPause();
                GetChatHistory();
            }
        }

        private void DisplayUserTaskDetails()
        {         
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());            
            addTaskBusinessObj.LoginUserID = loginUserID;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.UserTaskTime(addTaskBusinessObj);
            DataTable table = dtResult.Tables[0];
            object sumObject;
            sumObject = table.Compute("Sum(Break)", "");
            Session["BreakTime"] = sumObject;
            pnlDisplayUserTaskDetails.Visible = true;
            grvDisplayUserTaskDetails.DataSource = dtResult.Tables[0];
            grvDisplayUserTaskDetails.DataBind();
            DataSet dsBugHistory = addTaskDetails.TaskBugHistory(addTaskBusinessObj);
            gvDisplayBugHistory.DataSource = dsBugHistory.Tables[0];
            gvDisplayBugHistory.DataBind();
        }

        //private void GetTaskDetailsByTaskID()
        //{
        //    addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
        //    DataSet dtResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
        //    lblClientName.Text = dtResult.Tables[0].Rows[0]["ClientName"].ToString();
        //    lblProjectName.Text = dtResult.Tables[0].Rows[0]["ProjectName"].ToString();
        //    lblTaskName.Text = dtResult.Tables[0].Rows[0]["TaskName"].ToString();
        //    lblTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
        //    lblTaskDetails.Text = dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();


        //    string estimatedTime= dtResult.Tables[0].Rows[0]["EstimateTime"].ToString();
        //    int estimatedMin = Int32.Parse(estimatedTime) * 60;
        //    TimeSpan finalestimatedTime = TimeSpan.FromMinutes(estimatedMin);
        //    lblTimeEstimate.Text = finalestimatedTime.ToString("hh':'mm");

        //    if (dtResult.Tables[0].Rows[0]["UserId"].ToString() != "")
        //    {
        //        //lblStartDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()).ToShortDateString();
        //        //lblEndDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["EndDate"].ToString()).ToShortDateString();
        //        //int totalTime = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TotalTime"].ToString());
        //        //int breakTime = Convert.ToInt32(Session["BreakTime"].ToString());

        //        //DateTime i = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()) != null ? Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()) : Convert.ToDateTime(DBNull.Value.ToString());

        //        //Convert.ToDateTime()
        //        if (dtResult.Tables[0].Rows[0]["StartDate"].ToString() != "")
        //            lblStartDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()).ToShortDateString();
        //        else
        //            lblStartDate.Text = dtResult.Tables[0].Rows[0]["StartDate"].ToString();
        //        if (dtResult.Tables[0].Rows[0]["EndDate"].ToString() != "")
        //            lblEndDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["EndDate"].ToString()).ToShortDateString();                
        //        else
        //            lblEndDate.Text = dtResult.Tables[0].Rows[0]["EndDate"].ToString();

        //        int totalTime=0;
        //        int breakTime = 0;
        //        if (dtResult.Tables[0].Rows[0]["TotalTime"].ToString() != "")
        //            totalTime += Convert.ToInt32(dtResult.Tables[0].Rows[0]["TotalTime"].ToString());
        //        if (Session["BreakTime"].ToString() != "")
        //            breakTime += Convert.ToInt32(Session["BreakTime"].ToString());

        //        int actualTime = totalTime - breakTime;
        //        if (actualTime != 0)
        //        {
        //            TimeSpan finalActualTime = TimeSpan.FromMinutes(actualTime);
        //            lblActualTime.Text = finalActualTime.ToString("hh':'mm");
        //            int estimatedError = actualTime - estimatedMin;
        //            TimeSpan finalEstimatedError = TimeSpan.FromMinutes(estimatedError);
        //            if (finalEstimatedError.Ticks < 0)
        //            {
        //                lblEstimatedError.Text = "-" + finalEstimatedError.ToString("hh':'mm");
        //            }
        //            else
        //            {
        //                lblEstimatedError.Text = finalEstimatedError.ToString("hh':'mm");
        //            }
        //            TimeSpan finalPauseDuration = TimeSpan.FromMinutes(breakTime);
        //            lblPause.Text = finalPauseDuration.ToString("hh':'mm");
        //        }
        //    }
        //}

        private void GetTaskDetailsByTaskID()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
            lblClientName.Text = dtResult.Tables[0].Rows[0]["ClientName"].ToString();
            lblProjectName.Text = dtResult.Tables[0].Rows[0]["ProjectName"].ToString();
            lblTaskName.Text = dtResult.Tables[0].Rows[0]["TaskName"].ToString();
            lblTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            lblTaskDetails.Text = dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            lblTaskCreatedBy.Text = dtResult.Tables[0].Rows[0]["CreatedByUser"].ToString();
            //lblTaskAssigedTo.Text = dtResult.Tables[0].Rows[0]["AssignedTo"].ToString();
            lblTaskCreatedDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["TaskCreatedDate"].ToString()).ToShortDateString();
            string estimatedTime = dtResult.Tables[0].Rows[0]["EstimateTime"].ToString();
            int estimatedMin = Int32.Parse(estimatedTime) * 60;
            TimeSpan finalestimatedTime = TimeSpan.FromMinutes(estimatedMin);
            lblTimeEstimate.Text = finalestimatedTime.ToString("hh':'mm");

            if (dtResult.Tables[0].Rows[0]["UserId"].ToString() != "")
            {
                if (dtResult.Tables[0].Rows[0]["StartDate"].ToString() != "")
                    lblStartDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()).ToShortDateString();
                if (dtResult.Tables[0].Rows[0]["EndDate"].ToString() != "" && dtResult.Tables[0].Rows[0]["StatusId"].ToString() == "5")
                    lblEndDate.Text = Convert.ToDateTime(dtResult.Tables[0].Rows[0]["EndDate"].ToString()).ToShortDateString();

                //DateTime currentTime = TimeZoneInfo.ConvertTime(Convert.ToDateTime(dtResult.Tables[0].Rows[0]["StartDate"].ToString()), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
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

        protected void grvDisplayUserTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        public void DisplayPlayPause()
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.dsResult = addTaskDetails.GetAllCreatedTaskByUser(addTaskBusinessObj);
            for (int i = 0; i < addTaskBusinessObj.dsResult.Tables[0].Rows.Count; i++)
            {
                if (addTaskBusinessObj.dsResult.Tables[0].Rows[i]["StatusName"].ToString() == "In Process")
                {
                    btnPlayTask.Visible = false;
                    btnPauseTask.Visible = true;
                }
                else if (addTaskBusinessObj.dsResult.Tables[0].Rows[i]["StatusName"].ToString() == "Pause")
                {
                    btnPlayTask.Visible = true;
                    btnPauseTask.Visible = false;
                }
            }
        }

        protected void btnPlayTask_Click(object sender, EventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatus(addTaskBusinessObj);
            DisplayUserTaskDetails();
            btnPlayTask.Visible = false;
            btnPauseTask.Visible = true;
            ddlStatus.SelectedItem.Text = "Select";
        }

        protected void btnPauseTask_Click(object sender, EventArgs e)
        {
            Display(null, null);
        }

        protected void gvDisplayBugHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
            addTaskBusinessObj.PauseReason = reason;
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.ClientID = Request.QueryString["ClientId"];
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatusPause(addTaskBusinessObj);
            DisplayUserTaskDetails();
            btnPlayTask.Visible = true;
            btnPauseTask.Visible = false;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = false;
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlConfirmwindowHistoryStatus.Visible = true;
            txtHistoryStatus.Text = ddlStatus.SelectedItem.Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "PopHistory", "OpenConfirmationStatusHistory();", true);
        }

        protected void btnOpenHistoryStatus_Click(object sender, EventArgs e)
        {

            string pauseReasonStatus = txtHistoryStatus.Text;
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.PauseReasonStatus = pauseReasonStatus;
            DataSet dtResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
            if (dtResult.Tables[0].Rows[0]["StatusId"].ToString() == "3")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Already working on this task.');", true);
                return;
            }
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatusPause(addTaskBusinessObj);
            DisplayUserTaskDetails();
            //ddlReason.SelectedItem.Text = "Select";
            txtHistoryStatus.Text = "";
            if (pauseReasonStatus == "Completed")
            {
                btnPlayTask.Visible = false;
                btnPauseTask.Visible = false;
                ddlStatus.Enabled = false;
            }
        }

        protected void btnCloseHistoryStatus_Click(object sender, EventArgs e)
        {
            pnlConfirmwindowHistoryStatus.Visible = false;
        }


        protected void btnSendDescription_Click(object sender, EventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.TaskDescription = txtChatDescription.Text;
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.response = addTaskDetails.InsertChatDetails(addTaskBusinessObj);
            txtChatDescription.Text = "";
            GetChatHistory();
        }

        protected void GetChatHistory()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.GetChatDetails(addTaskBusinessObj);
            lstViewChatBox.DataSource = dtResult;
            lstViewChatBox.DataBind();
        }
    }
}