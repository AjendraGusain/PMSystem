using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        UserLoginBusinessLogic userBLL = new UserLoginBusinessLogic();
        
        UserLoginObject userBusinessObject = new UserLoginObject();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            int response = 0;
            string uid = Request.QueryString["UID"];
            DataSet ds = userBLL.GetUsersDetailByUID(uid);
            DateTime currentDate = DateTime.Now;
            TimeSpan dateDiff = currentDate - Convert.ToDateTime(ds.Tables[0].Rows[0]["UIDDate"]);
            double diffinHour = dateDiff.Hours;
            double diffinMin = dateDiff.Minutes;
            userBusinessObject.Email = ds.Tables[0].Rows[0]["Email"].ToString();
            userBusinessObject.ResetPassword = txtresetPassword.Text;
            userBusinessObject.ConfirmPassword = txtConfirmPassword.Text;
            //if (diffinHour > 24)
            if(diffinMin>2)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mail", "alert('Link expired.');", true);
            }
            else
            {
                if(userBusinessObject.ResetPassword== userBusinessObject.ConfirmPassword && uid== ds.Tables[0].Rows[0]["UID"].ToString())
                {
                    response = userBLL.ResetPassword(userBusinessObject);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass1", "alert('New Password and Confirm Password not matched.');", true);
                }
                if (response > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "pass2", "alert('Password Reset successfully.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Password Reset successfully.');location.href = 'Login.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass3", "alert('Password not Reset.');", true);
                }
                //Response.Redirect("Login.aspx");
            }
        }
    }
}