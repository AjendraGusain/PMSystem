using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
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
    public partial class TeamDetails : System.Web.UI.Page
    {
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        int respone = 0;
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int projectId = Convert.ToInt32(Session["ProjectId"]);
                int teamId = Convert.ToInt32(Session["TeamId"]);
                GetTeam(projectId, teamId);
            }
        }

        private void GetTeam(int projectId, int teamId)
        {
            createTeam.ProjectId = projectId.ToString();
            createTeam.TeamName = "0";
            createTeam.Manager = "0";
            createTeam.TeamLeader = "0";
            DataSet ds = createTeamBA.GetTeamDetails(createTeam);
            lblProject.Text = ds.Tables[2].Rows[0]["ProjectName"].ToString();
            grvViewDetails.DataSource = ds.Tables[2];
            grvViewDetails.DataBind();
        }
    }
}