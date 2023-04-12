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
                // AddHeaders();
            }

        }
        //protected void AddHeaders()
        //{
        //    if (AllProjects.Rows.Count > 0)
        //    {
        //        //This replaces <td> with <th>    
        //        AllProjects.UseAccessibleHeader = true;
        //        //This will add the <thead> and <tbody> elements    
        //        AllProjects.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        //This adds the <tfoot> element. Remove if you don't have a footer row    
        //        AllProjects.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}
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
                var Response = _projectBL.DeleteProject(Id);
                if (Response > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    BindProjectGrid();

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
    }
}