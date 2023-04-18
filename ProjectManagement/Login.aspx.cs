using System;
using System.Collections.Generic;
using BussinessObjectLayer;
using BusinessLogicLayer;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer.Interface;

namespace ProjectManagement
{
    public partial class Login : System.Web.UI.Page
    {
        UserLoginBusinessLogic userBLL = new UserLoginBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                lblError.Text = "Please Insert Username or Password.";
            else
            {
                UserLoginObject userLogin = new UserLoginObject();
                IUserLogin userLogin1 = (IUserLogin)userBLL;
                userLogin.Email = txtUsername.Text.Trim();
                userLogin.Password = txtPassword.Text.Trim();
                DataSet dtResult = userLogin1.UserLogin(userLogin);
                if (dtResult.Tables[0].Rows.Count > 0)
                {
                    Session["User"] = dtResult.Tables[0].Rows[0]["UserName"].ToString();
                    Session["RoleID"] = dtResult.Tables[0].Rows[0]["RoleId"].ToString();
                    Session["UserEmail"] = dtResult.Tables[0].Rows[0]["Email"].ToString();
                    Session["UserID"] = dtResult.Tables[0].Rows[0]["UserId"].ToString();
                    if (dtResult.Tables[0].Rows[0]["Role"].ToString()=="Admin"|| dtResult.Tables[0].Rows[0]["Role"].ToString() == "TeamLeader"|| dtResult.Tables[0].Rows[0]["Role"].ToString() == "Manager")
                    {
                        Response.Redirect("~/Admin/Dashboard.aspx");
                    }
                    else if (dtResult.Tables[0].Rows[0]["Role"].ToString() == "User")
                    {
                        Response.Redirect("~/Users/UserTask.aspx");
                    }
                }
                else
                {
                    lblError.Text = "You have entered Wrong Username or Password.";
                }
            }
        }

        protected void lnkbtnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}