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
    public partial class AddDesignation : System.Web.UI.Page
    {
        AddDesignationBusinessLogic addDesignation = new AddDesignationBusinessLogic();
        AddDesignationBusinessObject addDesignationObj = new AddDesignationBusinessObject();
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
                    GetClient(UserId);
                }
            }
        }

        private void GetClient(int Id)
        {
            btnAddDesignation.Text = "Update";
            DataSet dtResult = addDesignation.GetDesignationById(Id);
            txtDesignation.Text = dtResult.Tables[0].Rows[0]["Designation"].ToString();
        }

        protected void btnAddDesignation_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            addDesignationObj.Designation = txtDesignation.Text.Trim();
            if (btnAddDesignation.Text == "Add Designation")
            {
                successResult = addDesignation.InsertDesignation(addDesignationObj);
                if (successResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');location.href = 'ViewDesignation.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record already exists.');location.href = 'ViewDesignation.aspx';", true);
                }
                txtDesignation.Text = "";
            }
            else
            { 
                successResult=addDesignation.UpdateDesignation(addDesignationObj, UserId);
                if (successResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3ada", "alert('Record Updated successfully.');", true);
                }
                Response.Redirect("ViewDesignation.aspx");
            }
        }
    }
}