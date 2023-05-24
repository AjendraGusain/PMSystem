using BusinessLogicLayer.Interface;
using BusinessLogicLayer;
using BussinessObjectLayer;
using DataAccessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Xml.Linq;

namespace ProjectManagement.Admin
{
    public partial class ProjectDetail : System.Web.UI.Page
    {
        private readonly IProjectBusinessLogic _projectBL;
        private readonly IClientBusinessLogic _clientBL;
        ProjectBusinessObject _projectBO = new ProjectBusinessObject(); // Business Object or Model
        IProjectDataAccess _projectDA = new ProjectDataAccess();      // Repository interface 
        IClientDataAccess _clientDA = new ClientDataAccess();
        DataSet dsResult = new DataSet();
        public ProjectDetail()
        {
            _projectBL = new ProjectBusinessLogic(_projectDA);            // Service interface 
            _clientBL = new ClientBusinessLogic(_clientDA);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                GetProjectById(ProjectId);
                GetCurrentEmployeeByProjectId(ProjectId);
                GetPastEmployeeByProjectId(ProjectId);
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
                    lblProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                    lblClientName.Text = dt.Rows[0]["ClientName"].ToString();
                    lblStartDate.Text = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                    if (dt.Rows[0]["EndDate"].ToString() != "")
                    {
                        lblEndDate.Text = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblEndDate.Text = null;
                    }
                }
            }
        }

        public void GetCurrentEmployeeByProjectId(int ProjectId)
        {
            DataSet ds = _projectBL.GetCurrentEmployeeByProjectId(ProjectId);
            if (ds != null)
            {
                grvCurrentEmployees.DataSource = ds.Tables[0];
                grvCurrentEmployees.DataBind();
            }
        }

        public void GetPastEmployeeByProjectId(int ProjectId)
        {
            DataSet ds = _projectBL.GetPastEmployeeByProjectId(ProjectId);
            if (ds != null)
            {
                grvPastEmployees.DataSource = ds.Tables[0];
                grvPastEmployees.DataBind();
            }
        }

        protected void grvCurrentEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ViewEmployeeInfo")
            {
                Response.Redirect("~/Admin/EmployeeDetail?UserId=" + e.CommandArgument.ToString());
            }
        }
    }
}