using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;

namespace ProjectManagement
{
    public partial class Home1 : System.Web.UI.MasterPage
    {
        ITaskBusinessLogic addTaskDetails = new TaskBusinessLogic(new TaskDataAccess());
        EmployeeBusinessLogic managerName = new EmployeeBusinessLogic();
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        DataSet dtResult = new DataSet();
        StringBuilder builder = new StringBuilder();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblUserLogged.Text= "Welcome " + Session["User"].ToString();
                var selectedRole = Request.QueryString["User"] ?? string.Empty;
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                string Designation = Session["Designation"].ToString();
                if (selectedRole == "")
                {
                    if (Global.RoleIdSession == 4)
                        Designation = "Manager";
                    else if (Global.RoleIdSession == 3)
                        Designation = "TeamLeader";
                    else if (Global.RoleIdSession == 1)
                        Designation = "Admin";
                }
                else
                {
                    if (selectedRole == "User")
                        Designation = "User";
                    else if (selectedRole == "Manager")
                        Designation = "Manager";
                    else if (selectedRole == "TeamLeader")
                        Designation = "TeamLeader";
                    Session["Designation"] = Designation;
                    Session["SelectedRole"] = selectedRole;
                }
                lblSelectedDesignation.Text = Designation;
                if (Global.Role == "Admin")//For Admin 
                {
                    pnlAdmin.Visible = true;
                    pnlUser.Visible = false;
                    pnlTeamLeaderAccess.Visible = false;
                    pnlManagerTeamAccess.Visible = false;
                    pnlAddTask.Visible = true;
                    builder.Append("<script language=JavaScript> HidePopuphideSwitchUser(); </script>\n");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopuphideSwitchUser", builder.ToString());
                    builder.Append("<script language=JavaScript> HidePopupApproval(); </script>\n");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
                    builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalTL", builder.ToString());
                    builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalUser", builder.ToString());
                }
                else if (Global.Role == "User")//For User 
                {
                    if(Designation=="Manager")
                    {
                        pnlAdmin.Visible = false;
                        pnlTeamLeaderAccess.Visible = false;
                        pnlManagerTeamAccess.Visible = true;
                        pnlUser.Visible = true;
                        pnlAddTask.Visible = true;
                        pnlUser.Visible = false;
                        CheckSwitchUser(selectedRole, Designation);
                    }
                    else if (Designation == "TeamLeader")
                    {
                        Global.RoleId = 4;
                        pnlAdmin.Visible = false;
                        pnlManagerTeamAccess.Visible = false;
                        pnlUser.Visible = true;
                        pnlTeamLeaderAccess.Visible = true;
                        pnlAddTask.Visible = true;
                        CheckSwitchUser(selectedRole, Designation);
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                        pnlTeamLeaderAccess.Visible = false;
                        pnlManagerTeamAccess.Visible = false;
                        pnlAddTask.Visible = false;
                        pnlUser.Visible = true;
                        Designation = "User";
                        CheckSwitchUser(selectedRole, Designation);
                    }
                }
            }
        }

        private void CheckSwitchUser(string selectedRole, string Designation)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            createTeam.Employee = userId.ToString();
            dtResult = createTeamBA.GetRolesInTeam(createTeam);
            builder.Append("<script language=JavaScript> HidePopupApproval(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
            builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
            builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
            if (dtResult.Tables[0].Rows.Count > 1)
            {
                for (int i = 0; i < dtResult.Tables[0].Rows.Count - 1; i++)
                {
                    if (dtResult.Tables[0].Rows.Count == 3)
                    {
                        if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 2)
                        {
                            if (selectedRole == "User")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalUser", builder.ToString());
                            }
                            else
                            {
                                if (Designation == "Manager")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                                else if (Designation == "TeamLeader")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                            }
                        }
                        else if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 3)
                        {
                            if (selectedRole == "Manager")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApproval(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
                            }
                            else
                            {
                                if (Designation == "Manager")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                                else if (Designation == "TeamLeader")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                            }
                        }
                        else if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 4)
                        {
                            if (selectedRole == "TeamLeader")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalTL", builder.ToString());
                            }
                            else
                            {
                                if (Designation == "Manager")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                                else if (Designation == "TeamLeader")
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                            }
                        }
                    }
                    else if (dtResult.Tables[0].Rows.Count == 2)
                    {
                        if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 2)
                        {
                            if (selectedRole == "User")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalUser", builder.ToString());
                                if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 3)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                            }
                            if (selectedRole == "Manager")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalUser", builder.ToString());
                                if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 3)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                            }
                            if (selectedRole == "TeamLeader")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalTL", builder.ToString());
                                if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 3)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                }
                            }
                            else
                            {
                                if (selectedRole == "")
                                {
                                    if (Designation == "Manager")
                                    {
                                        builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    }
                                    else if (Designation == "TeamLeader")
                                    {
                                        builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                    }
                                    else if (Designation == "User")
                                    {
                                        if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 3)
                                        {
                                            builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                        }
                                        else if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                        {
                                            builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                        }
                                    }
                                }
                            }
                        }
                        else if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 3)
                        {
                            if (selectedRole == "Manager")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApproval(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
                                if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                }
                                else
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                }
                            }
                            if (selectedRole == "TeamLeader")
                            {
                                builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalTL", builder.ToString());
                                if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                }
                                else
                                {
                                    builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                                }
                            }
                            else
                            {
                                if (selectedRole == "")
                                {
                                    if (Designation == "TeamLeader")
                                    {
                                        if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                        {
                                            builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                                        }
                                    }
                                    if (Designation == "Manager")
                                    {
                                        if (Convert.ToInt32(dtResult.Tables[0].Rows[i + 1]["RoleId"]) == 4)
                                        {
                                            builder.Append("<script language=JavaScript> ShowPopupApprovalTL(); </script>\n");
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalTL", builder.ToString());
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 2)
                            {
                                builder.Append("<script language=JavaScript> ShowPopupApprovalUser(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApprovalUser", builder.ToString());
                            }
                            else if (Convert.ToInt32(dtResult.Tables[0].Rows[i]["RoleId"]) == 4)
                            {
                                builder.Append("<script language=JavaScript> ShowPopupApproval(); </script>\n");
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupApproval", builder.ToString());
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopuphideSwitchUser(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopuphideSwitchUser", builder.ToString());
                builder.Append("<script language=JavaScript> HidePopupApproval(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApproval", builder.ToString());
                builder.Append("<script language=JavaScript> HidePopupApprovalTL(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalTL", builder.ToString());
                builder.Append("<script language=JavaScript> HidePopupApprovalUser(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopupApprovalUser", builder.ToString());
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}