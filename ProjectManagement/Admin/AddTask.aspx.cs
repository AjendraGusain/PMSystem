using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;

namespace ProjectManagement.Admin
{
    public partial class addTask : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        bool checkIf = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                string Designation = Session["Designation"].ToString();
           //     int userId = Convert.ToInt32(Session["UserID"].ToString());
                checkIf = Convert.ToBoolean(Request.QueryString["checkIf"]);
                int taskId = Convert.ToInt32(Request.QueryString["TaskId"]);
                int projectID = Convert.ToInt32(Request.QueryString["ProjectId"]);
                if (taskId == 0)
                {
                    BindClientandProject(Global.RoleIdSession, Designation);
                }
                else 
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                    string editID = "";
                    if (Convert.ToInt32(Request.QueryString["EditId"]).ToString()!= "0")
                    {
                        editID = Request.QueryString["EditId"].ToString();
                    }
                    GetTaskDetails(taskId, userId, projectID, editID, checkIf);
                }
            }
        }

        private void BindEmployee(string teamId, string projectId)
        {
            addTaskBusinessObj.ProjectID = projectId; //Request.QueryString["ProjectId"];
            addTaskBusinessObj.TeamId = teamId;
            DataSet dsUsers = addTaskDetails.GetAllUsers(addTaskBusinessObj);
            if (dsUsers.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "message", "alert('No team assigned to this project. Please assign any team first.'); parent.location.href='AssignTask.aspx'", true);
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No team assigned to this project. Please assign any team first.');location.href = 'AssignTask.aspx';", true);
                return;
            }
            else
            {
                gvAllEmployee.DataSource = dsUsers.Tables[0];
                gvAllEmployee.DataBind();
            }
        }

        private void GetTaskDetails(int TaskId, int userId, int projectID, string editId, bool checkIf)
        {
            if (editId!="")
            {
                btnAddTask.Text = "Update";
                addTaskBusinessObj.TaskID = TaskId;
                addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(addTaskBusinessObj);
            }
           else if (userId == 0)
            {
                btnAddTask.Text = "Assign";
                addTaskBusinessObj.TaskID = TaskId;
                //addTaskBusinessObj.RoleID = Global.RoleId;
                //addTaskBusinessObj.Designation = Global.Designation;
                addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(addTaskBusinessObj);
                DataTable dtAssign = addTaskBusinessObj.dsResult.Tables[0];
                dtAssign.TableName = "AssignTask";
                ViewState["AssignTask"] = dtAssign;
            }
            else
            {
                btnAddTask.Text = "Reassign";
                addTaskBusinessObj.TaskID = TaskId;
                addTaskBusinessObj.dsResult = addTaskDetails.ReAssignTask(addTaskBusinessObj);
                DataTable dtReassign = addTaskBusinessObj.dsResult.Tables[0];
                dtReassign.TableName = "ReassignTask";
                ViewState["ReassignTask"] = dtReassign;
            }
            if(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["StatusId"].ToString()=="3"&& editId == "")
            {
                if (checkIf == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User is already working on this task. Please pause the task first.');", true);
                    Response.Redirect("TaskDetails.aspx?TaskId=" + TaskId + "&UserId=" + userId + "&ProjectId=" + projectID);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "message", "alert('User is already working on this task. Please pause the task first.'); parent.location.href='AssignTask.aspx'", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User is already working on this task. Please pause the task first.');location.href = 'AssignTask.aspx';", true);
                    return;
                }
            }
            BindClientandProject(Global.RoleIdSession, Session["Designation"].ToString());
            ddlProjectName.SelectedValue = Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"]).ToString();
            ddlClientName.SelectedValue = Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ClientId"]).ToString();
            ddlTeamName.SelectedValue = Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["Id"]).ToString();
            txtTaskName.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskName"].ToString();
            txtTaskNumber.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            txtTaskDescription.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            ddlProjectName.Enabled = false;
            ddlClientName.Enabled = false;
            ddlTeamName.Enabled = false;
            if (editId == "")
            {
                txtSearch.Visible = true;
                btnSearch.Visible = true;
                btnClearAll.Visible = true;
                txtTaskName.Enabled = false;
                txtTaskNumber.Enabled = false;
                txtTaskDescription.Enabled = false;
                gvAllEmployee.Visible = true;
                BindEmployee(ddlTeamName.SelectedValue, ddlProjectName.SelectedValue);
                if (btnAddTask.Text != "Assign")
                {
                    List<string> userList = new List<string>();
                    for (int i = 0; i < addTaskBusinessObj.dsResult.Tables[0].Rows.Count; i++)
                    {
                        userList.Add(addTaskBusinessObj.dsResult.Tables[0].Rows[i]["TeamMemberID"].ToString());
                    }
                    foreach (GridViewRow row in gvAllEmployee.Rows)
                    {
                        Label chkRecord = (Label)row.FindControl("lblTeamMemberID");
                        string teamMemberID = chkRecord.Text;
                        for (int i = 0; i < addTaskBusinessObj.dsResult.Tables[0].Rows.Count; i++)
                        {
                            if (addTaskBusinessObj.dsResult.Tables[0].Rows[i]["TeamMemberID"].ToString() == teamMemberID)
                            {
                                CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                                chckrw.Checked = true;
                            }
                        }
                    }
                }
            }
            btnResetField.Visible = false;
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            checkIf = Convert.ToBoolean(Request.QueryString["checkIf"]);
            int checkRecord = 0;
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            if (btnAddTask.Text == "Reassign")
            {
                addTaskBusinessObj.AssignedDate = DateTime.Now;
                DataTable dtreassign = (DataTable)ViewState["ReassignTask"];
                //addTaskBusinessObj.dsResult = addTaskDetails.ReAssignTask(addTaskBusinessObj.TaskID);
                //addTaskBusinessObj.ProjectID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString();
                //addTaskBusinessObj.TaskNumber = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();

                addTaskBusinessObj.ProjectID = dtreassign.Rows[0]["ProjectId"].ToString();
                addTaskBusinessObj.TaskNumber = dtreassign.Rows[0]["TaskNumber"].ToString();
                addTaskBusinessObj.LoginUserID = loginUserID;

                List<string> userList = new List<string>();
                for (int i = 0; i < dtreassign.Rows.Count; i++)
                {
                    userList.Add(dtreassign.Rows[i]["TeamMemberID"].ToString());
                }
                int count;
                foreach (var item in userList)
                {
                    count = 0;
                    foreach (GridViewRow row in gvAllEmployee.Rows)
                    {
                        CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                        if (chckrw.Checked == true)
                        {
                            checkRecord += 1;
                        }
                    }
                    if (checkRecord > 0)
                    {
                        foreach (GridViewRow row in gvAllEmployee.Rows)
                        {
                            CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                            if (chckrw.Checked == true)
                            {
                                Label teamMember = (Label)row.FindControl("lblTeamMemberID");
                                Label employee = (Label)row.FindControl("lblUserId");
                                string teamMemberID = teamMember.Text;
                                string employeeID = employee.Text;

                                addTaskBusinessObj.EmployeeName = employeeID;
                                addTaskBusinessObj.TeamMemberID = Convert.ToInt32(teamMemberID);
                                if (item == teamMemberID)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    if (count == 0)
                    {
                        addTaskBusinessObj.TeamMemberID = Convert.ToInt32(item);
                        addTaskBusinessObj.response = addTaskDetails.UpdateAssignedTaskDetails(addTaskBusinessObj);
                    }
                }
                int insertCount;

                foreach (GridViewRow row in gvAllEmployee.Rows)
                {
                    CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                    if (chckrw.Checked == true)
                    {
                        checkRecord += 1;
                    }
                }
                if (checkRecord > 0)
                {
                    foreach (GridViewRow row in gvAllEmployee.Rows)
                    {
                        insertCount = 0;
                        CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                        if (chckrw.Checked == true)
                        {
                            Label teamMember = (Label)row.FindControl("lblTeamMemberID");
                            Label employee = (Label)row.FindControl("lblUserId");
                            string teamMemberID = teamMember.Text;
                            string employeeID = employee.Text;
                            Label team = (Label)row.FindControl("lblTeamID");
                            string teamID = team.Text;
                            addTaskBusinessObj.TeamId = teamID;
                            addTaskBusinessObj.EmployeeName = employeeID;
                            addTaskBusinessObj.TeamMemberID = Convert.ToInt32(teamMemberID);
                            foreach (var item in userList)
                            {
                                if (addTaskBusinessObj.ProjectID == dtreassign.Rows[0]["ProjectId"].ToString()
                                && addTaskBusinessObj.TaskID == Convert.ToInt32(dtreassign.Rows[0]["TaskId"].ToString())
                                && item == teamMemberID)
                                {
                                    insertCount++;
                                }
                            }
                            if (insertCount == 0)
                            {
                                addTaskBusinessObj.response = addTaskDetails.InsertAssignedTaskDetails(addTaskBusinessObj);
                            }
                        }
                    }
                }
                if (addTaskBusinessObj.response == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Task not Reassigned.');", true);
                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task Reassigned sucessfully.');location.href = 'TaskDetails.aspx';", true);
                    //   ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task Reassigned sucessfully.');", true);
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Task not Reassigned.');", true);
                //}
                //Response.Redirect("~/Admin/AssignTask");
                if (checkIf == true)
                {
                    Response.Redirect("TaskDetails.aspx?TaskId=" + addTaskBusinessObj.TaskID + "&UserId=" + addTaskBusinessObj.EmployeeName + "&ProjectId=" + addTaskBusinessObj.ProjectID);
                    //Response.Redirect("TaskDetails.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "sucess", "alert('Task Reassigned sucessfully'); parent.location.href='AssignTask.aspx'", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task Reassigned sucessfully.');", true);
                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task Reassigned sucessfully.');location.href = 'AssignTask.aspx';", true);
                    //Response.Redirect("AssignTask.aspx");
                }
            }
            else if (btnAddTask.Text == "Assign")
            {
                addTaskBusinessObj.AssignedDate = DateTime.Now;
                DataTable dtassign = (DataTable)ViewState["AssignTask"];
                //addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
                //addTaskBusinessObj.ProjectID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString();
                //addTaskBusinessObj.TaskNumber = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();

                addTaskBusinessObj.ProjectID = dtassign.Rows[0]["ProjectId"].ToString();
                addTaskBusinessObj.TaskNumber = dtassign.Rows[0]["TaskNumber"].ToString();
                addTaskBusinessObj.LoginUserID = loginUserID;
                try
                {
                    foreach (GridViewRow row in gvAllEmployee.Rows)
                    {
                        CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                        if (chckrw.Checked == true)
                        {
                            checkRecord += 1;
                        }
                    }
                    if (checkRecord > 0)
                    {
                        foreach (GridViewRow row in gvAllEmployee.Rows)
                        {
                            CheckBox chckrw = (CheckBox)row.FindControl("chkTeamMemberID");
                            if (chckrw.Checked == true)
                            {
                                Label teamMemberId = (Label)row.FindControl("lblTeamMemberID");
                                Label teamId = (Label)row.FindControl("lblTeamID");
                                int teamID = Convert.ToInt32(teamId.Text);
                                int teamMemberID = Convert.ToInt32(teamMemberId.Text);
                                Label empId = (Label)row.FindControl("lblUserId");
                                string userName = empId.Text;
                                Label role = (Label)row.FindControl("lblRoleName");
                                addTaskBusinessObj.EmployeeName = userName;
                                addTaskBusinessObj.TeamMemberID = teamMemberID;
                                addTaskBusinessObj.TeamId = teamID.ToString();
                                addTaskBusinessObj.response = addTaskDetails.InsertAssignedTaskDetails(addTaskBusinessObj);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('No record selected. Please select atleast one record.');", true);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                if (addTaskBusinessObj.response > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "sucess", "alert('Task assigned sucessfully'); parent.location.href='AssignTask.aspx'", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task assigned sucessfully.');location.href = 'AssignTask.aspx';", true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task assigned sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Task not assigned.');", true);
                }
                //Response.Redirect("~/Admin/AssignTask");
            }
            else
            {
                addTaskBusinessObj.ClientID = ddlClientName.SelectedValue;
                addTaskBusinessObj.ProjectID = ddlProjectName.SelectedValue;
                addTaskBusinessObj.TaskNumber = txtTaskNumber.Text.Trim();
                addTaskBusinessObj.TaskName = txtTaskName.Text.Trim();
                addTaskBusinessObj.RoleID = Global.RoleIdSession;
                addTaskBusinessObj.Designation = Global.Designation;
                addTaskBusinessObj.LoginUserID = loginUserID;
                if (btnAddTask.Text == "Create Task")
                {
                    DataSet ds = addTaskDetails.GetAllCreatedTask(addTaskBusinessObj);
                    DataRow[] foundTask = ds.Tables[0].Select("TaskNumber = '" + addTaskBusinessObj.TaskNumber + "'");
                    if (foundTask.Length != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Task Number already exists in record.');", true);
                        return;
                    }
                }
                addTaskBusinessObj.TaskDescription = txtTaskDescription.Text.Trim();
                addTaskBusinessObj.TeamId= ddlTeamName.SelectedValue;
                if (btnAddTask.Text == "Update")
                {
                    addTaskBusinessObj.response = addTaskDetails.UpdateTaskDetails(addTaskBusinessObj);
                    if (addTaskBusinessObj.response == 1)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Record updated sucessfully.');location.href = 'ViewAllTask.aspx';", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "sucess", "alert('Record updated sucessfully.'); parent.location.href='ViewAllTask.aspx'", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "fail", "alert('Record not updated.');location.href = 'ViewAllTask.aspx';", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "sucess", "alert('Record not updated sucessfully.'); parent.location.href='ViewAllTask.aspx'", true);
                    }
                }
                else
                {
                    addTaskBusinessObj.response = addTaskDetails.InsertTaskDetails(addTaskBusinessObj);

                    if (addTaskBusinessObj.response == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Record inserted sucessfully.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Record not inserted.');", true);
                    }
                }
               ResetAllFields();
           //     BindClientandProject(Global.RoleId, Global.Designation);
            }
        }

        public void ResetAllFields()
        {
            //ddlClientName.Items.Clear();
            //ddlProjectName.Items.Clear();
            //ddlTeamName.Items.Clear();
            ddlClientName.Items.Insert(0, new ListItem("-- Select Client --", "0"));
            ddlProjectName.Items.Insert(0, new ListItem("-- Select Project --", "0"));
            ddlTeamName.Items.Insert(0, new ListItem("-- Select Team --", "0"));
            //ddlClientName.SelectedItem.Text = "--Select Client--";
            //ddlProjectName.SelectedItem.Text = "--Select Project--";
            //ddlTeamName.SelectedItem.Text = "--Select Team--";
            txtTaskNumber.Text = "";
            txtTaskName.Text = "";
            txtTaskDescription.Text = "";
        }

        protected void BindClientandProject(int RoleId, string Designation)
        {
            int userid= Convert.ToInt32(Session["UserID"].ToString());
            addTaskBusinessObj.RoleID = RoleId;
            addTaskBusinessObj.Designation = Designation;
            addTaskBusinessObj.LoginUserID = userid;
            ddlClientName.Items.Clear();
            ddlClientName.DataSource = addTaskDetails.GetAllClients(addTaskBusinessObj);
            ddlClientName.DataTextField = "ClientName";
            ddlClientName.DataValueField = "ClientID";
            ddlClientName.DataBind();
            ddlClientName.Items.Insert(0, new ListItem("-- Select Client --", "0"));


            ddlProjectName.Items.Clear();
            ddlProjectName.DataSource = addTaskDetails.GetAllProject();
            ddlProjectName.DataTextField = "ProjectName";
            ddlProjectName.DataValueField = "ProjectID";
            ddlProjectName.DataBind();
            ddlProjectName.Items.Insert(0, new ListItem("-- Select Project --", "0"));
            ddlTeamName.Items.Clear();
            ddlTeamName.DataSource = addTaskDetails.GetAllTeam();
            ddlTeamName.DataTextField = "TeamName";
            ddlTeamName.DataValueField = "Id";
            ddlTeamName.DataBind();
            ddlTeamName.Items.Insert(0, new ListItem("-- Select Team --", "0"));

        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            addTaskBusinessObj.ClientID= ddlClientName.SelectedValue;
            //string clientID = ddlClientName.SelectedValue;
            //ddlProjectName.DataSource = addTaskDetails.GetProjectByClient(Convert.ToInt32(clientID));
            ddlProjectName.DataSource = addTaskDetails.GetProjectByClient(addTaskBusinessObj);
            ddlProjectName.DataTextField = "ProjectName";
            ddlProjectName.DataValueField = "ProjectID";
            ddlProjectName.DataBind();
            //ddlProjectName.Items.Insert(0, new ListItem("-- Select Project --", "0"));
            //addTaskBusinessObj.ProjectID = ddlProjectName.SelectedValue;
            //ddlTeamName.DataSource = addTaskDetails.GetAllTeamByClient(addTaskBusinessObj);
            //ddlTeamName.DataTextField = "TeamName";
            //ddlTeamName.DataValueField = "Id";
            //ddlTeamName.DataBind();
        }

        protected void btnResetField_Click(object sender, EventArgs e)
        {
            ResetAllFields();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            addTaskBusinessObj.ProjectID= Request.QueryString["ProjectId"];
            addTaskBusinessObj.SearchResult = txtSearch.Text;
            addTaskBusinessObj.dsResult = addTaskDetails.SearchResult(addTaskBusinessObj);
            gvAllEmployee.DataSource = addTaskBusinessObj.dsResult.Tables[0];
            gvAllEmployee.DataBind();
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["AssignTask"];
            addTaskBusinessObj.TeamId = Convert.ToInt32(dt.Rows[0]["Id"]).ToString();
            addTaskBusinessObj.ProjectID = Convert.ToInt32(dt.Rows[0]["ProjectId"]).ToString(); //Request.QueryString["ProjectId"];
            gvAllEmployee.EditIndex = -1;
            BindEmployee(addTaskBusinessObj.TeamId, addTaskBusinessObj.ProjectID);
            txtSearch.Text = "";
        }

        protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            addTaskBusinessObj.ProjectID = ddlProjectName.SelectedValue;
            //string clientID = ddlClientName.SelectedValue;
            //ddlProjectName.DataSource = addTaskDetails.GetProjectByClient(Convert.ToInt32(clientID));
            //ddlTeamName.DataSource = addTaskDetails.GetProjectByClient(addTaskBusinessObj);
            //ddlTeamName.DataTextField = "TeamName";
            //ddlTeamName.DataValueField = "Id";
            //ddlTeamName.DataBind();

            //addTaskBusinessObj.ProjectID = ddlProjectName.SelectedValue;
            ddlTeamName.DataSource = addTaskDetails.GetAllTeamByClient(addTaskBusinessObj);
            ddlTeamName.DataTextField = "TeamName";
            ddlTeamName.DataValueField = "Id";
            ddlTeamName.DataBind();
            //ddlClientName.Items.Insert(0, new ListItem("-- Select Client --", "0"));
            //ddlProjectName.Items.Insert(0, new ListItem("-- Select Project --", "0"));
          //  ddlTeamName.Items.Insert(0, new ListItem("-- Select Team --", "0"));
        }
    }
}