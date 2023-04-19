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

namespace ProjectManagement.Admin
{
    public partial class AddTeamLeader : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.Role = Session["Role"].ToString();
                //Global.RoleId = Convert.ToInt32(Session["RoleId"].ToString());
                int userId = Convert.ToInt32(Session["UserID"].ToString());

                if (Global.Role == "User")
                {
                    TeamLeaderAccess(Global.RoleId, userId);
                    
                    ddlMProject.Enabled = false;
                    ddlMTeamName.Enabled = false;
                    ddlManager.Enabled = false;
                    //ddlTeamLeader.Enabled = false;
                    DataBindTeamLeaderViewTeam();

                }
                else
                {
                    BindList();
                    pnlHideForm.Visible = true;
                    //pnlHideGrid.Visible = true;
                }
            }
        }

        

        private void DataBindTeamLeaderViewTeam()
        {
            dtResult= createTeamBA.GetTeamName();
            ddlMProject.DataSource = dtResult.Tables[1];

            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();


            ddlMTeamName.DataSource = dtResult.Tables[0];

            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "Id";
            ddlMTeamName.DataBind();


            ddlManager.DataSource = managerName.GetAllEmployee();

            ddlManager.DataTextField = "UserName";
            ddlManager.DataValueField = "UserId";
            ddlManager.DataBind();

            //lsTeamLeader.DataSource = userList;
            lsTeamLeader.DataSource = managerName.GetAllEmployee();
            lsTeamLeader.DataTextField = "UserName";
            lsTeamLeader.DataValueField = "UserId";
            lsTeamLeader.DataBind();

            //ddlTeamLeader.DataSource = managerName.GetAllEmployee();


            //ddlTeamLeader.DataTextField = "UserName";
            //ddlTeamLeader.DataValueField = "UserId";
            //ddlTeamLeader.DataBind();
        }

        private void TeamLeaderAccess(int roleID, int userId)
        {
            createTeam.Role = roleID.ToString();
            createTeam.Employee = userId.ToString();
            dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
            if (dtResult.Tables[1].Rows.Count == 0)
            {
                
                if (dtResult.Tables[2].Rows.Count > 0)
                {
                    pnlHideForm.Visible = true;
                    ddlManager.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["UserId"]).ToString();
                    ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["ProjectId"]).ToString();
                    ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["TeamId"]).ToString();
                    Session["ProjectId"] = Convert.ToInt32(dtResult.Tables[2].Rows[0]["ProjectId"]).ToString();
                    Session["TeamId"] = Convert.ToInt32(dtResult.Tables[2].Rows[0]["TeamId"]).ToString();
                    Session["Manager"] = Convert.ToInt32(dtResult.Tables[2].Rows[0]["TeamMemberId"]).ToString();
                    Session["TLId"] = "0";
                    
                }
                else
                {
                    lblNotFound.Text = "You Haven't any Team";
                }

            }
            else
            {
                grvViewTeamLeader.DataSource = dtResult.Tables[1];
                grvViewTeamLeader.DataBind();
            }
        }

        private void BindList()
        {
            dtResult = createTeamBA.GetTeamName();
            ddlMProject.DataSource = dtResult.Tables[1];
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();
            ddlMProject.Items.Insert(0, new ListItem("-- Select Project Name --", "0"));
            ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));

        }

        protected void grvViewTeamLeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTeamLeader")
            {
                btnAddTeamLeader.Text = "Update";
               
                int userId = 0;
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string parrentTeamMemberId = commandArgs[2];
                string role = Session["Role"].ToString();
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                Session["Manager"] = parrentTeamMemberId;
                createTeam.Role = "4";
                createTeam.Manager = parrentTeamMemberId;
                DataSet dsResultTeamLeader = new DataSet();
                DataSet dsResultTeamLeaderNew = new DataSet();
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);

                if (Global.Role == "Admin")
                {
                    dsResultTeamLeader = dtResult;
                    //dsResultTeamLeader = dtResult;
                    ddlMProject.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["ProjectId"]).ToString();
                    ddlMTeamName.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["TeamId"]).ToString();
                }
                else if (Global.Role == "User")
                {
                    pnlHideForm.Visible = true;
                    userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Employee = userId.ToString();
                    createTeam.Role = Global.RoleId.ToString();
                    dsResultTeamLeader = createTeamBA.GetTeamLeaderTeam(createTeam);
                    ddlManager.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[1].Rows[0]["ManagerID"]).ToString();
                    ddlMProject.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[1].Rows[0]["ProjectId"]).ToString();
                    ddlMTeamName.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[1].Rows[0]["TeamId"]).ToString();
                    Session["TLId"] = "0";
                    dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                    ViewState["GetTeamMember"] = dtResult.Tables[0];

                }
               


                List<string> userList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsTeamLeader.DataSource = userList;
                lsTeamLeader.DataSource = managerName.GetAllEmployee();
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
                dtResult.Reset();
            }


            else if (e.CommandName == "DeleteTeamLeader")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                string teamMemberId= commandArgs[3];
                string tlUserId = commandArgs[2];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;
                //int ProjectID3 = Convert.ToInt32(e.CommandArgument);
               dtResult= addTaskDetails.GetTaskDetails();
                Session["Manager"] = teamMemberId;
                Session["TLId"] = "0";
                DataRow[] foundteamLeader = dtResult.Tables[0].Select("UserId = '" + tlUserId + "'");
                if (foundteamLeader.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please reassing the task before removing the user.');location.href = 'AddTeamLeader.aspx';", true);
                }
                else
                {
                    dtResult = createTeamBA.GetTeamDetails(createTeam);
                    DataRow[] foundteamMember = dtResult.Tables[2].Select("ParrentTeamMemberId = '" + teamMemberId + "'");
                    if (foundteamMember.Length != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please remove team members before removing the team leader.');location.href = 'AddTeamLeader.aspx';", true);
                    }
                    else
                    {
                        createTeam.Employee = tlUserId;
                        

                        createTeam.ParentTeamId = teamMemberId;
                        createTeam.IsActive = 0;
                        createTeam.Role = "4";
                        int Respone = createTeamBA.UpdateTeamMember(createTeam);
                        if (Respone > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Team Leader deleted successfully');", true);
                        }
                    }
                }                    
                //int Respone = createTeamBA.DeleteTeamMember(Convert.ToInt32(userId), createTeam);
                //if (Respone > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                //}
                gridViewList();
            }
        }

        protected void btnAddTeamLeader_Click(object sender, EventArgs e)
        {
            if (btnAddTeamLeader.Text == "Update")
            {
                int ProjectId = Convert.ToInt32(Session["ProjectId"]);
                int TeamId = Convert.ToInt32(Session["TeamId"]);
                createTeam.Manager = Session["Manager"].ToString();
                string role = Session["Role"].ToString();
                //DataTable dtGetTeamMember = ViewState["GetTeamMember"] as DataTable;
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;
                List<string> userList = new List<string>();
                int count = 0;
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsTeamLeader.DataSource = userList;
                foreach (var item in userList)
                {
                    count = 0;
                    int countFinal = 0;
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
                                if (Global.Role == "User")
                                    createTeam.ParentTeamId = Session["Manager"].ToString();
                                else
                                    createTeam.ParentTeamId = ddlManager.SelectedValue;
                                createTeam.IsActive = 1;
                                createTeam.Role = "4";
                                createTeamBA.InsertTeamMember(createTeam);
                            }
                        }
                        countFinal += count;
                        count = 0;
                    }
                    if (countFinal == 0)
                    {
                        createTeam.Manager = item;
                        createTeam.Employee = item;
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        if (Global.Role == "User")
                            createTeam.ParentTeamId = Session["Manager"].ToString();
                        else
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
                //string role = Session["Role"].ToString();
                foreach (ListItem item in lsTeamLeader.Items)
                {
                    if (item.Selected)
                    {
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;

                       
                        createTeam.Manager = item.Value;

                        if (Global.Role=="User")
                            createTeam.ParentTeamId = Session["Manager"].ToString();
                        else
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