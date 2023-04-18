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
                    pnlTeamLeaderAccess.Visible = false;
                    pnlManagerTeamAccess.Visible = false;
                    pnlAddTask.Visible = true;
                }
                else if (roleID == 2)//For User 
                {
                    pnlAdmin.Visible = false;
                    pnlTeamLeaderAccess.Visible = false;
                    pnlManagerTeamAccess.Visible = false;
                    pnlUser.Visible = true;
                }
                else if (roleID == 4)//For TL
                {
                    pnlAdmin.Visible = false;
                    pnlTeamLeaderAccess.Visible = true;
                    pnlManagerTeamAccess.Visible = false;
                    pnlUser.Visible = true;
                    pnlAddTask.Visible = true;
                }
                else if(roleID == 3)//For Manager
                {
                    pnlAdmin.Visible = false;
                    pnlManagerTeamAccess.Visible = true;
                    pnlUser.Visible = true;
                    pnlTeamLeaderAccess.Visible = false;
                    pnlAddTask.Visible = true;
                }
            }
        }
    }
}