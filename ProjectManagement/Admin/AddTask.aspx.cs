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
                checkIf = Convert.ToBoolean(Request.QueryString["checkIf"]);
                int taskId = Convert.ToInt32(Request.QueryString["TaskId"]);
                int projectID = Convert.ToInt32(Request.QueryString["ProjectId"]);
                if (taskId == 0)
                {
                    BindClientandProject();
                }
                else 
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                    string editID = "";
                    if (Convert.ToInt32(Request.QueryString["EditId"]).ToString()!= "0")
                    {
                        editID = Request.QueryString["EditId"].ToString();
                    }
                    
                    //string editID = "";
                    //if (userId != 0)
                    //{
                    //    editID = Request.QueryString["EditId"].ToString();
                    //}
                    GetTaskDetails(taskId, userId, projectID, editID, checkIf);
                }
            }
        }

        private void BindEmployee()
        {
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            DataSet dsUsers = addTaskDetails.GetAllUsers(addTaskBusinessObj);
            if (dsUsers.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No team assigned to this project. Please assign any team first.');location.href = 'AssignTask.aspx';", true);
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
                addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(TaskId);
            }
           else if (userId == 0)
            {
                btnAddTask.Text = "Assign";
                addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(TaskId);
            }
            else
            {
                btnAddTask.Text = "Reassign";
                addTaskBusinessObj.dsResult = addTaskDetails.ReAssignTask(TaskId);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User is already working on this task. Please pause the task first.');location.href = 'AssignTask.aspx';", true);
                    return;
                }
            }
            BindClientandProject();
            ddlProjectName.SelectedValue = Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"]).ToString();
            ddlClientName.SelectedValue = Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ClientId"]).ToString();
            txtTaskName.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskName"].ToString();
            txtTaskNumber.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            txtTaskDescription.Text = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            ddlProjectName.Enabled = false;
            ddlClientName.Enabled = false;
            if (editId == "")
            {
                txtSearch.Visible = true;
                btnSearch.Visible = true;
                btnClearAll.Visible = true;
                
                txtTaskName.Enabled = false;
                txtTaskNumber.Enabled = false;
                txtTaskDescription.Enabled = false;
                gvAllEmployee.Visible = true;
                BindEmployee();
                //   BindEmployeeList(projectID);
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
                addTaskBusinessObj.dsResult = addTaskDetails.ReAssignTask(addTaskBusinessObj.TaskID);
                addTaskBusinessObj.ProjectID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString();
                addTaskBusinessObj.TaskNumber = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();
                addTaskBusinessObj.LoginUserID = loginUserID;

                List<string> userList = new List<string>();
                for (int i = 0; i < addTaskBusinessObj.dsResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(addTaskBusinessObj.dsResult.Tables[0].Rows[i]["TeamMemberID"].ToString());
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

                            addTaskBusinessObj.EmployeeName = employeeID;
                            addTaskBusinessObj.TeamMemberID = Convert.ToInt32(teamMemberID);
                            foreach (var item in userList)
                            {
                                if (addTaskBusinessObj.ProjectID == addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString()
                                && addTaskBusinessObj.TaskID == Convert.ToInt32(addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskId"].ToString())
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
                if (addTaskBusinessObj.response > 0)
                {
                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task Reassigned sucessfully.');location.href = 'TaskDetails.aspx';", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Task Reassigned sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Task not Reassigned.');", true);
                }
                //Response.Redirect("~/Admin/AssignTask");
                if (checkIf == true)
                {
                    Response.Redirect("TaskDetails.aspx?TaskId=" + addTaskBusinessObj.TaskID + "&UserId=" + addTaskBusinessObj.EmployeeName + "&ProjectId=" + addTaskBusinessObj.ProjectID);
                    //Response.Redirect("TaskDetails.aspx");
                }
                else
                {
                    Response.Redirect("AssignTask.aspx");
                }
            }
            else if (btnAddTask.Text == "Assign")
            {
                addTaskBusinessObj.AssignedDate = DateTime.Now;
                addTaskBusinessObj.dsResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
                addTaskBusinessObj.ProjectID = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["ProjectId"].ToString();
                addTaskBusinessObj.TaskNumber = addTaskBusinessObj.dsResult.Tables[0].Rows[0]["TaskNumber"].ToString();
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Task assigned sucessfully.');location.href = 'AssignTask.aspx';", true);
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
                addTaskBusinessObj.TaskDescription = txtTaskDescription.Text.Trim();
                addTaskBusinessObj.LoginUserID = loginUserID;
                if (btnAddTask.Text == "Update")
                {
                    addTaskBusinessObj.response = addTaskDetails.UpdateTaskDetails(addTaskBusinessObj);
                    if (addTaskBusinessObj.response == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Record updated sucessfully.');location.href = 'ViewAllTask.aspx';", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Record inserted sucessfully.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "fail", "alert('Record not updated.');location.href = 'ViewAllTask.aspx';", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Record not inserted.');", true);
                    }
                }
                else
                {
                    addTaskBusinessObj.response = addTaskDetails.InsertTaskDetails(addTaskBusinessObj);

                    if (addTaskBusinessObj.response == 1)
                    {
                       // ScriptManager.RegisterStartupScript(this, this.GetType(), "sucess", "alert('Record inserted sucessfully.');location.href = 'AssignTask.aspx';", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Record inserted sucessfully.');", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "fail", "alert('Record not inserted.');location.href = 'AssignTask.aspx';", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Record not inserted.');", true);
                    }
                }
                ResetAllFields();
            }
        }

        public void ResetAllFields()
        {
            ddlClientName.SelectedItem.Text = "--Select Client--";
            ddlProjectName.SelectedItem.Text = "--Select Project--";
            txtTaskNumber.Text = "";
            txtTaskName.Text = "";
            txtTaskDescription.Text = "";
        }

        protected void BindClientandProject()
        {
            ddlClientName.Items.Clear();
            ddlClientName.DataSource = addTaskDetails.GetAllClients();
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
        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clientID = ddlClientName.SelectedValue;
            ddlProjectName.DataSource = addTaskDetails.GetProjectByClient(Convert.ToInt32(clientID));
            ddlProjectName.DataTextField = "ProjectName";
            ddlProjectName.DataValueField = "ProjectID";
            ddlProjectName.DataBind();
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
            addTaskBusinessObj.ProjectID = Request.QueryString["ProjectId"];
            gvAllEmployee.EditIndex = -1;
            BindEmployee();
            //BindEmployeeList(Convert.ToInt32(addTaskBusinessObj.ProjectID));
            txtSearch.Text = "";
        }

        
    }
}