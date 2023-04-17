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
    public partial class ViewRole : System.Web.UI.Page
    {
        AddRoleBusinessLogic viewRole = new AddRoleBusinessLogic();
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
            dsResult = viewRole.GetRole();
            grvRole.DataSource = dsResult.Tables[0];
            grvRole.DataBind();
        }

        protected void grvRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRole")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["Id"] = Id;
                Response.Redirect("AddRole.aspx?UserId=" + Id);
            }

            if (e.CommandName == "DeleteRole")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["Id"] = Id;
                int COLIEnhancedPolicyDollarsID = Convert.ToInt32(e.CommandArgument);
                int dataout = viewRole.DeleteRole(Id);
                if (dataout == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Role is currently in use.');", true);
                }
                else if(dataout>0)
                {
                    grvRole.EditIndex = -1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    BindClientList();
                }
            }
        }

        protected void grvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRole.PageIndex = e.NewPageIndex;
            BindClientList();
        }
    }
}