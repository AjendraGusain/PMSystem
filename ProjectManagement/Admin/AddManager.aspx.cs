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
    public partial class AddManager : System.Web.UI.Page
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
            ddlMProject.Items.Insert(0, new ListItem("-- Select Project Name --", "0"));
            
        }

        protected void grvViewManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditManager")
            {
                btnAddTeamName.Text = "Update";
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                createTeam.Role = "3";
                createTeam.Manager = "0";
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                //BindList();
                ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
                lsManager.DataSource = managerName.GetAllEmployee();
                lsManager.DataTextField = "UserName";
                lsManager.DataValueField = "UserId";
                lsManager.DataBind();
                List<string> userList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsManager.DataSource = userList;
                foreach (var listItem in userList)
                {
                    ListItem itm = lsManager.Items.FindByValue(listItem);
                    if (itm != null)
                    {
                        itm.Selected = true;
                    }
                }
                dtResult.Reset();
                
            }
            else if (e.CommandName == "DeleteManager")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                string userId= commandArgs[2];
                string teamMemberId = commandArgs[3];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;
                //int ProjectID3 = Convert.ToInt32(e.CommandArgument);

                dtResult = createTeamBA.GetTeamDetails(createTeam);
                DataRow[] foundteamMember = dtResult.Tables[1].Select("ParrentTeamMemberId = '" + teamMemberId + "'");
                if (foundteamMember.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please remove team members before removing the manager.');location.href = 'AddManager.aspx';", true);
                }
                else
                {
                    createTeam.Manager = userId;
                    createTeam.ParentTeamId = "0";
                    createTeam.IsActive = 0;
                    createTeam.Role = "4";
                    int Respone = createTeamBA.UpdateTeamMember(createTeam);
                    //int Respone = createTeamBA.DeleteTeamMember(Convert.ToInt32(userId), createTeam);
                    if (Respone > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Manager deleted successfully');", true);
                    }
                    gridViewList();
                }
            }
        }

        protected void btnAddTeamName_Click(object sender, EventArgs e)
        {
            if (btnAddTeamName.Text == "Update")
            {
                int ProjectId = Convert.ToInt32(Session["ProjectId"]);
                int TeamId= Convert.ToInt32( Session["TeamId"]) ;
                //createTeam.Role = "3";
                createTeam.Manager = "0";
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;
                int count = 0;
                List<string> userList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsManager.DataSource = userList;
                foreach (var item in userList)
                {
                    count = 0;
                    int countFinal = 0;
                    foreach (ListItem listItem in lsManager.Items)
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
                                createTeam.ParentTeamId = "0";
                                createTeam.IsActive = 1;
                                createTeam.Role = "3";
                                createTeamBA.InsertTeamMember(createTeam);
                            }
                            countFinal += count;
                            count = 0;
                        }
                    }
                    if (count == countFinal)
                    {
                        createTeam.Manager = item;
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.ParentTeamId = "0";
                        createTeam.IsActive = 0;
                        createTeam.Role = "3";
                        createTeamBA.UpdateTeamMember(createTeam);
                    }

                }
                
                dtResult.Reset();
                gridViewList();
                
            }
            if (btnAddTeamName.Text == "Add Manager")
            {
                foreach (ListItem item in lsManager.Items)
                {
                    if (item.Selected)
                    {
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.Manager = item.Value;
                        createTeam.ParentTeamId = "0";
                        createTeam.IsActive = 1;
                        createTeam.Role = "3";
                        int response = createTeamBA.InsertTeamMember(createTeam);
                        if (response == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "alert('" + item.Value + "Already in this Project');", true);
                        }
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "alert('Record Inserted successfully');", true);
                gridViewList();
            }
            BindList();
            btnAddTeamName.Text = "Add Manager";
        }



        protected void ddlMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedId = ddlMProject.SelectedValue;
            ddlMTeamName.DataSource = createTeamBA.GetTeamNameById(Convert.ToInt32(ChangedId));
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "Id";
            ddlMTeamName.DataBind();
            ddlMTeamName.Items.Insert(0, new ListItem("-- Select Team Name --", "0"));


        }

        protected void grvViewManager_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvViewManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        

        protected void ddlMTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProjectId = ddlMProject.SelectedValue;
            string TeamName = ddlMTeamName.SelectedValue;
            string Manager = "0";
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
            dtResult = createTeamBA.GetTeamMemberMangerTLUser(createTeam);
            grvViewManager.DataSource = dtResult.Tables[0];
            grvViewManager.DataBind();
            //lsManager.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            //lsManager.DataTextField = "UserName";
            //lsManager.DataValueField = "UserId";
            //lsManager.DataBind();
            lsManager.DataSource = managerName.GetAllEmployee();
            lsManager.DataTextField = "UserName";
            lsManager.DataValueField = "UserId";
            lsManager.DataBind();
            //dtResult.Reset();
            //ds.Tables[0].Clear();
            //grvViewManager
        }
    }
}