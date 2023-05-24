using BusinessLogicLayer.Interface;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using BussinessObjectLayer;

namespace ProjectManagement.Admin
{
    public partial class ViewProject : System.Web.UI.Page
    {
        IProjectDataAccess _projectRepo = new ProjectDataAccess();
        ProjectBusinessObject _projectBO = new ProjectBusinessObject(); // Business Object or Model
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        private readonly IProjectBusinessLogic _projectBL;
        public ViewProject()
        {
            _projectBL = new ProjectBusinessLogic(_projectRepo);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProjectGrid();
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                Global.Designation = Session["Designation"].ToString();
            }

        }

        private void BindProjectGrid()
        {
            DataSet response = _projectBL.GetAllProject();
            DataTable table = response.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                if (row["StartDate"] != DBNull.Value)
                {
                    DateTime startDateTimeValue = (DateTime)row["StartDate"];
                    DateTime startDateValue = startDateTimeValue.Date;
                    row["StartDate"] = startDateValue;
                }
                if (row["EndDate"] != DBNull.Value)
                {
                    DateTime endDateTimeValue = (DateTime)row["EndDate"];
                    DateTime endDateValue = endDateTimeValue.Date;
                    row["EndDate"] = endDateValue;
                }
            }
            AllProjects.DataSource = table;
            AllProjects.DataBind();
        }


        protected void AllProjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            if (e.CommandName == "ProjectDetail")
            {
                Response.Redirect("ProjectDetail.aspx?ProjectId=" + Id);
            }
            else if (e.CommandName == "EditProject")
            {
                Response.Redirect("AddProject.aspx?ProjectId=" + Id);
            }
            else if (e.CommandName == "DeleteProject")
            {
                addTaskBusinessObj.RoleID = Global.RoleIdSession;
                addTaskBusinessObj.Designation = Global.Designation;
                addTaskBusinessObj.LoginUserID = userId;
                DataSet dtResult = addTaskDetails.GetAllCreatedTask(addTaskBusinessObj);
                DataRow[] foundProject = dtResult.Tables[0].Select("ProjectId = '" + Id + "'");
                if (foundProject.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please reassing the task before removing the project.');", true);//location.href = 'AddTeamEmployee.aspx';
                }
                else
                {
                    var Response = _projectBL.DeleteProject(Id);
                    if (Response > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                        BindProjectGrid();
                    }
                }
            }
        }

        protected void AllProjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AllProjects.PageIndex = e.NewPageIndex;
            BindProjectGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _projectBO.ProjectName = txtProNameSearch.Text.Trim();
            _projectBO.StartDate = txtProStartDateSearch.Text.Trim();
            _projectBO.EndDate = txtProEndDateSearch.Text.Trim();
            DataSet response = _projectBL.ProjectSearch(_projectBO);
            AllProjects.DataSource = response.Tables[0];
            AllProjects.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            AllProjects.EditIndex = -1;
            txtProNameSearch.Text = "";
            txtProStartDateSearch.Text = "";
            txtProEndDateSearch.Text = "";
            BindProjectGrid();
        }
    }
}