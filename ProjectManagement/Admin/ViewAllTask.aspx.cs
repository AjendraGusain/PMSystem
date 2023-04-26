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
                GetAllCreatedTask();
              //  BindClientandProject();
            }
        }
        public void GetAllCreatedTask()
        {
            DataSet ds = assigntaskBLL.GetAllCreatedTask();
            // DataSet ds = assigntaskBLL.GetAssignedTask();
            grvViewAllTask.DataSource = ds.Tables[0];
            grvViewAllTask.DataBind();
        }


        //protected void BindClientandProject()
        //{
        //    //ddlSearchClient.Items.Clear();
        //    //ddlSearchClient.DataSource = assigntaskBLL.GetAllClients();
        //    //ddlSearchClient.DataTextField = "ClientName";
        //    //ddlSearchClient.DataValueField = "ClientID";
        //    //ddlSearchClient.DataBind();
        //    //ddlSearchClient.Items.Insert(0, new ListItem("Select Client", "0"));
        //    ddlSerachProject.Items.Clear();
        //    ddlSerachProject.DataSource = assigntaskBLL.GetAllProject();
        //    ddlSerachProject.DataTextField = "ProjectName";
        //    ddlSerachProject.DataValueField = "ProjectID";
        //    ddlSerachProject.DataBind();
        //    ddlSerachProject.Items.Insert(0, new ListItem("Select Project", "0"));
        //}
        protected void grvViewAllTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                string editID = "1";
                Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&UserId=" + userID.Trim() + "&ProjectId=" + projectID.Trim() + "&EditId=" + editID.Trim());
            }
            if (e.CommandName == "DeleteTask")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                string clientID = commandArgs[3];

                addTaskBusinessObj.ClientID = clientID;
                addTaskBusinessObj.ProjectID = projectID;
                addTaskBusinessObj.TaskID = Convert.ToInt32(taskID);
                addTaskBusinessObj.EmployeeName = userID;
                int response = assigntaskBLL.DeleteTaskDetails(addTaskBusinessObj);
                if (response > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task deleted sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('You are already working on this task.');", true);
                }
                GetAllCreatedTask();
            }
        }

        //protected void GetTaskByClient()
        //{
        //    addTaskBusinessObj.ClientID = ddlSearchClient.SelectedValue;
        //    addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByClient(addTaskBusinessObj);
        //    pnlDisplayAssignTask.Visible = true;
        //    grvViewAllTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
        //    grvViewAllTask.DataBind();
        //}

        //protected void GetTaskByProject()
        //{
        //    addTaskBusinessObj.ProjectID = ddlSerachProject.SelectedValue;
        //    addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByProject(addTaskBusinessObj);
        //    pnlDisplayAssignTask.Visible = true;
        //    grvViewAllTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
        //    grvViewAllTask.DataBind();
        //}

        //protected void ddlSearchClient_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetAllCreatedTask();
        //    GetTaskByClient();
        //    if (ddlSearchClient.SelectedItem.Text == "Select Client")
        //    {
        //        grvViewAllTask.EditIndex = -1;
        //        txtSearchEmp.Text = "";
        //        ddlSerachProject.SelectedItem.Text = "Select Project";
        //        GetAllCreatedTask();
        //    }
        //}

        //protected void ddlSerachProject_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetAllCreatedTask();
        //    GetTaskByProject();
        //    if (ddlSerachProject.SelectedItem.Text == "Select Project")
        //    {
        //        grvViewAllTask.EditIndex = -1;
        //        txtSearchEmp.Text = "";
        //      //  ddlSearchClient.SelectedItem.Text = "Select Client";
        //        GetAllCreatedTask();
        //    }
        //}

        protected void btnSearchEmp_Click(object sender, EventArgs e)
        {
            //string[] formats = {"dd/MM/yyyy", "dd-MMM-yyyy", "yyyy-MM-dd","dd-MM-yyyy", "M/d/yyyy", "dd MMM yyyy"};
            //string convertedStartDate = DateTime.ParseExact(txtTaskStartDateSearch.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
            //string convertedEndDate = DateTime.ParseExact(txtTaskEndDateSearch.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");

            if (!string.IsNullOrEmpty(txtTaskStartDateSearch.Text))
            {
                addTaskBusinessObj.StartDate = DateTime.Parse(txtTaskStartDateSearch.Text);
            }
            //else
            //{
            //    addTaskBusinessObj.StartDate = DateTime.MaxValue;
            //}
            if (!string.IsNullOrEmpty(txtTaskEndDateSearch.Text))
            {
                addTaskBusinessObj.EndDate = Convert.ToDateTime(txtTaskEndDateSearch.Text);
            }
            //else
            //{
            //    addTaskBusinessObj.EndDate = DateTime.MaxValue;
            //}
            //if ((!string.IsNullOrEmpty(txtTaskStartDateSearch.Text)) && !string.IsNullOrEmpty(txtTaskEndDateSearch.Text.ToString()))
            //{
            //    addTaskBusinessObj.StartDate = Convert.ToDateTime(txtTaskStartDateSearch.Text.ToString());
            //    addTaskBusinessObj.EndDate = Convert.ToDateTime(txtTaskEndDateSearch.Text.ToString());
            //}
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
                txtTaskStartDateSearch.Text = "";
                txtTaskEndDateSearch.Text = "";
            }
        }

        //protected void btnCancelSearch_Click(object sender, EventArgs e)
        //{
        //  //  ddlSearchClient.SelectedItem.Text = "Select Client";
        //   // ddlSerachProject.SelectedItem.Text = "Select Project";
        //    grvViewAllTask.EditIndex = -1;
        //    txtSearchEmp.Text = "";
        //    GetAllCreatedTask();
        //}
    }
}