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
    public partial class AddRole : System.Web.UI.Page
    {
        AddRoleBusinessLogic addRole = new AddRoleBusinessLogic();
        AddRoleBusinessObject addRoleObj = new AddRoleBusinessObject();
        int successResult = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                if (UserId == 0)
                {
                }
                else
                {
                    GetRole(UserId);
                }
            }
        }

        private void GetRole(int Id)
        {
            btnAddRole.Text = "Update";
            DataSet dtResult = addRole.GetRoleById(Id);
            txtRole.Text = dtResult.Tables[0].Rows[0]["Role"].ToString();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["UserId"]);
            addRoleObj.Role = txtRole.Text.Trim();
            if (btnAddRole.Text == "Add Role")
            {
                successResult = addRole.InsertRole(addRoleObj);
                if (successResult == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record already exists.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                }
                txtRole.Text = "";
            }
            else
            {
                successResult=addRole.UpdateRole(addRoleObj, Id);
                if (successResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3uda", "alert('Record updated successfully.');", true);
                }
            }
        }
    }
}