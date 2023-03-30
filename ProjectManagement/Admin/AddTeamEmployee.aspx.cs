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
                BindList();
            }
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
                btnAddEmployee.Text = "Update";
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProjectId = commandArgs[0];
                string TeamId = commandArgs[1];
                string teamMemberId= commandArgs[2];
                Session["ProjectId"] = ProjectId;
                Session["TeamId"] = TeamId;
                Session["Manager"] = teamMemberId;
                //createTeam.Role = "2";
                createTeam.Manager = teamMemberId;
                dtResult = createTeamBA.GetTeamMember(Convert.ToInt32(ProjectId), Convert.ToInt32(TeamId), createTeam);
                //BindList();
                ddlMProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                ddlMTeamName.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["TeamId"]).ToString();
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


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (btnAddEmployee.Text == "Update")
            {
                int ProjectId = Convert.ToInt32(Session["ProjectId"]);
                int TeamId = Convert.ToInt32(Session["TeamId"]);
                //createTeam.Role = "2";
                createTeam.Manager = Session["Manager"].ToString();
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
                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;
                        createTeam.IsActive = 0;
                        createTeam.Role = "2";
                        createTeamBA.UpdateTeamMember(createTeam);
                    }

                }
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
                        createTeam.ParentTeamId = ddlTeamLeader.SelectedValue;
                        createTeam.IsActive = 0;
                        createTeam.Role = "5";
                        createTeamBA.UpdateTeamMember(createTeam);
                    }

                }
                gridViewList();
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
            lsEmployee.DataSource = managerName.GetAllEmployee();
            lsEmployee.DataTextField = "UserName";
            lsEmployee.DataValueField = "UserId";
            lsEmployee.DataBind();

            lsTester.DataSource = managerName.GetAllEmployee();
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