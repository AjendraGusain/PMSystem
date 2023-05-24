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
                pnlHideForm.Visible = true;
                DataTable dtGetTeamMember = (DataTable)ViewState["dtTeamUpdate"];
                BindList();
            }
        }

        private void DataBindTeamLeaderViewTeam()
        {
            dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
            ddlMProject.DataSource = dtResult.Tables[2];
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();
            ddlMTeamName.DataSource = dtResult.Tables[2];
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "Id";
            ddlMTeamName.DataBind();
            ddlManager.DataSource = dtResult.Tables[2];
            ddlManager.DataTextField = "ManagerName";
            ddlManager.DataValueField = "UserId";
            ddlManager.DataBind();
            lsTeamLeader.DataSource = managerName.GetAllEmployee();
            lsTeamLeader.DataTextField = "UserName";
            lsTeamLeader.DataValueField = "UserId";
            lsTeamLeader.DataBind();
        }

        private void TeamLeaderAccess(int roleID, int userId)
        {
            createTeam.Role = roleID.ToString();
            createTeam.Employee = userId.ToString();
            dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
            if (dtResult.Tables[1].Rows.Count != 0)
            {
                if (dtResult.Tables[2].Rows.Count > 0)
                {
                    pnlHideForm.Visible = true;
                    ddlManager.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["UserId"]).ToString();
                    ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["ProjectId"]).ToString();
                    ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[2].Rows[0]["TeamId"]).ToString();
                    Session["ProjectId"] = Convert.ToInt32(dtResult.Tables[2].Rows[0]["ProjectId"]).ToString();
                    Session["TeamId"] = Convert.ToInt32(dtResult.Tables[2].Rows[0]["TeamId"]).ToString();
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
            if (Global.Role == "Admin")
            {
                dtResult = createTeamBA.GetTeamName();
                ddlMProject.DataSource = dtResult.Tables[1];
                ddlMProject.DataTextField = "ProjectName";
                ddlMProject.DataValueField = "ProjectId";
                ddlMProject.DataBind();
            }
            else if(Global.Role == "User")
            {
                Global.Role = Session["Role"].ToString();
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                createTeam.Role = "3";
                createTeam.Employee = userId.ToString();
                createTeam.ProjectId = "0";
                createTeam.TeamName = "0";
                dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                ddlMProject.DataSource = dtResult.Tables[2];
                ddlMProject.DataTextField = "ProjectName";
                ddlMProject.DataValueField = "ProjectId";
                ddlMProject.DataBind();
            }
            ddlMProject.Items.Insert(0, new ListItem("-- Select Project Name --", "0"));
            ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
        }

        protected void grvViewTeamLeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTeamLeader")
            {
                btnAddTeamLeader.Text = "Update";
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                createTeam.ParentTeamId = commandArgs[2];
                createTeam.Role = "4";
                createTeam.Manager = createTeam.ParentTeamId;
                dtResult = createTeamBA.GetTeamMember(createTeam);
                DataTable dtupdateTeam = new DataTable();
                dtupdateTeam = dtResult.Tables[0];
                ViewState["dtTeamUpdate"] = dtupdateTeam;
                ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
                List<string> userList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsTeamLeader.DataSource = userList;
                BindEmployeeList();
                foreach (var listItem in userList)
                {
                    ListItem itm = lsTeamLeader.Items.FindByValue(listItem);
                    if (itm != null)
                    {
                        itm.Selected = true;
                    }
                }
                pnlHideForm.Visible = true;
            }
            else if (e.CommandName == "DeleteTeamLeader")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                string teamMmberId= commandArgs[3];
                string tlUserId = commandArgs[2];
                string parrentteamMmberId = commandArgs[4];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;
                dtResult= addTaskDetails.GetTaskDetails();
                Session["Manager"] = parrentteamMmberId;
                Session["TLId"] = "0";
                DataRow[] foundteamLeader = dtResult.Tables[0].Select("UserId = '" + tlUserId + "'");
                if (foundteamLeader.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please reassing the task before removing the user.');location.href = 'AddTeamLeader.aspx';", true);
                }
                else
                {
                    dtResult = createTeamBA.GetTeamDetails(createTeam);
                    DataRow[] foundteamMember = dtResult.Tables[2].Select("ParrentTeamMemberId = '" + teamMmberId + "'");
                    if (foundteamMember.Length != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please remove team members before removing the team leader.');location.href = 'AddTeamLeader.aspx';", true);
                    }
                    else
                    {
                        createTeam.Employee = tlUserId;
                        createTeam.ParentTeamId = teamMmberId;
                        createTeam.IsActive = 0;
                        createTeam.Role = "4";
                        int Respone = createTeamBA.UpdateTeamMember(createTeam);
                        if (Respone > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Team Leader deleted successfully');", true);
                        }
                    }
                }                    
                gridViewList();
            }
        }

        protected void btnAddTeamLeader_Click(object sender, EventArgs e)
        {
            if (btnAddTeamLeader.Text == "Update")
            {
                dtResult = createTeamBA.GetTeamMember(createTeam);
                DataTable dtupdateTeam = new DataTable();
                dtupdateTeam = dtResult.Tables[0];
                List<string> userList = new List<string>();
                int count = 0;
                for (int i = 0; i < dtupdateTeam.Rows.Count; i++)
                {
                    userList.Add(dtupdateTeam.Rows[i]["UserId"].ToString());
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
                pnlHideForm.Visible = false;
                gridViewList();
            }
            if (btnAddTeamLeader.Text == "Add TeamLeader")
            {
                Session["ProjectId"] = ddlMProject.SelectedValue;
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
                BindList();
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
            if (Global.Role == "Admin")
            {
                dtResult = createTeamBA.GetTeamNameById(Convert.ToInt32(ChangedId));
                ddlMTeamName.DataSource = dtResult;
                ddlMTeamName.DataTextField = "TeamName";
                ddlMTeamName.DataValueField = "Id";
                ddlMTeamName.DataBind();
                ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
            }
            else if (Global.Role == "User")
            {
                createTeam.Role = "3";
                createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                DataTable rowsToUpdate = dtResult.Tables[2].AsEnumerable().Where(r => r.Field<int>("ProjectId") == Convert.ToInt32(ChangedId)).CopyToDataTable();
                ddlMTeamName.DataSource = rowsToUpdate;
                ddlMTeamName.DataTextField = "TeamName";
                ddlMTeamName.DataValueField = "TeamId";
                ddlMTeamName.DataBind();
                ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
            }
        }

        protected void ddlMTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedTeamId = ddlMTeamName.SelectedValue;
            string ChangedId = ddlMProject.SelectedValue;
            if (Global.Role == "Admin")
            {
                dtResult = createTeamBA.GetManager(Convert.ToInt32(ChangedTeamId), Convert.ToInt32(ChangedId));
                ddlManager.DataSource = dtResult.Tables[0];
                ddlManager.DataTextField = "UserName";
                ddlManager.DataValueField = "TeamMemberId";
                ddlManager.DataBind();
            }
            else if (Global.Role == "User")
            {
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;
                createTeam.Role = "3";
                createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                ddlManager.DataSource = dtResult.Tables[0];
                ddlManager.DataTextField = "ManagerName";
                ddlManager.DataValueField = "TeamMemberId";
                ddlManager.DataBind();
            }
            
            string ProjectId = ddlMProject.SelectedValue;
            string TeamName = ddlMTeamName.SelectedValue;
            string Manager = "0";
            string TLId = "0";
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
            Session["ProjectId"] = ProjectId;
            Session["TeamId"] = TeamName;
            Session["Manager"] = Manager;
            Session["TLId"] = TLId;
            BindEmployeeList();
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
        }
        private void BindEmployeeList()
        {
            createTeam.Employee = "TL";
            createTeam.ProjectId = Session["ProjectId"].ToString();
            createTeam.TeamName = Session["TeamId"].ToString();
            lsTeamLeader.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            lsTeamLeader.DataTextField = "UserName";
            lsTeamLeader.DataValueField = "UserId";
            lsTeamLeader.DataBind();
        }
    }
}