using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObjectLayer;
using BusinessLogicLayer;
namespace ProjectManagement.Admin
{
    public partial class Task : System.Web.UI.Page
    {
        TaskBusinesLogicLayer taskBusinessLogicLayer = new TaskBusinesLogicLayer();
        TaskBusinessObjectLayer taskBussinessObjectLayer = new TaskBusinessObjectLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateTask_Click(object sender, EventArgs e)
        {
            taskBussinessObjectLayer.TaskName = txtTaskName.Text.Trim();
            taskBusinessLogicLayer.InsertTaskDetails(taskBussinessObjectLayer);
        }
    }
}