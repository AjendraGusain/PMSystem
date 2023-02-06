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
	public partial class Dashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindClientList();
			}
		}

		private void BindClientList()
		{
			DashboardBussinessLogic getDashboard = new DashboardBussinessLogic();
			DataSet ds = getDashboard.GetDashboard();
			grvDashboard.DataSource = ds.Tables[0];
			grvDashboard.DataBind();
		}
	}
}