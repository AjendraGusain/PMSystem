using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObjectLayer;
using BusinessLogicLayer;
using System.Data;

namespace ProjectManagement.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
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
            ddlRoleList.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["RoleId"]).ToString();
            ddlDesignation.SelectedValue = dtResult.Tables[0].Rows[0]["DesignationId"].ToString();
            chkAdminAuth.Checked = Convert.ToBoolean(dtResult.Tables[0].Rows[0]["IsAdmin"]);
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            addEmployee.EmployeeCode = txtEmployeeCode.Text;
            addEmployee.EmployeeEmail = txtEmail.Text;
            bool checkCode = addEmployeeLogic.UserCheck(addEmployee);
            bool checkEmail = addEmployeeLogic.UserCheck(addEmployee);
            bool checkPhone = addEmployeeLogic.UserCheck(addEmployee);

            if (checkCode == true)
            {
                lblCheckCode.Text = "Employee Code Already Exists";
            }
            if (checkEmail == true)
            {
                lblCheckEmail.Text = "Employee Email Already Exists";
            }
            if (checkPhone == true)
            {
                lblCheckPhone.Text = "Phone Already Exists";
            }

            else
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                addEmployee.EmployeeCode = txtEmployeeCode.Text.Trim();
                addEmployee.EmployeeName = txtEmployeeName.Text.Trim();
                addEmployee.EmployeeEmail = txtEmail.Text.Trim();
                addEmployee.EmployeePhone = txtPhoneNo.Text.Trim();
                addEmployee.Role = ddlRoleList.SelectedValue;
                addEmployee.Designation = ddlDesignation.SelectedValue;
                addEmployee.IsAdmin = chkAdminAuth.Checked;
                if (btnAddEmployee.Text == "Add Employee")
                {
                    successResult = addEmployeeLogic.InsertAllEmployeeDetails(addEmployee);
                    if (successResult == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                    }
                    txtEmployeeCode.Text = "";
                    txtEmployeeName.Text = "";
                    txtEmail.Text = "";
                    txtPhoneNo.Text = "";
                    ddlRoleList.SelectedValue = "0";
                    ddlDesignation.SelectedValue = "0";
                    chkAdminAuth.Checked = false;
                }
                else
                {
                    successResult = addEmployeeLogic.UpdateAllEmployee(addEmployee, UserId);
                    if (successResult == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Key3uda", "alert('Record updated successfully.');", true);
                    }
                }
            }
        }

        protected void BindEmployeeList()
        {
            ddlRoleList.Items.Clear();
            ddlRoleList.DataSource = addEmployeeLogic.GetAllRole();
            ddlRoleList.DataTextField = "Role";
            ddlRoleList.DataValueField = "RoleId";
            ddlRoleList.DataBind();
            ddlRoleList.Items.Insert(0, new ListItem("-- Select Role --", "0"));
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
            //addEmployee.EmployeeEmail = txtEmail.Text;
            //string checkUser = addEmployeeLogic.UserCheck(addEmployee);
            //if (checkUser == "insert")
            //{
            //    lblCheckEmail.Text = "";
            //}
            //else
            //    lblCheckEmail.Text = checkUser;
        }

        protected void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {
            //addEmployee.EmployeePhone = txtEmail.Text;
            //string checkUser = addEmployeeLogic.UserCheck(addEmployee);
            //if (checkUser == "insert")
            //{
            //    lblCheckCode.Text = "";
            //}
            //else
            //    lblCheckCode.Text = checkUser;
        }
    }
}