using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObjectLayer;
using BusinessLogicLayer;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using DataAccessLayer;
namespace ProjectManagement.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        Connection objCon = new Connection();
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        EmployeeBusinessObject addEmployee = new EmployeeBusinessObject();
        int successResult = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                if (UserId == 0)
                {
                    BindEmployeeList();
                }
                else
                {
                    GetEmployee(UserId);
                }
            }
        }

        private void GetEmployee(int UserId)
        {
            btnAddEmployee.Text = "Update";
            DataSet dtResult = addEmployeeLogic.GetEmployeeById(UserId);
            txtEmployeeCode.Text = dtResult.Tables[0].Rows[0]["EmployeeCode"].ToString();
            txtEmployeeName.Text = dtResult.Tables[0].Rows[0]["UserName"].ToString();
            txtPhoneNo.Text = dtResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
            txtEmail.Text = dtResult.Tables[0].Rows[0]["Email"].ToString();
            BindEmployeeList();
            //  ddlRoleList.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["RoleId"]).ToString();
            ddlDesignation.SelectedValue = dtResult.Tables[0].Rows[0]["DesignationId"].ToString();
            chkAdminAuth.Checked = Convert.ToBoolean(dtResult.Tables[0].Rows[0]["IsAdmin"]);
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            addEmployee.EmployeeCode = txtEmployeeCode.Text.Trim();
            addEmployee.EmployeeEmail = txtEmail.Text.Trim();
            addEmployee.EmployeePhone = txtPhoneNo.Text.Trim();
            addEmployee.EmployeeName = txtEmployeeName.Text.Trim();
            addEmployee.Designation = ddlDesignation.SelectedValue;
            string usercode = "";
            string userEmail = "";
            string userphone = "";
            if (btnAddEmployee.Text == "Add Employee")
            {
                addEmployeeLogic.UserCheck(addEmployee, out usercode, out userEmail, out userphone);
                if (usercode != "" || userEmail != "" || userphone != "")
                {
                    if (usercode == "EmployeeCode")
                    {
                        lblCheckCode.Text = "Employee Code Already Exists";
                    }
                    if (userEmail == "EmployeeEmail")
                    {
                        lblCheckEmail.Text = "Employee Email Already Exists";
                    }
                    if (userphone == "EmployeePhone")
                    {
                        lblCheckPhone.Text = "Phone Already Exists";
                    }
                    return;
                }
                else
                {
                    int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                    addEmployee.EmployeeName = txtEmployeeName.Text.Trim();
                    addEmployee.Designation = ddlDesignation.SelectedValue;

                    addEmployee.IsAdmin = chkAdminAuth.Checked;
                    if (chkAdminAuth.Checked == true)
                    {
                        addEmployee.Role = "1";//Admin
                    }
                    else
                    {
                        addEmployee.Role = "2";//User
                    }

                    if (btnAddEmployee.Text == "Add Employee")
                    {
                        successResult = addEmployeeLogic.InsertAllEmployeeDetails(addEmployee);
                        DataSet dtResult = addEmployeeLogic.GetAllEmployeeByEmail(addEmployee.EmployeeEmail);
                        if (dtResult.Tables[0].Rows.Count > 0)
                        {
                            if (dtResult.Tables[0].Rows[0]["Email"].ToString() != "" || dtResult.Tables[0].Rows[0]["Email"].ToString() != null)
                            {
                                string useremail = dtResult.Tables[0].Rows[0]["Email"].ToString();
                                string resetToken = Guid.NewGuid().ToString();
                                successResult = addEmployeeLogic.UpdateToken(resetToken, useremail);
                                objCon.SendResetPasswordEmail(useremail, resetToken);
                            }
                        }
                        if (successResult == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                        }
                        txtEmployeeCode.Text = "";
                        txtEmployeeName.Text = "";
                        txtEmail.Text = "";
                        txtPhoneNo.Text = "";
                        // ddlRoleList.SelectedValue = "0";
                        ddlDesignation.SelectedValue = "0";
                        chkAdminAuth.Checked = false;
                    }
                }
            }
            else
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                addEmployee.IsAdmin = chkAdminAuth.Checked;
                if (chkAdminAuth.Checked == true)
                {
                    addEmployee.Role = "1";//Admin
                }
                else
                {
                    addEmployee.Role = "2";//User
                }
                successResult = addEmployeeLogic.UpdateAllEmployee(addEmployee, UserId);
                if (successResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3uda", "alert('Record updated successfully.');", true);
                }
                Response.Redirect("ViewAllEmployee.aspx");
            }
        }

        public void ResetAllFields()
        {
            txtEmployeeCode.Text = "";
            txtEmployeeName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            ddlDesignation.SelectedItem.Text = "--Select Designation--";
            chkAdminAuth.Checked = false;
            lblCheckCode.Text = "";
            lblCheckEmail.Text = "";
            lblCheckPhone.Text = "";
        }

        protected void BindEmployeeList()
        {
            //ddlRoleList.Items.Clear();
            //ddlRoleList.DataSource = addEmployeeLogic.GetAllRole();
            //ddlRoleList.DataTextField = "Role";
            //ddlRoleList.DataValueField = "RoleId";
            //ddlRoleList.DataBind();
            //ddlRoleList.Items.Insert(0, new ListItem("-- Select Role --", "0"));
            ddlDesignation.Items.Clear();
            ddlDesignation.DataSource = addEmployeeLogic.GetAllDesignation();
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "Id";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation --", "0"));
        }

        protected void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {

            //addEmployee.EmployeeCode = txtEmployeeCode.Text;
            //string checkUser= addEmployeeLogic.UserCheck(addEmployee);
            // if (checkUser == "insert")
            // {
            //     lblCheckCode.Text = "";
            // }
            // else
            //     lblCheckCode.Text = checkUser;

        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAllFields();
        }


        //protected void SendResetPasswordEmail(string tomail, string UniqueID)
        //{
        //    string from = "deepak.dhiman1988@gmail.com";
        //    MailMessage mailMsg = new MailMessage(from, tomail);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append("Dear " + tomail + ",<br/><br/>");
        //    stringBuilder.Append("Please click on the below link to reset your password");
        //    stringBuilder.Append("<br/>");
        //    stringBuilder.Append("https://localhost:44399/ResetPassword.aspx?UID="+UniqueID);
        //    stringBuilder.Append("<br/><br/>");

        //    mailMsg.IsBodyHtml = true;
        //    mailMsg.Body = stringBuilder.ToString();
        //    mailMsg.Subject = "Reset Your Password";
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    NetworkCredential NetworkCred = new NetworkCredential(from, "zqgfvyigriszjcej");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.EnableSsl = true;
        //    try
        //    {
        //        smtp.Send(mailMsg);
        //        ScriptManager.RegisterStartupScript(this, GetType(), "mail", "alert('Mail sent successfully.');", true);
        //    }
        //    catch(Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
    }
}
