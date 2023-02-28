using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using System.Collections;

namespace DataAccessLayer
{
    public class TaskDataAccessLayer
    {
        DataSet dsResult = new DataSet();
        int response = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public int InsertTaskDetails(TaskBusinessObjectLayer addTask, string sproc)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_AddCarrier";
               // string dsResult = "insert  into TaskList(ClientID,ProjectID,TaskID,TaskName,TaskDetails) values(@ClientID,@ProjectID,@TaskID,@TaskName,@TaskDetails)";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@ClientID", addTask.ClientID));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", addTask.ProjectID));
                cmd.Parameters.Add(new MySqlParameter("@TaskID", addTask.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@TaskName", addTask.TaskName));
                cmd.Parameters.Add(new MySqlParameter("@TaskDescription", addTask.TaskDescription));
              response=  cmd.ExecuteNonQuery();
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
            return response;
        }

        public DataSet GetClient()
        {
            try
            {

                dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.client");
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


        public DataSet GetProject()
        {
            try
            {

                dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.project");
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


        public DataSet GetProjectByClient(int ID)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "GetProjectByClient";
                dsResult = new Connection().ExecuteSP(spName, ID);
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


        public DataSet GetAssignedTask()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetAllTask";
                dsResult = new Connection().ExecuteSPWithoutID(spName);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


        public DataSet GetTaskDetails()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetAssignedTask";
                dsResult = new Connection().ExecuteSPWithoutID(spName);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


    }
}
