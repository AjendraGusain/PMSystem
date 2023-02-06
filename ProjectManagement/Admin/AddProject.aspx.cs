using BusinessLogicLayer;
using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class AddProject : System.Web.UI.Page
    {
        AddProjectBusinessObject addProjectObj = new AddProjectBusinessObject();
        AddProjectBusinessLogic addProjectLog = new AddProjectBusinessLogic();
        int successResult = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                if (UserId == 0)
                {
                    BindClientDetails();
                }
            }
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            addProjectObj.projectName = txtProjectName.Text.Trim();
            addProjectObj.clientID = Convert.ToInt32(ddlClientID.SelectedValue);
            addProjectObj.startDate = txtStartDate.Text.Trim();
            if(btnAddProject.Text.ToLower() == "add project")
            {
                successResult = addProjectLog.InsertProjectDetails(addProjectObj);
                if (successResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                    txtProjectName.Text = "";
                    ddlClientID.SelectedValue = "0";
                    txtStartDate.Text = "";
                }
            }

        }
        protected void BindClientDetails()
        {
            ddlClientID.Items.Clear();
            ddlClientID.DataSource = addProjectLog.GetClientDetails();
            ddlClientID.DataTextField = "ClientName";
            ddlClientID.DataValueField = "ClientId";
            ddlClientID.DataBind();
            ddlClientID.Items.Insert(0, new ListItem("-- Select Client Name --", "0"));
        }
    }
}