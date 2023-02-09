using System;
using System.Collections.Generic;
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

        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClientandProject();
            }
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
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