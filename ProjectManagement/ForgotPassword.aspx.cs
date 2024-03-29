﻿using BusinessLogicLayer;
using BussinessObjectLayer;
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
using DataAccessLayer;
namespace ProjectManagement
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        Connection objCon = new Connection();
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        EmployeeBusinessObject addEmployee = new EmployeeBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string email = Request.QueryString["Email"].ToString();
                if (email != "")
                {
                    btnForgotPassword.Text = "Resend Link";
                    txtEmail.Text = email;
                }
            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            int successResult = 0;
            addEmployee.EmployeeEmail = txtEmail.Text.Trim();
            DataSet dtResult = addEmployeeLogic.GetAllEmployeeByEmail(addEmployee.EmployeeEmail);
            if (dtResult.Tables[0].Rows.Count > 0)
            {
                if (dtResult.Tables[0].Rows[0]["Email"].ToString() != "" || dtResult.Tables[0].Rows[0]["Email"].ToString() != null)
                {
                    string useremail = dtResult.Tables[0].Rows[0]["Email"].ToString();
                    string resetToken = Guid.NewGuid().ToString();
                    successResult = addEmployeeLogic.UpdateToken(resetToken, useremail);
                    objCon.SendResetPasswordEmail(useremail, resetToken);
                    ScriptManager.RegisterStartupScript(this, GetType(), "mail", "alert('Mail sent successfully.');", true);
                }
            }
        }
    }
}