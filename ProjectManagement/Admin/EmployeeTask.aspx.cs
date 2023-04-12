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
    public partial class EmployeeTask : System.Web.UI.Page
    {
        EmployeeBusinessLogic addEmployeeLogic = new EmployeeBusinessLogic();
        EmployeeBusinessObject addEmployee = new EmployeeBusinessObject();
        DataSet dtResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int projectId = Convert.ToInt32(Session["ProjectId"]);
                int userId = Convert.ToInt32(Session["UserId"]);
                dtResult= addEmployeeLogic.GetAllTaskByUserEmployeeTask(projectId, userId);
                grvEmployeeTask.DataSource = dtResult.Tables[0];
                grvEmployeeTask.DataBind();
                dtResult = addEmployeeLogic.GetAllTaskByUserEmployeeTask(projectId, userId);
                grvReassign.DataSource = dtResult.Tables[1];
                grvReassign.DataBind();

            }
        }

        protected void grvEmployeeTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}