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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_CreateTask";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@ClientID", addTask.ClientID));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", addTask.ProjectID));
                cmd.Parameters.Add(new MySqlParameter("@TaskNumber", addTask.TaskNumber));
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
            return addTask.response;
        }

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


        public DataSet GetAllCreatedTask()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetAllCreatedTask";
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

        public DataSet ReAssignTask(int taskID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_ReAssignTaskByID";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                addTaskBO.dsResult = new Connection().ExecuteSPByTaskID(spName, taskID);
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


        public DataSet AssignTask(int taskID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_AssignTaskByID";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                addTaskBO.dsResult = new Connection().ExecuteSPByTaskID(spName, taskID);
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

        public int InsertAssignedTaskDetails(TaskBusinessObject assignTask)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.user_task(UserId,TeamMemberId,TaskId,AssignedByUserID,AssignedDate,ProjectId,IsActive) values(@UserId,@TeamMemberId, @TaskId,@AssignedByUserID,@AssignedDate,@ProjectId,'1');  Update ProjectManagementNew.task set StatusID=2 where TaskId=" + assignTask.TaskID + " and ProjectId="+ assignTask.ProjectID;
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UserId", assignTask.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@TeamMemberId", assignTask.TeamMemberID));
                cmd.Parameters.Add(new MySqlParameter("@TaskId", assignTask.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedByUserID", assignTask.LoginUserID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedDate", assignTask.AssignedDate));
                cmd.Parameters.Add(new MySqlParameter("@ProjectId", Convert.ToInt32(assignTask.ProjectID)));
                assignTask.response = cmd.ExecuteNonQuery();
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
            return assignTask.response;
        }

        public int UpdateAssignedTaskDetails(TaskBusinessObject assignTask)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update ProjectManagementNew.user_task set UnassignedByUserID=@UnassignedByUserID," +
                    "UnassignedDate=@UnassignedDate,IsActive='0' where TaskId="+ assignTask.TaskID+ " and ProjectId=" 
                    + assignTask.ProjectID + " and TeamMemberId=" + assignTask.TeamMemberID;
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UnassignedByUserID", assignTask.LoginUserID));
                cmd.Parameters.Add(new MySqlParameter("@UnassignedDate", assignTask.AssignedDate));
                assignTask.response = cmd.ExecuteNonQuery();
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
            return assignTask.response;
        }

        public DataSet SearchResult(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_SearchResult";
                Hashtable obj = new Hashtable();
                obj.Add("@ProjectID", searchResult.ProjectID);
                obj.Add("@name", searchResult.SearchResult);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
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

        public DataSet SearchResultByClient(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_SearchAllTaskByClientID";
                Hashtable obj = new Hashtable();
                obj.Add("@ClientCheckID", searchResult.ClientID);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
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

        public DataSet SearchResultByProject(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_SearchAllTaskByProjectID";
                Hashtable obj = new Hashtable();
                obj.Add("@ProjectCheckID", searchResult.ProjectID);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
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

        public DataSet SearchResultByUser(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_SearchAllTaskByUser";
                Hashtable obj = new Hashtable();
                obj.Add("@name", searchResult.SearchResult);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
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

        public DataSet GetAllUsers(TaskBusinessObject objProjectuser)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetTeamByProjectID";
                Hashtable obj = new Hashtable();
                obj.Add("@ProjectCheckID", objProjectuser.ProjectID);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
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

        public int InsertChatDetails(TaskBusinessObject Chat)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.task_comment(TaskId,UserId,TaskComment,CommentDate) " +
                    "values(@TaskId,@UserId,@TaskComment,@CommentDate)";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@TaskId", Chat.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@UserId", Convert.ToInt32(Chat.EmployeeName)));
                cmd.Parameters.Add(new MySqlParameter("@TaskComment", Chat.TaskDescription));
                cmd.Parameters.Add(new MySqlParameter("@CommentDate", Chat.AssignedDate));
                Chat.response = cmd.ExecuteNonQuery();
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
            return Chat.response;
        }

        public DataSet GetChatDetails()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetChatHistory";
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
    }
}
