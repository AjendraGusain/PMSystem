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
    public partial class AddTeamEmployee : System.Web.UI.Page
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        int respone = 0;
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int roleID = Convert.ToInt32(Session["RoleId"].ToString());
                int userId= Convert.ToInt32(Session["UserID"].ToString());

                int projectID = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int teamId = Convert.ToInt32(Request.QueryString["TeamId"]);
                int parrentTeamMemberId = Convert.ToInt32(Request.QueryString["ParrentTeamMemberId"]);
                

                if (roleID == 4)
                {
                    TeamLeaderAccess(roleID, userId);
                    DataBindTeamLeaderViewTeam();
                    ddlMProject.Enabled = false;
                    ddlMTeamName.Enabled = false;
                    ddlManager.Enabled = false;
                    ddlTeamLeader.Enabled = false;

                }
                else if (projectID != 0 && teamId != 0)
                {
                    string viewTeam = Request.QueryString["ViewTeam"].ToString();
                    //var ProjectId = Session["ProjectId"].ToString();
                    //ProjectId ??
                    //var TeamId = Session["TeamId"].ToString();
                    //string parrentTeamMemberId = Session["parrentTeamMemberId"].ToString();
                    if (viewTeam == "ViewTeam")
                    {
                        DataBindTeamLeaderViewTeam();
                        GetTeamDetailInForm(projectID.ToString(), teamId.ToString(), parrentTeamMemberId.ToString(), viewTeam);
                    }
                    else
                    {
                        DeleteAllTeam(projectID.ToString(), teamId.ToString(), parrentTeamMemberId.ToString());
                    }
                }
                else
                {
                    pnlHideForm.Visible = true;
                    pnlHideGrid.Visible = true;
                    BindList();
                }
                
            }
        }

        private void DeleteAllTeam(string projectID, string teamId, string parrentTeamMemberId)
        {
            
            createTeam.ProjectId=projectID;
            createTeam.TeamName=teamId;
            //int ProjectID3 = Convert.ToInt32(e.CommandArgument);
            //createTeam.ParentTeamId = teamMemberID;
            createTeam.IsActive = 0;
            //createTeam.Role = "2";
            createTeam.Manager = "0";
            int Respone = createTeamBA.UpdateTeamMember(createTeam);
            if (Respone > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                Response.Redirect("ViewTeam.aspx?");
            }
        }

        private void DataBindTeamLeaderViewTeam()
        {
            ddlMProject.DataSource = createTeamBA.GetTeamName();
            
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();


            ddlMTeamName.DataSource = createTeamBA.GetTeamName();
            
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "Id";
            ddlMTeamName.DataBind();


            ddlManager.DataSource = managerName.GetAllEmployee();
            
            ddlManager.DataTextField = "UserName";
            ddlManager.DataValueField = "UserId";
            ddlManager.DataBind();


            ddlTeamLeader.DataSource = managerName.GetAllEmployee();
            

            ddlTeamLeader.DataTextField = "UserName";
            ddlTeamLeader.DataValueField = "UserId";
            ddlTeamLeader.DataBind();
        }

        private void TeamLeaderAccess(int roleID, int userId)
        {
            createTeam.Role = roleID.ToString();
            createTeam.Employee = userId.ToString();
            DataSet ds = createTeamBA.GetTeamLeaderTeam(createTeam);
            grvViewEmployee.DataSource = ds.Tables[0];
            grvViewEmployee.DataBind();
        }

        private void BindList()
        {
            ddlMProject.DataSource = createTeamBA.GetTeamName();
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();
            ddlMProject.Items.Insert(0, new ListItem("-- Select Project --", "0"));
        }

       

      

        protected void grvViewEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string teamMemberId = commandArgs[2];
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                Session["Manager"] = teamMemberId;
                //createTeam.Role = "2";
                createTeam.Manager = teamMemberId;
                string viewTeam = "";
                GetTeamDetailInForm(ProjectId, TeamId, teamMemberId, viewTeam);
            }
            else if (e.CommandName == "DeleteEmployee")
            {
                
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                createTeam.ProjectId = commandArgs[0];
                createTeam.TeamName = commandArgs[1];
                string userId = commandArgs[2];
                string teamMemberID= commandArgs[3];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;

                dtResult = addTaskDetails.GetTaskDetails();
                DataRow[] foundteamLeader = dtResult.Tables[0].Select("UserId = '" + userId + "'");
                if (foundteamLeader.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please reassing the task before removing the user.');location.href = 'AddTeamEmployee.aspx';", true);
                }
                else
                {
                    createTeam.Manager = userId;
                    createTeam.ParentTeamId = teamMemberID;
                    createTeam.IsActive = 0;
                    createTeam.Role = "2";
                    int Respone = createTeamBA.UpdateTeamMember(createTeam);
                    if (Respone > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Employee deleted successfully');", true);
                    }
                    //int Respone = createTeamBA.DeleteTeamMember(Convert.ToInt32(userId), createTeam);
                    //if (Respone > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    //}
                    gridViewList();
                }
            }

            
        }



        private void GetTeamDetailInForm(string ProjectId, string TeamId, string teamMemberId, string viewTeam)
        {
            //string viewTeam = Convert.ToInt32(Request.QueryString["ViewTeam"]).ToString();
            int userId = 0;
            btnAddEmployee.Text = "Update";
            pnlHideForm.Visible = true;
            createTeam.Manager = teamMemberId;
            DataSet dsResultTeamLeader = new DataSet();
            int roleID = Convert.ToInt32(Session["RoleId"].ToString());
            dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
            Session["ViewTeam"] = viewTeam;

            if (roleID == 1 && viewTeam == "")
            {
                //dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                dsResultTeamLeader = dtResult;
            }
            else if (roleID == 4 || viewTeam!= "")
            {
                if (viewTeam == "")
                {
                    userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Role = roleID.ToString();
                }
                else
                {
                    userId= Convert.ToInt32(Request.QueryString["TLUserId"].ToString());
                    createTeam.Employee = userId.ToString();
                    createTeam.Role = "4";
                    createTeam.ProjectId = ProjectId;
                    createTeam.TeamName = TeamId;
                    Session["Manager"] = teamMemberId;
                    Session["ProjectId"] = createTeam.ProjectId;
                    Session["TeamId"] = createTeam.TeamName;
                    

                }
                dsResultTeamLeader = createTeamBA.GetTeamLeaderTeam(createTeam);
                ddlManager.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["TLUserId"]).ToString();
                ddlTeamLeader.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["ManagerID"]).ToString();
                Session["TLId"] = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["ParrentTeamMemberId"]).ToString();
                //ddlTeamLeader.SelectedValue = Session["TLId"].ToString();
            }
            //else if()
            //{

            //}

            ddlMProject.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["ProjectId"]).ToString();
            ddlMTeamName.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["TeamId"]).ToString();
            //ddlManager.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["TLUserId"]).ToString();
            //ddlTeamLeader.SelectedValue = Convert.ToInt32(dsResultTeamLeader.Tables[0].Rows[0]["ManagerID"]).ToString();

            List<string> userList = new List<string>();
            List<string> testerList = new List<string>();
            for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
            {
                if (dtResult.Tables[0].Rows[i]["RoleId"].ToString() == "2")
                    userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                else if (dtResult.Tables[0].Rows[i]["RoleId"].ToString() == "5")
                    testerList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
            }
            lsEmployee.DataSource = userList;
            lsTester.DataSource = testerList;
            // ddlManager.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0][""]).ToString();
            //ddlTeamLeader.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
            lsEmployee.DataSource = managerName.GetAllEmployee();
            lsEmployee.DataTextField = "UserName";
            lsEmployee.DataValueField = "UserId";
            lsEmployee.DataBind();

            lsTester.DataSource = managerName.GetAllEmployee();
            lsTester.DataTextField = "UserName";
            lsTester.DataValueField = "UserId";
            lsTester.DataBind();

            foreach (var listItem in userList)
            {
                ListItem itm = lsEmployee.Items.FindByValue(listItem);
                if (itm != null)
                {
                    itm.Selected = true;
                }
            }
            foreach (var listItem in testerList)
            {
                ListItem itm = lsTester.Items.FindByValue(listItem);
                if (itm != null)
                {
                    itm.Selected = true;
                }
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (btnAddEmployee.Text == "Update")
            {
                int roleID = Convert.ToInt32(Session["RoleId"].ToString());
                int ProjectId = Convert.ToInt32(Session["ProjectId"]);
                int TeamId = Convert.ToInt32(Session["TeamId"]);
                string viewTeam = Session["ViewTeam"].ToString();
                //createTeam.Role = "2";
                string parrentTeamMemberId= Session["Manager"].ToString();
                createTeam.Manager = parrentTeamMemberId;
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;

                List<string> userList = new List<string>();
                List<string> testerList = new List<string>();
                for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
                {
                    if (dtResult.Tables[0].Rows[i]["RoleId"].ToString() == "2")
                        userList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                    else if (dtResult.Tables[0].Rows[i]["RoleId"].ToString() == "5")
                        testerList.Add(dtResult.Tables[0].Rows[i]["UserId"].ToString());
                }
                lsEmployee.DataSource = userList;
                lsTester.DataSource = testerList;
                int count = 0;
                if (userList.Count == 0)
                {
                    foreach (ListItem item in lsEmployee.Items)
                    {
                        if (item.Selected)
                        {
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            createTeam.Manager = item.Value;
                            if (roleID == 4 && viewTeam=="")
                                createTeam.ParentTeamId = Session["TLId"].ToString();
                            else if(viewTeam!="")
                            {
                                createTeam.ParentTeamId = parrentTeamMemberId;
                            }
                            else
                                createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                            createTeam.IsActive = 1;
                            createTeam.Role = "2";
                            createTeamBA.InsertTeamMember(createTeam);
                        }
                    }
                }
                else
                {
                    foreach (var item in userList)
                    {
                        count = 0;
                        int countFinal = 0;
                        foreach (ListItem listItem1 in lsEmployee.Items)
                        {
                            if (listItem1.Selected)
                            {
                                createTeam.Manager = listItem1.Value.ToString();
                                if (item == createTeam.Manager)
                                {
                                    count++;
                                }
                                if (count == 0)
                                {
                                    createTeam.Manager = listItem1.Value.ToString();
                                    createTeam.ProjectId = ddlMProject.SelectedValue;
                                    createTeam.TeamName = ddlMTeamName.SelectedValue;
                                    if (roleID == 4 && viewTeam == "")
                                        createTeam.ParentTeamId = Session["TLId"].ToString();
                                    else if (viewTeam != "")
                                    {
                                        createTeam.ParentTeamId = parrentTeamMemberId;
                                    }
                                    else
                                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                                    createTeam.IsActive = 1;
                                    createTeam.Role = "2";
                                    createTeamBA.InsertTeamMember(createTeam);
                                }
                            }
                            countFinal += count;
                            count = 0;
                        }
                        if (countFinal == 0)
                        {
                            createTeam.Manager = item;
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            if (roleID == 4 && viewTeam == "")
                                createTeam.ParentTeamId = Session["TLId"].ToString();
                            else if (viewTeam != "")
                            {
                                createTeam.ParentTeamId = parrentTeamMemberId;
                            }
                            else
                                createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                            createTeam.IsActive = 0;
                            createTeam.Role = "2";
                            createTeamBA.UpdateTeamMember(createTeam);
                        }

                    }
                }
                if (testerList.Count == 0)
                {
                    foreach (ListItem item in lsTester.Items)
                    {
                        if (item.Selected)
                        {
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            createTeam.Manager = item.Value;
                            if (roleID == 4 && viewTeam == "")
                                createTeam.ParentTeamId = Session["TLId"].ToString();
                            else if (viewTeam != "")
                            {
                                createTeam.ParentTeamId = parrentTeamMemberId;
                            }
                            else
                                createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                            createTeam.IsActive = 1;
                            createTeam.Role = "5";
                            createTeamBA.InsertTeamMember(createTeam);
                        }
                    }
                }
                else
                {
                    foreach (var item in testerList)
                    {
                        count = 0;
                        int countFinal = 0;
                        foreach (ListItem listItem in lsTester.Items)
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
                                    if (roleID == 4 && viewTeam == "")
                                        createTeam.ParentTeamId = Session["TLId"].ToString();
                                    else if (viewTeam != "")
                                    {
                                        createTeam.ParentTeamId = parrentTeamMemberId;
                                    }
                                    else
                                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                                    createTeam.IsActive = 1;
                                    createTeam.Role = "5";
                                    createTeamBA.InsertTeamMember(createTeam);
                                }
                            }
                            countFinal += count;
                            count = 0;
                        }
                        if (countFinal == 0)
                        {
                            createTeam.Manager = item;
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            if (roleID == 4 && viewTeam == "")
                                createTeam.ParentTeamId = Session["TLId"].ToString();
                            else if (viewTeam != "")
                            {
                                createTeam.ParentTeamId = parrentTeamMemberId;
                            }
                            else
                                createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;

                            createTeam.IsActive = 0;
                            createTeam.Role = "5";
                            createTeamBA.UpdateTeamMember(createTeam);
                        }

                    }
                }
                if (viewTeam != "")
                {
                    Response.Redirect("ViewTeam.aspx?");
                }
                else
                {
                    //pnlHideForm.Visible = false;
                    gridViewList();
                }
            }
            if (btnAddEmployee.Text == "Add Employee")
            {
                foreach (ListItem item in lsEmployee.Items)
                {
                    if (item.Selected)
                    {
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.Manager = item.Value;
                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;
                        createTeam.IsActive = 1;
                        createTeam.Role = "2";
                        createTeamBA.InsertTeamMember(createTeam);
                    }
                }
                foreach (ListItem item in lsTester.Items)
                {
                    if (item.Selected)
                    {
                        createTeam.ProjectId = ddlMProject.SelectedValue;
                        createTeam.TeamName = ddlMTeamName.SelectedValue;
                        createTeam.Manager = item.Value;
                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;
                        createTeam.IsActive = 1;
                        createTeam.Role = "5";
                        createTeamBA.InsertTeamMember(createTeam);
                    }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "alert('Record Inserted successfully');", true);
                gridViewList();
            }
            BindList();
            btnAddEmployee.Text = "Add Employee";
        }

        protected void grvViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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

        protected void ddlMTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedTeamId = ddlMTeamName.SelectedValue;
            string ChangedId = ddlMProject.SelectedValue;
            ddlManager.DataSource = createTeamBA.GetManager(Convert.ToInt32(ChangedTeamId), Convert.ToInt32(ChangedId));
            ddlManager.DataTextField = "UserName";
            ddlManager.DataValueField = "TeamMemberId";
            ddlManager.DataBind();
            ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
            createTeam.ProjectId = ddlMProject.SelectedValue;
            createTeam.TeamName = ddlMTeamName.SelectedValue;
            string Manager = "0";
            string TLId = "0";
            Session["ProjectId"] = createTeam.ProjectId;
            Session["TeamId"] = createTeam.TeamName;
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
            DataSet ds = createTeamBA.GetTeamMemberEmployee(createTeam);
            grvViewEmployee.DataSource = ds.Tables[2];
            grvViewEmployee.DataBind();
            lsEmployee.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            lsEmployee.DataTextField = "UserName";
            lsEmployee.DataValueField = "UserId";
            lsEmployee.DataBind();

            lsTester.DataSource = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            lsTester.DataTextField = "UserName";
            lsTester.DataValueField = "UserId";
            lsTester.DataBind();
            ds.Tables[0].Clear();
            //grvViewManager
        }

        protected void ddlManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedTeamId = ddlManager.SelectedValue;
            //string ChangedId = ddlMProject.SelectedValue;
            ddlTeamLeader.DataSource = createTeamBA.GetTeamLeader(Convert.ToInt32(ChangedTeamId));
            ddlTeamLeader.DataTextField = "UserName";
            ddlTeamLeader.DataValueField = "TeamMemberId";
            ddlTeamLeader.DataBind();
            ddlTeamLeader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
            //Session["ProjectId"] = ddlManager.SelectedValue;
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

        protected void ddlTeamLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProjectId = ddlMProject.SelectedValue;
            string TeamName = ddlMTeamName.SelectedValue;
            string Manager = ddlManager.SelectedValue;
            string TLId =ddlTeamLeader.SelectedValue;
            Session["ProjectId"] = ProjectId;
            Session["TeamId"] = TeamName;
            Session["Manager"] = Manager;
            Session["TLId"] = TLId;

            gridViewList();
        }

        protected void grvViewEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //DataSet ds= managerName.GetAllEmployee();

            //int count = ds.Tables[0].Rows.Count;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 10 == 0)
                {
                    e.Row.Cells[6].Attributes.Add("rowspan", "10");
                }
                else
                {
                    e.Row.Cells[6].Visible = false;
                }
            }
        }
    }
}