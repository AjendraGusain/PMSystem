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
                int roleID = Convert.ToInt32(Session["RoleId"].ToString());
                if (roleID == 1)//For Admin 
                {
                    pnlAdmin.Visible = true;
                    pnlUser.Visible = false;
                    pnlTeamLeaderAccess.Visible = true;
                }
                else if (roleID == 2)//For User 
                {
                    pnlAdmin.Visible = false;
                    pnlTeamLeaderAccess.Visible = false;
                    pnlUser.Visible = true;
                }
                else if (roleID == 3|| roleID == 4)
                {
                    pnlAdmin.Visible = false;
                    pnlTeamLeaderAccess.Visible = true;
                    pnlUser.Visible = true;
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