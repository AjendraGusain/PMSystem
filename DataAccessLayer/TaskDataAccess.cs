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
using DataAccessLayer.Interface;
namespace DataAccessLayer
{
    public class TaskDataAccess : ITaskDataAccess
    {
        TaskBusinessObject addTaskBO = new TaskBusinessObject();

        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public int InsertTaskDetails(TaskBusinessObject addTask)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_CreateTask";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@ClientID", addTask.ClientID));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", addTask.ProjectID));
                cmd.Parameters.Add(new MySqlParameter("@TaskID", addTask.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@TaskName", addTask.TaskName));
                cmd.Parameters.Add(new MySqlParameter("@TaskDescription", addTask.TaskDescription));
                addTask.response =  cmd.ExecuteNonQuery();
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
            return addTaskBO.response;
        }

        //public DataSet GetClient()
        //{
        //    try
        //    {
        //        dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.client");
        //        return dsResult;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //    }
        //}

        public DataSet GetProject()
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.project");
                return addTaskBO.dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
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
                addTaskBO.dsResult = new Connection().ExecuteSPWithoutID(spName);
                return addTaskBO.dsResult;
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
                addTaskBO.dsResult = new Connection().ExecuteSPWithoutID(spName);
                return addTaskBO.dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DataSet GetClients()
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.client");
                return addTaskBO.dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DataSet GetProjectByClient(int objClientID)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "GetProjectByClient";
                addTaskBO.dsResult = new Connection().ExecuteSP(spName, objClientID);
                return addTaskBO.dsResult;
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
