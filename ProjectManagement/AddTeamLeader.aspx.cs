using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement
{
	public partial class AddTeamLeader1 : System.Web.UI.Page
	{
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindList();

            }
        }

        private void BindList()
        {
            ddlMProject.DataSource = createTeamBA.GetTeamName();
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();
            createTeam.ProjectId = ddlMProject.SelectedValue;
            createTeam.TeamName = ddlMTeamName.SelectedValue;

            
            //foreach (var item in checkList)
            //{
            //    lsTeamLeader.DataSource = managerName.GetAllEmployee(item);
            //    lsTeamLeader.DataTextField = "UserName";
            //    lsTeamLeader.DataValueField = "UserId";
            //    lsTeamLeader.DataBind();
            //}
        }

        protected void btnAddTeamLeader_Click(object sender, EventArgs e)
        {
            if (btnAddTeamLeader.Text == "Update")
            {
                int ProjectId = Convert.ToInt32(Session["ProjectId"]);
                int TeamId = Convert.ToInt32(Session["TeamId"]);
                createTeam.Manager = Session["Manager"].ToString();
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;
                //lsTeamLeader.DataSource = managerName.GetAllEmployee();
                //lsTeamLeader.DataTextField = "UserName";
                //lsTeamLeader.DataValueField = "UserId";
                //lsTeamLeader.DataBind();
                List<string> userList = new List<string>();
                int count = 0;
               
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsTeamLeader.DataSource = userList;
                dtResult.Reset();
                foreach (var item in userList)
                {
                    count = 0;
                    foreach (ListItem listItem in lsTeamLeader.Items)
                    {
                        if (listItem.Selected)
                        {
                            createTeam.Manager = listItem.Value.ToString();
                            if (item == createTeam.Manager)
                            {
                                count++;
                            }
                            if (count == 0)
                            {
                                createTeam.Manager = listItem.Value.ToString();
                                createTeam.ProjectId = ddlMProject.SelectedValue;
                                createTeam.TeamName = ddlMTeamName.SelectedValue;
                                createTeam.ParentTeamId = ddlManager.SelectedValue;
                                createTeam.IsActive = 1;
                                createTeam.Role = "4";
                                createTeamBA.InsertTeamMember(createTeam);
                            }
                        }
                    }
                    if (count == 0)
                    {
                        createTeam.Manager = item;
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.ParentTeamId = ddlManager.SelectedValue;
                        createTeam.IsActive = 0;
                        createTeam.Role = "4";
                        createTeamBA.UpdateTeamMember(createTeam);
                    }

                }
                //dtResult.Reset();
                gridViewList();
            }
            if (btnAddTeamLeader.Text == "Add TeamLeader")
            {
                foreach (ListItem item in lsTeamLeader.Items)
                {
                    if (item.Selected)
                    {
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.Manager = item.Value;
                        createTeam.ParentTeamId = ddlManager.SelectedValue;
                        createTeam.IsActive = 1;
                        createTeam.Role = "4";
                        createTeamBA.InsertTeamMember(createTeam);
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "alert('Record Inserted successfully');", true);
                gridViewList();
            }
            BindList();
            //ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "alert('Record Inserted successfully');", true);
        }

        protected void grvViewTeamLeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                btnAddTeamLeader.Text = "Update";
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string parrentTeamMemberId = commandArgs[2];
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                Session["Manager"] = parrentTeamMemberId;
                //createTeam.Role = "4";
                createTeam.Manager = parrentTeamMemberId;
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
                List<string> userList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsTeamLeader.DataSource = userList;
                dtResult.Reset();
                //BindList();
               
                lsTeamLeader.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
                lsTeamLeader.DataTextField = "UserName";
                lsTeamLeader.DataValueField = "UserId";
                lsTeamLeader.DataBind();
                
                foreach (var listItem in userList)
                {
                    ListItem itm = lsTeamLeader.Items.FindByValue(listItem);
                    if (itm != null)
                    {
                        itm.Selected = true;
                    }
                }

            }


            else if (e.CommandName == "Delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                string userId = commandArgs[2];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;
                //int ProjectID3 = Convert.ToInt32(e.CommandArgument);
                int Respone = createTeamBA.DeleteTeamMember(Convert.ToInt32(userId), createTeam);
                if (Respone > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                }
                gridViewList();
            }
        }

        protected void grvViewTeamLeader_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvViewTeamLeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddlMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedId = ddlMProject.SelectedValue;
            ddlMTeamName.DataSource = createTeamBA.GetTeamNameById(Convert.ToInt32(ChangedId));
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "Id";
            ddlMTeamName.DataBind();
            ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
        }

        protected void ddlMTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedTeamId = ddlMTeamName.SelectedValue;
            string ChangedId = ddlMProject.SelectedValue;
            ddlManager.DataSource = createTeamBA.GetManager(Convert.ToInt32(ChangedTeamId), Convert.ToInt32(ChangedId));
            ddlManager.DataTextField = "UserName";
            ddlManager.DataValueField = "TeamMemberId";
            ddlManager.DataBind();
            string ProjectId = ddlMProject.SelectedValue;
            string TeamName = ddlMTeamName.SelectedValue;
            string Manager = "0";
            string TLId = "0";
            
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
            Session["ProjectId"] = ProjectId;
            Session["TeamId"] = TeamName;
            Session["Manager"] = Manager;
            Session["TLId"] = TLId;
            gridViewList();

        }

        protected void ddlManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProjectId = ddlMProject.SelectedValue;
            string TeamName = ddlMTeamName.SelectedValue;
            string Manager = ddlManager.SelectedValue;
            string TLId = "0";
            Session["ProjectId"] = ProjectId;
            Session["TeamId"] = TeamName;
            Session["Manager"] = Manager;
            Session["TLId"] = TLId;
            gridViewList();
        }



        private void gridViewList()
        {

            createTeam.ProjectId = Session["ProjectId"].ToString();
            createTeam.TeamName = Session["TeamId"].ToString();
            createTeam.Manager = Session["Manager"].ToString();
            createTeam.TeamLeader = Session["TLId"].ToString();
            dtResult = createTeamBA.GetTeamMemberTeamLeader(createTeam);
            grvViewTeamLeader.DataSource = dtResult.Tables[1];
            grvViewTeamLeader.DataBind();
            dtResult.Reset();
            lsTeamLeader.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            lsTeamLeader.DataTextField = "UserName";
            lsTeamLeader.DataValueField = "UserId";
            lsTeamLeader.DataBind();
            //dtResult.Reset();
        }
    }
}