using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Users
{
    public partial class UserTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TaskBusinessObject addTaskBusinessObj = new TaskBusinessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetUserTaskDetails();
            }
        }

        protected void gvDisplayUserTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewUserTask")
            {
                int taskID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ViewTaskDetails.aspx?UserId=" + taskID);
            }
            if (e.CommandName == "AssignPlayUserTask")
            {

            }
        }

        protected void GetUserTaskDetails()
        {
            DataSet ds = assigntaskBLL.GetAssignedTask();
            pnlDisplayUserTask.Visible = true;
            gvDisplayUserTask.DataSource = ds.Tables[0];
            gvDisplayUserTask.DataBind();
        }

    }
}