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
                    Session["RoleId"] = dtResult.Tables[0].Rows[0]["RoleId"].ToString();
                    Session["Role"] = dtResult.Tables[0].Rows[0]["Role"].ToString();
                    Session["UserEmail"] = dtResult.Tables[0].Rows[0]["Email"].ToString();
                    Session["UserID"] = dtResult.Tables[0].Rows[0]["UserId"].ToString();
                    Session["Designation"] = dtResult.Tables[0].Rows[0]["Designation"].ToString();
                    if (dtResult.Tables[0].Rows[0]["Role"].ToString()=="Admin"|| dtResult.Tables[0].Rows[0]["Role"].ToString() == "User")
                    {
                        if(dtResult.Tables[0].Rows[0]["Role"].ToString() == "Admin" || dtResult.Tables[0].Rows[0]["Designation"].ToString()=="Manager" 
                            || dtResult.Tables[0].Rows[0]["Designation"].ToString() == "TeamLeader")
                        Response.Redirect("~/Admin/Dashboard.aspx");
                        else
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
            Response.Redirect("ForgotPassword.aspx?Email=" + txtUsername.Text.Trim());
        }
    }
}