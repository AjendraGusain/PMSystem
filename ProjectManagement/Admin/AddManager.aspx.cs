using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class AddManager : System.Web.UI.Page
    {
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {

            //            BindProject();
            DataSet ds = createTeamBA.GetTeamName();
            grvViewManager.DataSource = ds.Tables[0];
            grvViewManager.DataBind();
            //ddlProject.Items.Clear();

            ddlMProject.DataSource = createTeamBA.GetTeamName();
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();
            //ddlMTeamName.Items.Clear();
           
            //ddlTeamleader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
        }

        protected void grvViewManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnAddTeamName_Click(object sender, EventArgs e)
        {

        }

       

        protected void ddlMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedId = ddlMProject.SelectedValue;
            ddlMTeamName.DataSource = createTeamBA.GetTeamNameById(Convert.ToInt32(ChangedId));
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "ProjectId";
            ddlMTeamName.DataBind();
        }
    }
}