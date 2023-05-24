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
    public partial class ViewTeam : System.Web.UI.Page
    {
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.Role = Session["Role"].ToString();
                Global.Designation = Session["Designation"].ToString();
                Global.UserId = Convert.ToInt32(Session["UserID"].ToString());
                BindList();
            }
        }

        private void BindList()
        {
            createTeam.ProjectId = "0";
            createTeam.TeamName = "0";
            dtResult = createTeamBA.GetViewTeam(createTeam);
            if (Global.Designation == "Manager")
            {
                DataRow[] filterNext = dtResult.Tables[0].Select("ManagerId = '" + Global.UserId + "'");
                if (filterNext.Length > 0)
                {
                    var rowsToUpdate = dtResult.Tables[0].AsEnumerable().Where(r => r.Field<int>("ManagerId") == Global.UserId).CopyToDataTable(); ;
                    grvAllViewTeam.DataSource = rowsToUpdate;
                }
                else
                    grvAllViewTeam.DataSource = filterNext;
            }
            else
            {
                grvAllViewTeam.DataSource = dtResult.Tables[0];
            }
            grvAllViewTeam.DataBind();
        }
        protected void grvViewTeam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTeam")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                createTeam.Role = "2";
                Response.Redirect("TeamDetails.aspx?");
            }
            if (e.CommandName == "EditTeam")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string TLUserId = commandArgs[2];
                string ParrentTeamMemberId = commandArgs[3];
                string ViewTeam = "ViewTeam";
                string Role = "3";
                createTeam.Role = "1";
                Response.Redirect("AddTeamEmployee.aspx?ProjectId=" + ProjectId.Trim() + "&TeamId=" + TeamId + "&TLUserId=" + TLUserId.Trim() + "&ParrentTeamMemberId=" + ParrentTeamMemberId.Trim() + "&ViewTeam=" + ViewTeam.Trim());
            }
            if (e.CommandName == "DeleteTeam")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string ParrentTeamMemberId = commandArgs[2];
                string ViewTeam = "DeleteTeam";
                string Role = "3";
                createTeam.Role = "1";
                Response.Redirect("AddTeamEmployee.aspx?ProjectId=" + ProjectId.Trim() + "&TeamId=" + TeamId + "&ParrentTeamMemberId=" + ParrentTeamMemberId.Trim() + "&ViewTeam=" + ViewTeam.Trim());
            }
        }

        protected void grvAllViewTeam_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnSearchTeam_Click(object sender, EventArgs e)
        {
            createTeam.SearchTeam = txtSearchTeam.Text.ToString();
            DataSet dsResult = createTeamBA.GetViewTeam(createTeam);
            grvAllViewTeam.DataSource = dsResult.Tables[0];
            grvAllViewTeam.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            grvAllViewTeam.EditIndex = -1;
            txtSearchTeam.Text = "";
            BindList();
        }
    }
}