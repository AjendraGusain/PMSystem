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
                BindClientandProject();
            }
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
                    int taskID = Convert.ToInt32(e.CommandArgument);
                    Session["TaskID"] = taskID;
                    addTaskBusinessObj.TaskID = Convert.ToInt32(Session["TaskID"].ToString());
                    addTaskBusinessObj.AssignedDate = DateTime.Now;
                    addTaskBusinessObj.dsResult = assigntaskBLL.AssignTask(addTaskBusinessObj.TaskID);
                    addTaskBusinessObj.ProjectID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString();
                    addTaskBusinessObj.TaskNumber = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();
                    addTaskBusinessObj.LoginUserID = loginUserID;
                    addTaskBusinessObj.EmployeeName = loginUserID.ToString();
                    addTaskBusinessObj.ClientID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ClientId"].ToString();
                    DataSet ds = assigntaskBLL.GetTeamMemberID(addTaskBusinessObj);
                    addTaskBusinessObj.TeamMemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["TeamMemberId"].ToString());
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
                lnkbtnPlay_Click(null, null);
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

        protected void GetUserTaskDetails()
        {
            addTaskBusinessObj.EmployeeName = Session["UserID"].ToString();
            DataSet ds = assigntaskBLL.GetAllCreatedTaskByUser(addTaskBusinessObj);
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = ds.Tables[0];
            gvDisplayUserTask.DataBind();
        }

        protected void gvDisplayUserTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbAssign = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnAssign");
                LinkButton lbPlay = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnPlay");
                LinkButton lbPause = (LinkButton)e.Row.Cells[6].FindControl("lnkbtnPause");
                if (e.Row.Cells[7].Text.ToString() == "Unassigned")
                {
                    lbAssign.Visible = true;
                    lbPlay.Visible = false;
                    lbPause.Visible = false;
                }
                else if (e.Row.Cells[7].Text.ToString() == "Assigned")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = true;
                    lbPause.Visible = false;
                }
                else if (e.Row.Cells[7].Text.ToString() == "In Process")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = false;
                    lbPause.Visible = true;
                }
                else if (e.Row.Cells[7].Text.ToString() == "Pause")
                {
                    lbAssign.Visible = false;
                    lbPlay.Visible = true;
                    lbPause.Visible = false;
                }
            }
        }

        protected void lnkbtnPlay_Click(object sender, EventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.EmployeeName = loginUserID.ToString();
            addTaskBusinessObj.AssignedDate = DateTime.Now;
            addTaskBusinessObj.TaskID = Convert.ToInt32(Session["TaskID"].ToString());
            addTaskBusinessObj.ProjectID = Session["ProjectID"].ToString();
            addTaskBusinessObj.ClientID = Session["ClientID"].ToString();
            addTaskBusinessObj.dsResult = assigntaskBLL.GetAllCreatedTaskByUser(addTaskBusinessObj);
            for (int i = 0; i < addTaskBusinessObj.dsResult.Tables[0].Rows.Count; i++)
            {
                if (addTaskBusinessObj.dsResult.Tables[0].Rows[i]["StatusName"].ToString() == "In Process")
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
            lnkbtnPause_Click(reason, null);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlConfirmwindow.Visible = false;
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
            ddlSearchStatus.Items.Clear();
            ddlSearchStatus.DataSource = assigntaskBLL.GetStatusName();
            ddlSearchStatus.DataTextField = "StatusName";
            ddlSearchStatus.DataValueField = "StatusID";
            ddlSearchStatus.DataBind();
            ddlSearchStatus.Items.Insert(0, new ListItem("Select Status", "0"));
        }
        protected void ddlSearchClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserTaskDetails();
            GetTaskByClient();
            if (ddlSearchClient.SelectedItem.Text == "Select Client")
            {
                gvDisplayUserTask.EditIndex = -1;
                txtSearchStartDate.Text = "";
                txtSearchEndDate.Text = "";
                ddlSerachProject.SelectedItem.Text = "Select Project";
                ddlSearchStatus.SelectedItem.Text = "Select Status";
                GetUserTaskDetails();
            }
        }

        protected void ddlSerachProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserTaskDetails();
            GetTaskByProject();
            if (ddlSerachProject.SelectedItem.Text == "Select Project")
            {
                gvDisplayUserTask.EditIndex = -1;
                txtSearchStartDate.Text = "";
                txtSearchEndDate.Text = "";
                ddlSearchClient.SelectedItem.Text = "Select Client";
                ddlSearchStatus.SelectedItem.Text = "Select Status";
                GetUserTaskDetails();
            }
        }

        protected void ddlSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserTaskDetails();
            GetTaskByStatus();
            if (ddlSearchStatus.SelectedItem.Text == "Select Status")
            {
                gvDisplayUserTask.EditIndex = -1;
                txtSearchStartDate.Text = "";
                txtSearchEndDate.Text = "";
                ddlSearchClient.SelectedItem.Text = "Select Client";
                ddlSerachProject.SelectedItem.Text = "Select Project";
                GetUserTaskDetails();
            }
        }

        protected void GetTaskByClient()
        {
            addTaskBusinessObj.ClientID = ddlSearchClient.SelectedValue;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByClient(addTaskBusinessObj);
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            gvDisplayUserTask.DataBind();
        }

        protected void GetTaskByStatus()
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            int roleId = Convert.ToInt32(Session["RoleId"].ToString());
            addTaskBusinessObj.LoginUserID = loginUserID;
            addTaskBusinessObj.RoleID = roleId;
            addTaskBusinessObj.StatusID = ddlSearchStatus.SelectedValue;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByStatus(addTaskBusinessObj);
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            gvDisplayUserTask.DataBind();
        }
        protected void GetTaskByProject()
        {
            addTaskBusinessObj.ProjectID = ddlSerachProject.SelectedValue;
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByProject(addTaskBusinessObj);
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            gvDisplayUserTask.DataBind();
        }

        protected void btnSearchStartEnd_Click(object sender, EventArgs e)
        {
            if (txtSearchStartDate.Text != "")
            {
                addTaskBusinessObj.StartDate = Convert.ToDateTime(txtSearchStartDate.Text);
            }
            if (txtSearchEndDate.Text != "")
            {
                addTaskBusinessObj.EndDate = Convert.ToDateTime(txtSearchEndDate.Text);
            }
            addTaskBusinessObj.dsResult = assigntaskBLL.SearchResultByDate(addTaskBusinessObj);
            gvDisplayUserTask.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            gvDisplayUserTask.DataBind();
        }

        protected void btnCancelStartEnd_Click(object sender, EventArgs e)
        {
            ddlSearchClient.SelectedItem.Text = "Select Client";
            ddlSerachProject.SelectedItem.Text = "Select Project";
            gvDisplayUserTask.EditIndex = -1;
            txtSearchEndDate.Text = "";
            txtSearchStartDate.Text = "";
            GetUserTaskDetails();
        }
    }
}