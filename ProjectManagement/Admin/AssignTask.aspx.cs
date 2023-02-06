using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
namespace ProjectManagement.Admin
{
    public partial class AssignTask : System.Web.UI.Page
    {

        TaskBusinessLogicLayer assigntaskBLL = new TaskBusinessLogicLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAssignedTask();
            }
        }

        protected void grvAssignedTaskDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewAssignedTask")
            {
                pnlDisplayAssignTask.Visible = false;
                pnlDisplayTaskDetails.Visible = true;
                GetTaskDetails();
            }
        }

        protected void GetAssignedTask()
        {
            DataSet ds = assigntaskBLL.GetAssignedTask();
            pnlDisplayAssignTask.Visible = true;
            pnlDisplayTaskDetails.Visible = false;
            grvAssignedTaskDetails.DataSource = ds.Tables[0];
            grvAssignedTaskDetails.DataBind();
        }

        protected void GetTaskDetails()
        {
            DataSet ds = assigntaskBLL.GetAssignedTask();
            pnlDisplayTaskDetails.Visible = true;
            pnlDisplayAssignTask.Visible = false;
            gvTaskDetails.DataSource = ds.Tables[0];
            gvTaskDetails.DataBind();
        }
    }
}