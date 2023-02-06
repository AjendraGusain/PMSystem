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
    public partial class ViewTeam : System.Web.UI.Page
    {
        ITeamBusinessLogic viewTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();

        }

        private void BindList()
        {
            DataSet ds = viewTeamBA.GetTeam();
            grvViewTeam.DataSource = ds.Tables[0];
            grvViewTeam.DataBind();
        }
        protected void grvViewTeam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }
    }
}