using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClientList();
            }
        }

        private void BindClientList()
        {
            
            DataSet ds = addEmployeeLogic.GetAllEmployee();
            grvEmployeeDetails.DataSource = ds.Tables[0];
            grvEmployeeDetails.DataBind();
        }
        protected void grvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployeeDetail")
            {
                DataSet ds = addEmployeeLogic.GetAllEmployee();
            }
        }
    }
}