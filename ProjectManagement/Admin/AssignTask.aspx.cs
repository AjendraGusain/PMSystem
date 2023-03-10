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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAssignedTask();
                BindClientandProject();
            }
        }

        protected void BindClientandProject()
        {
            ddlSearchClient.Items.Clear();
            ddlSearchClient.DataSource = assigntaskBLL.GetAllClients();
            ddlSearchClient.DataTextField = "ClientName";
            ddlSearchClient.DataValueField = "ClientID";
            ddlSearchClient.DataBind();
            ddlSearchClient.Items.Insert(0, new ListItem("Select Client", "0"));
            ddlSerachProject.Items.Clear();
            ddlSerachProject.DataSource = assigntaskBLL.GetAllProject();
            ddlSerachProject.DataTextField = "ProjectName";
            ddlSerachProject.DataValueField = "ProjectID";
            ddlSerachProject.DataBind();
            ddlSerachProject.Items.Insert(0, new ListItem("Select Project", "0"));
        }

        protected void grvAssignedTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ProjectName")
            {
                int projectID = Convert.ToInt32(e.CommandArgument);
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
            }
            if (e.CommandName == "ReAssign")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&UserId=" + userID.Trim() + "&ProjectId=" + projectID.Trim());
            }
            if (e.CommandName == "Assign")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string taskID = commandArgs[0];
                string userID = commandArgs[1];
                string projectID = commandArgs[2];
                Response.Redirect("AddTask.aspx?TaskId=" + taskID.Trim() + "&ProjectId=" + projectID.Trim());
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

        protected void grvAssignedTaskDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAssignedTaskDetails.PageIndex = e.NewPageIndex;
            GetAssignedTask();
        }

        protected void btnSearchEmp_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            addTaskBusinessObj.SearchResult = txtSearchEmp.Text;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByUser(addTaskBusinessObj);
            grvAssignedTaskDetails.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void ddlSearchClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAssignedTask();
            GetTaskByClient();
            if(ddlSearchClient.SelectedItem.Text=="Select Client")
            {
                grvAssignedTaskDetails.EditIndex = -1;
                txtSearchEmp.Text = "";
                ddlSerachProject.SelectedItem.Text = "Select Project";
                GetAssignedTask();
            }
        }

        protected void ddlSerachProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAssignedTask();
            GetTaskByProject();
            if (ddlSerachProject.SelectedItem.Text == "Select Project")
            {
                grvAssignedTaskDetails.EditIndex = -1;
                txtSearchEmp.Text = "";
                ddlSearchClient.SelectedItem.Text = "Select Client";
                GetAssignedTask();
            }
        }

        protected void GetTaskByClient()
        {
            addTaskBusinessObj.ClientID = ddlSearchClient.SelectedValue;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByClient(addTaskBusinessObj);
            pnlDisplayTaskDetails.Visible = false;
            pnlDisplayAssignTask.Visible = true;
            grvAssignedTaskDetails.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void GetTaskByProject()
        {
            addTaskBusinessObj.ProjectID = ddlSerachProject.SelectedValue;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByProject(addTaskBusinessObj);
            pnlDisplayTaskDetails.Visible = false;
            pnlDisplayAssignTask.Visible = true;
            grvAssignedTaskDetails.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            ddlSearchClient.SelectedItem.Text = "Select Client";
            ddlSerachProject.SelectedItem.Text = "Select Project";
            grvAssignedTaskDetails.EditIndex = -1;
            txtSearchEmp.Text = "";
            GetAssignedTask();
        }
    }
}