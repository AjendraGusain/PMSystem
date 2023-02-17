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
        DataSet dtResult = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                int taskId = Convert.ToInt32(Request.QueryString["TaskId"]);
                if (taskId == 0)
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

            //lsEmpoloyee.DataSource = createTeamBA.GetUser();
            //lsEmpoloyee.DataTextField = "UserName";
            //lsEmpoloyee.DataValueField = "UserId";
            //lsEmpoloyee.DataBind();

        }

        private void GetTaskDetails(int Id, int userId)
        {
            
            if (userId == 0)
            {
                btnAddTask.Text = "Assign";
                dtResult = addTaskDetails.AssignTask(Id);
            }
            else
            {
                btnAddTask.Text = "Reassign";
                dtResult = addTaskDetails.ReAssignTask(Id);
            }
            
            ddlEmployeeName.Visible = true;
            lblEmployee.Visible = true;
            BindClientandProject();
            ddlProjectName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
            ddlProjectName.Enabled = false;
            ddlClientName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ClientId"]).ToString();
            ddlClientName.Enabled = false;
            txtTaskName.Text = dtResult.Tables[0].Rows[0]["TaskName"].ToString();
            txtTaskName.Enabled = false;
            txtTaskNumber.Text = dtResult.Tables[0].Rows[0]["TaskNumber"].ToString();
            txtTaskNumber.Enabled = false;
            txtTaskDescription.Text = dtResult.Tables[0].Rows[0]["TaskDescription"].ToString();
            txtTaskDescription.Enabled = false;
            BindEmployeeList();
            if(btnAddTask.Text == "Assign")
            {

            }
            else
            {
               // lsEmpoloyee.SelectedValue = dtResult.Tables[0].Rows[0]["UserId"].ToString();
                ddlEmployeeName.SelectedValue = dtResult.Tables[0].Rows[0]["UserId"].ToString();
            }
            
            btnResetField.Visible = false;
            
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            int loginUserID = Convert.ToInt32(Session["UserID"].ToString());
            if (btnAddTask.Text == "Reassign")
            {
                //DropDownList[] arr = { ddlEmployeeName };  //list of all dropdownlists.
                //foreach (var d in arr)
                //{
                //    addTaskBusinessObj.EmployeeName = ddlEmployeeName.SelectedValue;
                //    addTaskBusinessObj.response = addTaskDetails.InsertAssignedTaskDetails(addTaskBusinessObj);
                //}
            }
            else if (btnAddTask.Text == "Assign")
            {
                addTaskBusinessObj.TaskID = Convert.ToInt32(Request.QueryString["TaskId"]);
                addTaskBusinessObj.AssignedDate = DateTime.Now;
                dtResult = addTaskDetails.AssignTask(addTaskBusinessObj.TaskID);
                addTaskBusinessObj.ProjectID = dtResult.Tables[0].Rows[0]["ProjectId"].ToString();
                addTaskBusinessObj.TaskNumber = dtResult.Tables[0].Rows[0]["TaskId"].ToString();
                addTaskBusinessObj.LoginUserID = loginUserID;
                string ls = "";
                foreach (ListItem listItem in ddlEmployeeName.Items)
                {
                    if (listItem.Selected)
                    {
                        ls += listItem.Value.ToString();
                        addTaskBusinessObj.EmployeeName = ls;
                      //  addTaskBusinessObj.response = addTaskDetails.InsertAssignedTaskDetails(addTaskBusinessObj);
                    }
                }
                if (addTaskBusinessObj.response > 0)
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
                addTaskBusinessObj.TaskNumber = txtTaskNumber.Text.Trim();
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
    }
}