using BussinessObjectLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AddProjectDataAccess
    {
        DataSet dsResult = new DataSet();
        int insertSuccess = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);

        public int InsertProjectDetails(AddProjectBusinessObject addProject)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagement.ProjectDetails(ProjectName, ClientId , StartDate) values(@ProjectName, @ClientId, @StartDate)";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@ProjectName", addProject.projectName));
                cmd.Parameters.Add(new MySqlParameter("@ClientId", addProject.clientID));
                cmd.Parameters.Add(new MySqlParameter("@StartDate", addProject.startDate));
                insertSuccess = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return insertSuccess;
        }
        public DataSet GetClientDetails()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM  ProjectManagement.ClientDetails");
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            //return dsResult;
        }
    }
}
