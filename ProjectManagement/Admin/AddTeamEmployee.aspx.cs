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

        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.Role = Session["Role"].ToString();
                Global.Designation = Session["Designation"].ToString();
                Global.UserId = Convert.ToInt32(Session["UserID"].ToString());
                int projectID = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int teamId = Convert.ToInt32(Request.QueryString["TeamId"]);
                int parrentTeamMemberId = Convert.ToInt32(Request.QueryString["ParrentTeamMemberId"]);
                
                if (projectID != 0 && teamId != 0)
                {

                    string viewTeam = Request.QueryString["ViewTeam"] ?? string.Empty;
                    if (viewTeam == "ViewTeam")
                    {
                        int UserId = 0;
                        if (Global.Role == "Admin")
                        {
                            UserId = Convert.ToInt32(Request.QueryString["TLUserId"]);
                        }
                        else
                        {
                            UserId = Global.UserId;
                        }
                        //projectID = 0;
                        DataBindTeamLeaderViewTeam(UserId);
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

            createTeam.ProjectId = projectID;
            createTeam.TeamName = teamId;
            createTeam.IsActive = 0;
            //createTeam.Role = "2";
            createTeam.Manager = "0";
            dtResult = createTeamBA.CheckTeamTeamMemberExistTask(createTeam);
            if (dtResult.Tables[0].Rows.Count == 0)
            {
                int Respone = createTeamBA.UpdateTeamMember(createTeam);
                if (Respone > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Team Deleted Successfully.');location.href = 'ViewTeam.aspx';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message1", "alert('Team can not be deleted. Task is exists for this team.');location.href = 'ViewTeam.aspx';", true);
            }

        }
        private void DataBindTeamLeaderViewTeam(int userId)
        {
            createTeam.Role = "3";
            createTeam.Employee = userId.ToString();
            dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
            ddlMProject.DataSource = dtResult.Tables[1];
            ddlMProject.DataTextField = "ProjectName";
            ddlMProject.DataValueField = "ProjectId";
            ddlMProject.DataBind();

            ddlMTeamName.DataSource = dtResult.Tables[1];
            ddlMTeamName.DataTextField = "TeamName";
            ddlMTeamName.DataValueField = "TeamId";
            ddlMTeamName.DataBind();
            
            ddlManager.DataSource = dtResult.Tables[1];
            ddlManager.DataTextField = "ManagerName";
            ddlManager.DataValueField = "ManagerID";
            ddlManager.DataBind();

            ddlTeamLeader.DataSource = dtResult.Tables[1];
            ddlTeamLeader.DataTextField = "TLName";
            ddlTeamLeader.DataValueField = "TeamMemberId";
            ddlTeamLeader.DataBind();
            
            lsEmployee.DataSource = managerName.GetAllEmployee();
            lsEmployee.DataTextField = "UserName";
            lsEmployee.DataValueField = "UserId";
            lsEmployee.DataBind();

            lsTester.DataSource = managerName.GetAllEmployee();
            lsTester.DataTextField = "UserName";
            lsTester.DataValueField = "UserId";
            lsTester.DataBind();
        }

        private void TeamLeaderAccess(int roleID, int userId)
        {
            createTeam.Role = roleID.ToString();
            createTeam.Employee = userId.ToString();
            dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
            if (dtResult.Tables[0].Rows.Count == 0)
            {
                if (dtResult.Tables[1].Rows.Count > 0)
                {
                    pnlHideForm.Visible = true;
                    Session["ProjectId"] = Convert.ToInt32(dtResult.Tables[1].Rows[0]["ProjectId"]).ToString();
                    Session["TeamId"] = Convert.ToInt32(dtResult.Tables[1].Rows[0]["TeamId"]).ToString();
                    Session["Manager"] = Convert.ToInt32(dtResult.Tables[1].Rows[0]["ParrentTeamMemberId"]).ToString();
                    Session["TLId"] = Convert.ToInt32(dtResult.Tables[1].Rows[0]["TeamMemberId"]).ToString();
                }
                else
                {
                    lblNotFound.Text = "You Haven't any Team";
                }
            }
            else
            {
                grvViewEmployee.DataSource = dtResult.Tables[0];
                grvViewEmployee.DataBind();
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
            else if (Global.Role == "User")
            {
                if (Global.Designation == "Manager")
                {
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
                else if (Global.Designation == "TeamLeader")
                {
                    createTeam.Role = "4";
                    createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                    dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                    ddlMProject.DataSource = dtResult.Tables[2];
                    ddlMProject.DataTextField = "ProjectName";
                    ddlMProject.DataValueField = "ProjectId";
                    ddlMProject.DataBind();
                }
            }
            
            ddlMProject.Items.Insert(0, new ListItem("-- Select Project Name --", "0"));
            ddlMTeamName.Items.Insert(0, new ListItem("-- Select TeamName --", "0"));
            // ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
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
                string teamMemberID = commandArgs[3];
                string RoleIdEmployee = commandArgs[4];
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;

                dtResult = addTaskDetails.GetTaskDetails();
                DataRow[] foundteamLeader = dtResult.Tables[0].Select("UserId = '" + userId + "' and ProjectId='" + Convert.ToInt32(createTeam.ProjectId) + "' and TeamId='" + Convert.ToInt32(createTeam.TeamName) + "'");
                if (foundteamLeader.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please reassing the task before removing the user.');location.href = 'AddTeamEmployee.aspx';", true);
                }
                else
                {
                    createTeam.Employee = userId;
                    Session["Manager"] = teamMemberID;
                    Session["TLId"] = teamMemberID;
                    createTeam.ParentTeamId = teamMemberID;
                    createTeam.IsActive = 0;
                    createTeam.Role = RoleIdEmployee;
                    int Respone = createTeamBA.UpdateTeamMember(createTeam);
                    if (Respone > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Employee deleted successfully');", true);
                    }
                    gridViewList();
                }
            }
        }


        private void GetTeamDetailInForm(string ProjectId, string TeamId, string teamMemberId, string viewTeam)
        {
            //string viewTeam = Convert.ToInt32(Request.QueryString["ViewTeam"]).ToString();
            BindEmployeeList();
            int userId = 0;
            btnAddEmployee.Text = "Update";
            pnlHideForm.Visible = true;
            createTeam.ProjectId = ProjectId;
            createTeam.TeamName = TeamId;
            createTeam.Manager = teamMemberId;
            dtResult = createTeamBA.GetTeamMember(createTeam);
            DataTable dtupdateTeam = new DataTable();
            dtupdateTeam = dtResult.Tables[0];
            ViewState["dtTeamUpdate"] = dtupdateTeam;
            
            if (viewTeam != "")
            {
                userId = Convert.ToInt32(Request.QueryString["TLUserId"].ToString());
                createTeam.Employee = userId.ToString();
                createTeam.Role = "4";
                createTeam.ProjectId = ProjectId;
                createTeam.TeamName = TeamId;
                Session["Manager"] = teamMemberId;
                Session["ProjectId"] = createTeam.ProjectId;
                Session["TeamId"] = createTeam.TeamName;
            }
            else
            {
                ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
            }
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
                string parrentTeamMemberId = Session["Manager"].ToString();
                //string viewTeam = "ViewTeam";
                var viewTeam = Request.QueryString["ViewTeam"] ?? string.Empty;
                DataTable dtGetTeamMember = (DataTable)ViewState["dtTeamUpdate"];
                createTeam.ProjectId = ddlMProject.SelectedValue;
                createTeam.TeamName = ddlMTeamName.SelectedValue;

                List<string> userList = new List<string>();
                List<string> testerList = new List<string>();
                for (int i = 0; i < dtGetTeamMember.Rows.Count; i++)
                {
                    if (dtGetTeamMember.Rows[i]["RoleId"].ToString() == "2")
                        userList.Add(dtGetTeamMember.Rows[i]["UserId"].ToString());
                    else if (dtGetTeamMember.Rows[i]["RoleId"].ToString() == "5")
                        testerList.Add(dtGetTeamMember.Rows[i]["UserId"].ToString());
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
                            if (viewTeam != "")
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
                                    if (viewTeam != "")
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
                            createTeam.Employee = item;
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            if (viewTeam != "")
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
                            if (viewTeam != "")
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
                                    if (Global.Role == "User" && viewTeam == "")
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
                            createTeam.Employee = item;
                            createTeam.ProjectId = ddlMProject.SelectedValue;
                            createTeam.TeamName = ddlMTeamName.SelectedValue;
                            if (Global.Role == "User" && viewTeam == "")
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "updateallteam", "alert('Updated Successfully');location.href = 'ViewTeam.aspx';", true);
                }
                else
                {
                    pnlHideForm.Visible = false;
                    gridViewList();
                }
            }
            if (btnAddEmployee.Text == "Add Employee")
            {
                //string role = Session["Role"].ToString();
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
                if (Global.Designation == "Manager")
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
                else if (Global.Designation == "TeamLeader")
                {
                    createTeam.Role = "4";
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
                if (Global.Designation == "Manager")
                {
                    createTeam.ProjectId = ddlMProject.SelectedValue;
                    createTeam.TeamName = ddlMTeamName.SelectedValue;
                    createTeam.Role = "3";
                    //int userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                    dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                    ddlManager.DataSource = dtResult.Tables[0];
                    ddlManager.DataTextField = "ManagerName";
                    ddlManager.DataValueField = "TeamMemberId";
                    ddlManager.DataBind();
                }
                else if (Global.Designation == "TeamLeader")
                {
                    createTeam.ProjectId = ddlMProject.SelectedValue;
                    createTeam.TeamName = ddlMTeamName.SelectedValue;
                    createTeam.Role = "4";
                    //int userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                    dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                    ddlManager.DataSource = dtResult.Tables[2];
                    ddlManager.DataTextField = "TLName";
                    ddlManager.DataValueField = "TeamMemberId";
                    ddlManager.DataBind();
                }
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
            gridViewList();
        }

        private void gridViewList()
        {
            createTeam.ProjectId = Session["ProjectId"].ToString();
            createTeam.TeamName = Session["TeamId"].ToString();
            createTeam.Manager = Session["Manager"].ToString();
            createTeam.TeamLeader = Session["TLId"].ToString();
            dtResult = createTeamBA.GetTeamMemberEmployee(createTeam);
            grvViewEmployee.DataSource = dtResult.Tables[2];
            grvViewEmployee.DataBind();

        }

        private void BindEmployeeList()
        {
            createTeam.Employee = "";
            createTeam.ProjectId = Session["ProjectId"].ToString();
            createTeam.TeamName = Session["TeamId"].ToString();
            dtResult = createTeamBA.GetAllEmployeTeamMemberId(createTeam);
            lsEmployee.DataSource = dtResult;
            lsEmployee.DataTextField = "UserName";
            lsEmployee.DataValueField = "UserId";
            lsEmployee.DataBind();

            lsTester.DataSource = dtResult;
            lsTester.DataTextField = "UserName";
            lsTester.DataValueField = "UserId";
            lsTester.DataBind();
        }

        protected void ddlManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChangedTeamId = ddlManager.SelectedValue;
            if (Global.Role == "Admin")
            {
                dtResult= createTeamBA.GetTeamLeader(Convert.ToInt32(ChangedTeamId));
                ddlTeamLeader.DataSource = dtResult.Tables[0];
                ddlTeamLeader.DataTextField = "UserName";
                ddlTeamLeader.DataValueField = "TeamMemberId";
                ddlTeamLeader.DataBind();
                ddlTeamLeader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
            }
            if (Global.Role == "User")
            {
                if (Global.Designation == "Manager")
                {
                    createTeam.ProjectId = ddlMProject.SelectedValue;
                    createTeam.TeamName = ddlMTeamName.SelectedValue;
                    createTeam.Role = "3";
                    //int userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                    dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                    ddlTeamLeader.DataSource = dtResult.Tables[2];
                    ddlTeamLeader.DataTextField = "TLName";
                    ddlTeamLeader.DataValueField = "TeamMemberId";
                    ddlTeamLeader.DataBind();
                    ddlTeamLeader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
                }
                if (Global.Designation == "TeamLeader")
                {
                    createTeam.ProjectId = ddlMProject.SelectedValue;
                    createTeam.TeamName = ddlMTeamName.SelectedValue;
                    createTeam.Role = "4";
                    //int userId = Convert.ToInt32(Session["UserID"].ToString());
                    createTeam.Employee = Convert.ToInt32(Session["UserID"].ToString()).ToString();
                    dtResult = createTeamBA.GetTeamLeaderTeam(createTeam);
                    DataTable rowsToUpdate = dtResult.Tables[0].AsEnumerable().Where(r => r.Field<int>("ProjectId") == Convert.ToInt32(createTeam.ProjectId)
                    && r.Field<int>("TeamId") == Convert.ToInt32(createTeam.TeamName)).CopyToDataTable();
                    ddlTeamLeader.DataSource = rowsToUpdate;
                    ddlTeamLeader.DataTextField = "ManagerName";
                    ddlTeamLeader.DataValueField = "TeamMemberId";
                    ddlTeamLeader.DataBind();
                    ddlTeamLeader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
                   
                }
                

            }
            BindEmployeeList();
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
            string TLId = ddlTeamLeader.SelectedValue;
            Session["ProjectId"] = ProjectId;
            Session["TeamId"] = TeamName;
            Session["Manager"] = Manager;
            Session["TLId"] = TLId;

            gridViewList();
            
        }

        protected void grvViewEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
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