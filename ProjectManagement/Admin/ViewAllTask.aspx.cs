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
        bool tskCmp = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  BindClientandProject();
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                Global.Designation= Session["Designation"].ToString();
                GetAllCreatedTask(userId,Global.RoleIdSession, Global.Designation);

            }
        }
        public void GetAllCreatedTask(int userId,int roleID, string Designation)
        {
            addTaskBusinessObj.RoleID = Global.RoleIdSession;
            addTaskBusinessObj.Designation= Global.Designation;
            addTaskBusinessObj.LoginUserID = userId;
            DataSet ds = assigntaskBLL.GetAllCreatedTask(addTaskBusinessObj);

            DataTable dt = ds.Tables[0];
            dt.TableName = "ViewAllTask";
            ViewState["ViewAllTask"] = dt;

            // DataSet ds = assigntaskBLL.GetAssignedTask();
            grvViewAllTask.DataSource = dt;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i]["StatusName"].ToString() == "Completed")
            //    {
            //        //LinkButton lnkBtnEdit = (LinkButton)e.Row.FindControl("btnEditTeam");
            //        //lnkBtnEdit.Visible = false;
            //    }
            //}
            grvViewAllTask.DataBind();
        }


        //protected void grvViewAllTask_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["ViewAllTask"];
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //for(int i = 0; i < dt.Rows.Count; i++)
        //        //{
        //        //    if (dt.Rows[i]["StatusName"].ToString()=="Completed")
        //        //    {
        //        //        LinkButton lnkBtnEdit = (LinkButton)e.Row.FindControl("btnEditTeam");
        //        //        lnkBtnEdit.Visible = false;
        //        //        LinkButton lnkBtnDel = (LinkButton)e.Row.FindControl("btnDeleteEmployee");
        //        //        lnkBtnDel.Visible = false;
        //        //        LinkButton lnkBtnView = (LinkButton)e.Row.FindControl("btnViewAssignedTask");
        //        //        lnkBtnView.Visible = true;
        //        //    }
        //        //    else
        //        //    {
        //        //        LinkButton lnkBtnEdit = (LinkButton)e.Row.FindControl("btnEditTeam");
        //        //        lnkBtnEdit.Visible = true;
        //        //        LinkButton lnkBtnDel = (LinkButton)e.Row.FindControl("btnDeleteEmployee");
        //        //        lnkBtnDel.Visible = true;
        //        //        LinkButton lnkBtnView = (LinkButton)e.Row.FindControl("btnViewAssignedTask");
        //        //        lnkBtnView.Visible = false;
        //        //    }
        //        //}
        //        //foreach (GridViewRow row in grvViewAllTask.Rows)
        //        //{
        //            for (int i = 0; i < grvViewAllTask.Rows.Count; i++)
        //            {
        //            // String header = grvViewAllTask.Columns[i].HeaderText;
        //                GridViewRow gridViewRow1 = (GridViewRow)e.Row.FindControl("btnViewAssignedTask");
        //            if (gridViewRow1.ToString() == "Completed")
        //                {
        //                    LinkButton lnkBtnEdit = (LinkButton)e.Row.FindControl("btnEditTeam");
        //                    lnkBtnEdit.Visible = false;
        //                    LinkButton lnkBtnDel = (LinkButton)e.Row.FindControl("btnDeleteEmployee");
        //                    lnkBtnDel.Visible = false;
        //                    LinkButton lnkBtnView = (LinkButton)e.Row.FindControl("btnViewAssignedTask");
        //                    lnkBtnView.Visible = true;
        //                }
        //                //else
        //                //{
        //                //    LinkButton lnkBtnEdit = (LinkButton)e.Row.FindControl("btnEditTeam");
        //                //    lnkBtnEdit.Visible = true;
        //                //    LinkButton lnkBtnDel = (LinkButton)e.Row.FindControl("btnDeleteEmployee");
        //                //    lnkBtnDel.Visible = true;
        //                //    LinkButton lnkBtnView = (LinkButton)e.Row.FindControl("btnViewAssignedTask");
        //                //    lnkBtnView.Visible = false;
        //                //}
        //            }
        //       // }
        //    }
        //}

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
            addTaskBusinessObj.RoleID = Convert.ToInt32(Session["RoleId"].ToString());
            addTaskBusinessObj.EmployeeName= Session["UserID"].ToString();
            addTaskBusinessObj.Designation= Session["Designation"].ToString();
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
                //txtTaskStartDateSearch.Text = "";
                //txtTaskEndDateSearch.Text = "";
            }
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            int userId= Convert.ToInt32(Session["UserID"].ToString());
            grvViewAllTask.EditIndex = -1;
            txtSearchEmp.Text = "";
            txtTaskStartDateSearch.Text = "";
            txtTaskEndDateSearch.Text = "";
            GetAllCreatedTask(userId, Global.RoleIdSession, Global.Designation);
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