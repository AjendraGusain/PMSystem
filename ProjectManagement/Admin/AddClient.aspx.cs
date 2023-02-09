using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class AddClient : System.Web.UI.Page
    {

        IClientBusinessLogic addClient = new ClientBusinessLogic(new ClientDataAccess());
        ClientBusinessObject addClientObj = new ClientBusinessObject();
        private int response = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                if (UserId == 0)
                {
                    BindCountryList();
                }
                else
                {
                    GetClient(UserId);
                }
            }
        }

        private void GetClient(int Id)
        {
            btnAddClient.Text = "Update";
            DataSet dtResult = addClient.GetClientByID(Id);
            txtClient.Text = dtResult.Tables[0].Rows[0]["ClientName"].ToString();
            BindCountryList();
            ddlClientCountry.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["CountryId"]).ToString();
        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            //txtClient.Text = "";
            //ddlClientCountry.SelectedValue= "0";
            addClientObj.ClientName = txtClient.Text.Trim();
            addClientObj.Country = ddlClientCountry.SelectedValue;

            if (btnAddClient.Text == "Add Client")
            {
                response = addClient.InsertClient(addClientObj);
                if (response == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
                    txtClient.Text = "";
                    ddlClientCountry.SelectedValue = "0";
                }
            }
            else
            {
                response = addClient.UpdateClient(addClientObj, UserId);
                if (response == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Key3ada", "alert('Record Updated successfully.');", true);
                }
                Response.Redirect("ViewClient.aspx");
            }
        }
        protected void BindCountryList()
        {
            ddlClientCountry.Items.Clear();
            ddlClientCountry.DataSource = addClient.GetCountry();
            ddlClientCountry.DataTextField = "CountryName";
            ddlClientCountry.DataValueField = "Id";
            ddlClientCountry.DataBind();
            ddlClientCountry.Items.Insert(0, new ListItem("-- Select Country --", "0"));
        }
    }
}