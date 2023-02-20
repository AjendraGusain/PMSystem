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
    public partial class TaskDetails : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());

        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnlDisplayTaskDetails.Visible = true;
                GetTaskDetailsByTaskID();
                DisplayTaskDetails();
            }
        }

        protected void grvDisplayTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void DisplayTaskDetails()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.ReAssignTask(addTaskBusinessObj.TaskID);
            pnlDisplayTaskDetails.Visible = true;
            grvDisplayTaskDetails.DataSource = dtResult.Tables[0];
            grvDisplayTaskDetails.DataBind();
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
            lblWIP.Text = "";
            if (dtResult.Tables[0].Rows[0]["EndTime"].ToString() == "" || dtResult.Tables[0].Rows[0]["EndTime"].ToString() == null)
            {
                lblWIP.Text = "WIP";
            }
            else
            {
                lblWIP.Text = "Pause";
            }
            if (lblWIP.Text == "Pause")
            {
                lblPause.Text = "Yes";
            }
            else
            {
                lblPause.Text = "No";
            }

        }
    }
}