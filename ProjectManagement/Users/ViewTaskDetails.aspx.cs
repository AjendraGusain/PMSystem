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
                btnPlayTask_Click(null, null);
            }
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {

        }


        private void DisplayUserTaskDetails()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.UserTaskTime(addTaskBusinessObj);
            pnlDisplayUserTaskDetails.Visible = true;
            grvDisplayUserTaskDetails.DataSource = dtResult.Tables[0];
            grvDisplayUserTaskDetails.DataBind();
        }

        private void GetTaskDetailsByTaskID()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
            lblClientName.Text = dtResult.Tables[0].Rows[0]["ClientName"].ToString();
            lblProjectName.Text = dtResult.Tables[0].Rows[0]["ProjectName"].ToString();
            lblTaskName.Text = dtResult.Tables[0].Rows[0]["TaskName"].ToString();
            lblTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            lblTaskDetails.Text = dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            lblStartDate.Text = dtResult.Tables[0].Rows[0]["StartTime"].ToString();
            lblEndDate.Text = dtResult.Tables[0].Rows[0]["EndTime"].ToString();
            lblTimeEstimate.Text = dtResult.Tables[0].Rows[0]["EstimateTime"].ToString();
            lblActualTime.Text = dtResult.Tables[0].Rows[0]["ActualTime"].ToString();
            lblWIP.Text= dtResult.Tables[0].Rows[0]["WIP"].ToString();
        }

        protected void grvDisplayUserTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnSendDescription_Click(object sender, EventArgs e)
        {

        }

        protected void btnPlayTask_Click(object sender, EventArgs e)
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
//                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Already worked on a Task.');", true);
  //                  return;
                }
                else if (addTaskBusinessObj.dsResult.Tables[0].Rows[i]["StatusName"].ToString() == "Pause")
                {
                    btnPlayTask.Visible = true;
                    btnPauseTask.Visible = false;
                }
            }
            addTaskBusinessObj.response = addTaskDetails.UpdateUserTaskStatus(addTaskBusinessObj);
            DisplayUserTaskDetails();
        }

        protected void btnPauseTask_Click(object sender, EventArgs e)
        {
            Display(null,null);
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
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}