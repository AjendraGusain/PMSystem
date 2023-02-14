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
using DataAccessLayer.Interface;

namespace ProjectManagement.Admin
{
    public partial class addTask : System.Web.UI.Page
    {
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        

        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //                string[] queryString = Request.QueryString["TaskId"].ToString().Split(new char[] { ',' });
                //                string[] queryString = Request.QueryString["TaskId"].ToString().Split(new char[] { ',' });


                int taskId = Convert.ToInt32(Request.QueryString["TaskId"]);

//                int taskId = Convert.ToInt32(queryString[0]);
//                int userId = Convert.ToInt32(queryString[1]);
                //int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                if (taskId==0)
                {
                    BindClientandProject();
                }
                else
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                    GetTaskDetails(taskId, userId);
                }
            }
        }

        private void BindEmployeeList()
        {
            ddlEmployeeName.DataSource = createTeamBA.GetUser();
            ddlEmployeeName.DataTextField = "UserName";
            ddlEmployeeName.DataValueField = "UserId";
            ddlEmployeeName.DataBind();
        }

        private void GetTaskDetails(int Id, int userId)
        {
            if (userId == 0)
            {
                btnAddTask.Text = "Assign";
            }
            else
            {
                btnAddTask.Text = "Reassign";
            }
            ddlEmployeeName.Visible = true;
            lblEmployee.Visible = true;
            DataSet dtResult = addTaskDetails.GetTaskDetailsByID(Id);
            BindClientandProject();
            ddlProjectName.SelectedValue= Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
            ddlProjectName.Enabled = false;
            ddlClientName.SelectedValue= Convert.ToInt32(dtResult.Tables[0].Rows[0]["ClientId"]).ToString();
            ddlClientName.Enabled = false;
            txtTaskID.Text = dtResult.Tables[0].Rows[0]["TaskId"].ToString();
            txtTaskID.Enabled = false;
            txtTaskName.Text= dtResult.Tables[0].Rows[0]["TaskName"].ToString();
            txtTaskName.Enabled = false;
            txtTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            txtTaskNumber.Enabled = false;
            txtTaskDescription.Text= dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            txtTaskDescription.Enabled = false;
            BindEmployeeList();
            
            ddlEmployeeName.SelectedValue= dtResult.Tables[0].Rows[0]["UserName"].ToString();
            btnResetField.Visible = false;
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            if (btnAddTask.Text == "Reassign")
            {
                addTaskBusinessObj.EmployeeName = ddlEmployeeName.SelectedValue;
            }
            else if(btnAddTask.Text == "Assign")
            {
                addTaskBusinessObj.EmployeeName = ddlEmployeeName.SelectedValue;
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
            else
            {
                //ITaskBusinessLogic addTask = (ITaskBusinessLogic)taskBusinessLogic;
                addTaskBusinessObj.ClientID = ddlClientName.SelectedValue;
                addTaskBusinessObj.ProjectID = ddlProjectName.SelectedValue;
                addTaskBusinessObj.TaskID = txtTaskID.Text.Trim();
                addTaskBusinessObj.TaskName = txtTaskName.Text.Trim();
                addTaskBusinessObj.TaskDescription = txtTaskDescription.Text.Trim();
                addTaskBusinessObj.response = addTaskDetails.InsertTaskDetails(addTaskBusinessObj);
                if (addTaskBusinessObj.response == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sucess", "alert('Record inserted sucessfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "fail", "alert('Record not inserted.');", true);
                }
                ResetAllFields();
            }
        }

        public void ResetAllFields()
        {
            ddlClientName.SelectedItem.Text = "--Select Client--";
            ddlProjectName.SelectedItem.Text = "--Select Project--";
            txtTaskID.Text = "";
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
            ddlProjectName.DataSource= addTaskDetails.GetProjectByClient(Convert.ToInt32(clientID));
            ddlProjectName.DataTextField = "ProjectName";
            ddlProjectName.DataValueField = "ProjectID";
            ddlProjectName.DataBind();
        }

        protected void btnResetField_Click(object sender, EventArgs e)
        {
            ResetAllFields();
        }
    }
}