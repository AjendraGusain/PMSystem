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
            }
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {

        }


        private void DisplayUserTaskDetails()
        {
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            DataSet dtResult = addTaskDetails.ReAssignTask(addTaskBusinessObj.TaskID);
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
        }

        protected void grvDisplayUserTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}