using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement
{
    public partial class Home1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Global.Role = Session["Role"].ToString();
                Global.RoleIdSession = Convert.ToInt32(Session["RoleId"].ToString());
                string Designation = Session["Designation"].ToString();
                if (Global.RoleIdSession == 4)
                    Designation = "Manager";
                else if(Global.RoleIdSession == 3)
                    Designation = "TeamLeader";
                else if(Global.RoleIdSession == 1)
                    Designation = "Admin";

                if (Global.Role == "Admin")//For Admin 
                {
                    pnlAdmin.Visible = true;
                    pnlUser.Visible = false;
                    pnlTeamLeaderAccess.Visible = false;
                    pnlManagerTeamAccess.Visible = false;
                    pnlAddTask.Visible = true;
                }
                else if (Global.Role == "User")//For User 
                {
                    if(Designation=="Manager")
                    {
                        Global.RoleId = 3;
                        pnlAdmin.Visible = false;
                        pnlTeamLeaderAccess.Visible = false;
                        pnlManagerTeamAccess.Visible = true;
                        pnlUser.Visible = true;
                        pnlAddTask.Visible = true;
                        pnlUser.Visible = false;
                    }
                    else if (Designation == "TeamLeader")
                    {
                        Global.RoleId = 4;
                        pnlAdmin.Visible = false;
                        pnlManagerTeamAccess.Visible = false;
                        pnlUser.Visible = true;
                        pnlTeamLeaderAccess.Visible = true;
                        pnlAddTask.Visible = true;
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                        pnlTeamLeaderAccess.Visible = false;
                        pnlManagerTeamAccess.Visible = false;
                        pnlAddTask.Visible = false;
                        pnlUser.Visible = true;
                    }
                }
               
            }
        }

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Response.Redirect("~/Login.aspx");
        //}

        //protected void btnlogin_Click(object sender, EventArgs e)
        //{
        //        Session.Abandon();
        //        //Session.Remove("UserID");
        //        //Session.Remove("password");
        //        Response.Redirect("~/Login.aspx");
        //}
    }
}