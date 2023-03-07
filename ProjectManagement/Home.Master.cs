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
                Response.Redirect("Login.aspx");
            }
            else
            {
                int RoleID = Convert.ToInt32(Session["RoleId"].ToString());
                if (RoleID == 1)//For Admin 
                {
                    pnlAdmin.Visible = true;
                    pnlUser.Visible = false;
                }
                else if (RoleID == 2)//For User 
                {
                    pnlAdmin.Visible = false;
                    pnlUser.Visible = true;
                }
                else if (RoleID == 3|| RoleID == 4)
                {

                }
            }
        }
    }
}