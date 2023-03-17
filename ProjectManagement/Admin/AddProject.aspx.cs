using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Net;

namespace ProjectManagement.Admin
{
    public partial class AddProject : System.Web.UI.Page
    {

        private readonly IProjectBusinessLogic _projectBL;
        private readonly IClientBusinessLogic _clientBL;

        ProjectBusinessObject _projectBO = new ProjectBusinessObject(); // Business Object or Model
        IProjectDataAccess _projectDA = new ProjectDataAccess();      // Repository interface 
        IClientDataAccess _clientDA = new ClientDataAccess();

        DataSet dsResult = new DataSet();
        // MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);

        public AddProject()
        {
            _projectBL = new ProjectBusinessLogic(_projectDA);            // Service interface 
            _clientBL = new ClientBusinessLogic(_clientDA);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                if (ProjectId == 0)
                {
                    BindDropdown();
                    btnAddProject.Text = "Add Project";
                }
                else
                {
                    BindDropdown();
                    GetProjectById(ProjectId);
                    btnAddProject.Text = "Update Project";

                }
            }
        }

        public void GetProjectById(int ProjectId)
        {
            DataSet ds = _projectBL.GetProjectById(ProjectId);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                    txtProjectStartDate.Text = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                    ddlClient.SelectedValue = dt.Rows[0]["ClientId"].ToString();

                }
            }
        }

        public void BindDropdown()
        {
            ddlClient.Items.Clear();
            ddlClient.DataSource = _clientBL.GetClients();
            ddlClient.DataTextField = "ClientName";
            ddlClient.DataValueField = "ClientId";
            ddlClient.DataBind();
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            int ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);

            _projectBO.ProjectName = txtProjectName.Text.Trim();
            _projectBO.ClientId = ddlClient.SelectedValue;//.Text.Trim();
            _projectBO.StartDate = txtProjectStartDate.Text.Trim();

            if (btnAddProject.Text == "Add Project")
            {

                DataSet checkNameds = _projectBL.GetProjectByName(_projectBO.ProjectName);
                if (checkNameds != null)
                {
                    DataTable checkNamedt = checkNameds.Tables[0];
                    if (checkNamedt.Rows.Count > 0)
                    {
                        if (_projectBO.ProjectName == checkNamedt.Rows[0]["ProjectName"].ToString())
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert(' ProjectName already exists.');", true);
                            return;
                        }

                    }
                }

                var response = _projectBL.InsertProject(_projectBO);
                if (response == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                    reset_form();
                    Response.Redirect("~/Admin/ViewProject.aspx");
                }

            }
            else
            {

                DataSet checkNameds = _projectBL.GetProjectByName(_projectBO.ProjectName);
                if (checkNameds != null)
                {
                    DataTable checkNamedt = checkNameds.Tables[0];
                    if (checkNamedt.Rows.Count > 0)
                    {
                        if (_projectBO.ProjectName == checkNamedt.Rows[0]["ProjectName"].ToString() && ProjectId != Convert.ToInt32(checkNamedt.Rows[0]["ProjectId"]))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert(' ProjectName already exists.');", true);
                            return;
                        }

                    }
                }

                var response = _projectBL.UpdateProject(_projectBO, ProjectId);
                if (response == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3ada", "alert('Record Updated successfully.');", true);
                    Response.Redirect("~/Admin/ViewProject.aspx");
                }
            }
        }


        public void reset_form()
        {
            txtProjectName.Text = "";
            ddlClient.Items.Clear();
            txtProjectStartDate.Text = "";
        }
    }
}