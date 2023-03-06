using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class ViewAllTask : System.Web.UI.Page
    {
        ITaskBusinessLogic assigntaskBLL = new TaskBusinessLogic(new TaskDataAccess());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllCreatedTask();
            }
        }
        public void GetAllCreatedTask()
        {
            DataSet ds = assigntaskBLL.GetAllCreatedTask();
            grvViewAllTask.DataSource = ds.Tables[0];
            grvViewAllTask.DataBind();
        }
    }
}