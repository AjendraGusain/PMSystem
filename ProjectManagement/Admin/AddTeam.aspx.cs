using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class AddTeam : System.Web.UI.Page
    {

        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        int respone = 0;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeList();
            }
        }

        private void BindEmployeeList()
        {
            ddlEmployeeName.Items.Clear();
            ddlEmployeeName.DataSource = createTeamBA.GetUser();
            ddlEmployeeName.DataTextField = "UserName";
            ddlEmployeeName.DataValueField = "UserId";
            ddlEmployeeName.DataBind();
            ddlManager.Items.Clear();
            
            ddlManager.DataSource = createTeamBA.GetManager();
            ddlManager.DataTextField = "UserName";
            ddlManager.DataValueField = "UserId";
            ddlManager.DataBind();
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
            ddlTeamleader.Items.Clear();
            ddlTeamleader.DataSource = createTeamBA.GetTeamLeader();
            ddlTeamleader.DataTextField = "UserName";
            ddlTeamleader.DataValueField = "UserId";
            ddlTeamleader.DataBind();
            ddlTeamleader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string ls = "";
            createTeam.TeamName = txtTeamName.Text;
            createTeam.Manager = ddlManager.SelectedValue;
            createTeam.TeamLeader = ddlTeamleader.SelectedValue;
            foreach (ListItem item in ddlEmployeeName.Items)
            {
                if (item.Selected)
                {
                    ls += item.Value;
                    ls += ",";
                }
            }
            ls.TrimEnd(',');
            createTeam.Employee = ls;
            respone= createTeamBA.InsertTeam(createTeam);
            if(respone==1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
            }
        }
    }
}