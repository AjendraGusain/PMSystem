using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Admin
{
    public partial class ViewClient : System.Web.UI.Page
    {
        IClientBusinessLogic viewClient = new ClientBusinessLogic(new ClientDataAccess());
        IProjectDataAccess projectRepo = new ProjectDataAccess();
        ClientBusinessObject addClientObj = new ClientBusinessObject();
        DataSet dsResult = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    BindClientList();
                }
            }
        }
        private void BindClientList()
            {
                dsResult = viewClient.GetClients();
                grvClient.DataSource = dsResult.Tables[0];
                grvClient.DataBind();
            }

        protected void grvClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditClient")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                Response.Redirect("AddClient.aspx?UserId=" + Id);
            }

            if (e.CommandName == "DeleteClient")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                dsResult = projectRepo.GetAllProject();
                DataRow[] foundClient = dsResult.Tables[0].Select("ClientId = '" + Id + "'");
                if (foundClient.Length != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('A project is assigned to this client. Please reassing the project before removing the client.');", true);//location.href = 'AddTeamEmployee.aspx';
                }
                else
                {
                    int dataout = viewClient.DeleteClient(Id);
                    if (dataout > 0)
                    {
                        grvClient.EditIndex = -1;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                        BindClientList();
                    }
                }
            }
        }

        protected void grvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvClient.PageIndex = e.NewPageIndex;
            BindClientList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            addClientObj.ClientName = txtClientNameSearch.Text.Trim();
            DataSet response = viewClient.ClientSearch(addClientObj);
            grvClient.DataSource = response.Tables[0];
            grvClient.DataBind();
        }

       
    }
}