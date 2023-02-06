using BusinessLogicLayer;
using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class EmployeeDetail : System.Web.UI.Page
    {
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        EmployeeBusinessObject addEmployee = new EmployeeBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                GetEmployee(UserId);
            }
        }
        private void GetEmployee(int UserId)
        {
            DataSet dtResult = addEmployeeLogic.GetEmployeeById(UserId);
            lblEmployeeCode.Text = dtResult.Tables[0].Rows[0]["EmployeeCode"].ToString();
            lblEmployeeName.Text = dtResult.Tables[0].Rows[0]["UserName"].ToString();
            lblName.Text = dtResult.Tables[0].Rows[0]["UserName"].ToString();
            lblPhoneNo.Text = dtResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
            lblEmail.Text = dtResult.Tables[0].Rows[0]["Email"].ToString();
            lblRole.Text = dtResult.Tables[0].Rows[0]["Role"].ToString();
            lblDesignation.Text = dtResult.Tables[0].Rows[0]["Designation"].ToString();
        }
    }
}