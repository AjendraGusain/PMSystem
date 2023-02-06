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
    public partial class ViewDesignation : System.Web.UI.Page
    {
        AddDesignationBusinessLogic viewDesignation = new AddDesignationBusinessLogic();
        DataSet dsResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClientList();
            }
        }

        private void BindClientList()
        {
            dsResult = viewDesignation.GetDesignation();
            grvDesignation.DataSource = dsResult.Tables[0];
            grvDesignation.DataBind();
        }

        protected void grvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDesignation")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                Response.Redirect("AddDesignation.aspx?UserId=" + Id);
            }

            if (e.CommandName == "DeleteDesignation")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                int COLIEnhancedPolicyDollarsID = Convert.ToInt32(e.CommandArgument);
                int dataout = viewDesignation.DeleteDesignation(Id);
                if (dataout > 0)
                {
                    grvDesignation.EditIndex = -1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    BindClientList();

                }
            }
        }

        protected void grvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDesignation.PageIndex = e.NewPageIndex;
            BindClientList();
        }
    }
}