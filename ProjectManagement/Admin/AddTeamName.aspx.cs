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
    public partial class AddTeam : System.Web.UI.Page
    {

        ITeamBusinessLogic createTeamBA = new TeamBusinessLogic(new TeamDataAccess());
        TeamBusinessObject createTeam = new TeamBusinessObject();
        int respone = 0;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeList();
            }
        }

        private void BindEmployeeList()
        {
            
            BindProject();
            DataSet ds = createTeamBA.GetUser();
            grvViewTeam.DataSource = ds.Tables[0];
            grvViewTeam.DataBind();
            // ddlProject.Items.Clear();

            //ddlManager.DataSource = createTeamBA.GetManager();
            //ddlManager.DataTextField = "UserName";
            //ddlManager.DataValueField = "UserId";
            //ddlManager.DataBind();
            //ddlManager.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
            //ddlTeamleader.Items.Clear();
            //ddlTeamleader.DataSource = createTeamBA.GetTeamLeader();
            //ddlTeamleader.DataTextField = "UserName";
            //ddlTeamleader.DataValueField = "UserId";
            //ddlTeamleader.DataBind();
            //ddlTeamleader.Items.Insert(0, new ListItem("-- Select Team Leader --", "0"));
        }

        private void BindProject()
        {
            ddlProject.Items.Clear();
            ddlProject.DataSource = createTeamBA.GetProject();
            ddlProject.DataTextField = "ProjectName";
            ddlProject.DataValueField = "ProjectId";
            ddlProject.DataBind();
            ddlProject.Items.Insert(0, new ListItem("-- Select Project --", "0"));
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            //string ls = "";
            //createTeam.TeamName = txtTeamName.Text;
            //createTeam.Manager = ddlManager.SelectedValue;
            //createTeam.TeamLeader = ddlTeamleader.SelectedValue;
            //foreach (ListItem item in ddlEmployeeName.Items)
            //{
            //    if (item.Selected)
            //    {
            //        ls += item.Value;
            //        ls += ",";
            //    }
            //}
            //ls.TrimEnd(',');
            //createTeam.Employee = ls;
            //respone= createTeamBA.InsertTeam(createTeam);
            //if(respone==1)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Key3da", "alert('Record Inserted successfully.');", true);
            //}
        }

        protected void btnAddTeamName_Click(object sender, EventArgs e)
        {
            if (btnAddTeamName.Text == "Add Team")
            {
                createTeam.TeamName = txtTeamName.Text;
                createTeam.ProjectId = ddlProject.Text;
                respone = createTeamBA.InsertTeam(createTeam);
                if (respone == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Inserte", "alert('Record already exists.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Inserte", "alert('Record Inserted successfully.');", true);
                }
                txtTeamName.Text = "";
            }
            if (btnAddTeamName.Text == "Update")
            {
                createTeam.TeamName = txtTeamName.Text;
                createTeam.ProjectId = ddlProject.SelectedValue;
                int Id = Convert.ToInt32(Session["EmployeeUserId"]);
                int respone = createTeamBA.UpdateTeam(createTeam, Id);
                if (respone > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Update", "alert('Record Updated successfully');", true);
                }
                txtTeamName.Text = "";

            }
            BindEmployeeList();
            btnAddTeamName.Text = "Add Team";
        }

        protected void grvViewTeam_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                btnAddTeamName.Text = "Update";
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["EmployeeUserId"] = Id;
                DataSet dtResult = createTeamBA.GetTeamByID(Id);
                txtTeamName.Text = dtResult.Tables[0].Rows[0]["TeamName"].ToString();
                BindProject();
                ddlProject.SelectedValue = Convert.ToInt32(dtResult.Tables[0].Rows[0]["ProjectId"]).ToString();
                BindEmployeeList();
                //  Response.Redirect("AddEmployee.aspx?UserId=" + Id);
            }

            else if (e.CommandName == "Delete")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Session["Id"] = Id;
                int COLIEnhancedPolicyDollarsID = Convert.ToInt32(e.CommandArgument);
                int dataout = createTeamBA.DeleteTeam(Id);
                if (dataout > 0)
                {
                    grvViewTeam.EditIndex = -1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Delete", "alert('Record deleted successfully');", true);
                    BindEmployeeList();
                }
            }
        }

        protected void grvViewTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grvViewTeam_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}