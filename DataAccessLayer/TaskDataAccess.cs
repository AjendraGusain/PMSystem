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
                addTask.response = cmd.ExecuteNonQuery();
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public DataSet GetStatusName()
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.status");
                return addTaskBO.dsResult;
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                string dsResult = "insert  into ProjectManagementNew.user_task(UserId,TeamMemberId,TaskId,AssignedByUserID,AssignedDate,ProjectId,IsActive) values(@UserId,@TeamMemberId, @TaskId,@AssignedByUserID,@AssignedDate,@ProjectId,'1');  Update ProjectManagementNew.task set StatusID=2 where TaskId=" + assignTask.TaskID + " and ProjectId=" + assignTask.ProjectID;
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
                    "UnassignedDate=@UnassignedDate,IsActive='0' where TaskId=" + assignTask.TaskID + " and ProjectId="
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public DataSet SearchResultByStatus(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int roleID = searchResult.RoleID;
                string spName = "";
                Hashtable obj = new Hashtable();
                if (roleID == 2)
                {
                    spName = "sp_FilterTaskByUserandStatus";
                    obj.Add("@StatusNameID", searchResult.StatusID);
                    obj.Add("@UserNameID", searchResult.LoginUserID);
                }
                else
                {
                    spName = "sp_SearchTaskByStatusID";
                    obj.Add("@StatusCheckID", searchResult.StatusID);
                }
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
                return addTaskBO.dsResult;
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public DataSet SearchResultByDate(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string startDate = "";
                string endDate = "";
                if (Convert.ToDateTime(searchResult.StartDate).ToString() != "")
                {
                    startDate = Convert.ToDateTime(searchResult.StartDate).ToString("yyyy'-'MM'-'dd");
                }
                if (Convert.ToDateTime(searchResult.EndDate).ToString() != "")
                {
                    endDate = Convert.ToDateTime(searchResult.EndDate).ToString("yyyy'-'MM'-'dd");
                }
                string spName = "sp_FilterTaskByDate";
                Hashtable obj = new Hashtable();
                obj.Add("@StartDateTime", startDate);
                obj.Add("@EndDateTime", endDate);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
                return addTaskBO.dsResult;
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetTeamMemberID(TaskBusinessObject teamMember)
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.team_member where UserId = " + teamMember.LoginUserID + " and ProjectId = " + teamMember.ProjectID + " and ClientId = " + teamMember.ClientID + " and RoleId=2 and ParrentTeamMemberId!=0");
                return addTaskBO.dsResult;
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
        }

        public int InsertUserAssignedTask(TaskBusinessObject assignUserTask)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.user_task(UserId,TeamMemberId,TaskId,AssignedByUserID,AssignedDate,ProjectId,IsActive) values(@UserId,@TeamMemberId, @TaskId,@AssignedByUserID,@AssignedDate,@ProjectId,'1');  Update ProjectManagementNew.task set StatusID=2 where TaskId=" + assignUserTask.TaskID + " and ProjectId=" + assignUserTask.ProjectID;
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UserId", assignUserTask.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@TeamMemberId", assignUserTask.TeamMemberID));
                cmd.Parameters.Add(new MySqlParameter("@TaskId", assignUserTask.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedByUserID", assignUserTask.LoginUserID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedDate", assignUserTask.AssignedDate));
                cmd.Parameters.Add(new MySqlParameter("@ProjectId", Convert.ToInt32(assignUserTask.ProjectID)));
                assignUserTask.response = cmd.ExecuteNonQuery();
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
            return assignUserTask.response;
        }

        public DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetAllCreatedTaskByUser";
                Hashtable obj = new Hashtable();
                obj.Add("@UserNameID", taskByUser.EmployeeName);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
                return addTaskBO.dsResult;
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
        }

        public int UpdateUserTaskStatus(TaskBusinessObject taskStatus)
        {
            try
            {
                string spName = "sp_InitialStartJob";
                Hashtable obj = new Hashtable();
                obj.Add("@UserCheckId", taskStatus.EmployeeName);
                obj.Add("@TaskCheckID", taskStatus.TaskID);
                obj.Add("@ProjectCheckID", Convert.ToInt32(taskStatus.ProjectID));
                obj.Add("@ClientCheckID", Convert.ToInt32(taskStatus.ClientID));
                addTaskBO.response = new Connection().InsertEntry(spName, false, obj);
                return addTaskBO.response;
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
        }

        public int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (taskStatus.PauseReasonStatus == null)
                {
                    string spName = "sp_InitialPauseJob";
                    Hashtable obj = new Hashtable();
                    obj.Add("@UserCheckId", taskStatus.EmployeeName);
                    obj.Add("@TaskCheckID", taskStatus.TaskID);
                    obj.Add("@ProjectCheckID", Convert.ToInt32(taskStatus.ProjectID));
                    obj.Add("@ClientCheckID", Convert.ToInt32(taskStatus.ClientID));
                    obj.Add("@PauseReasonComment", taskStatus.PauseReason);
                    addTaskBO.response = new Connection().InsertEntry(spName, false, obj);
                }
                else if (taskStatus.PauseReasonStatus.Contains("End of the Day")|| taskStatus.PauseReasonStatus.Contains("Completed")||
                    taskStatus.PauseReasonStatus.Contains("Ready for Test"))
                {
                    string spName = "sp_PauseReasonStatusJob";
                    Hashtable obj = new Hashtable();
                    obj.Add("@UserCheckId", taskStatus.EmployeeName);
                    obj.Add("@TaskCheckID", taskStatus.TaskID);
                    obj.Add("@PauseReasonStatus", taskStatus.PauseReasonStatus);
                    addTaskBO.response = new Connection().InsertEntry(spName, false, obj);
                }
                else
               // if (taskStatus.PauseReasonStatus == "Bug History")
                {
                    string dsResult = "insert  into ProjectManagementNew.user_task_Bug (UserId,Date,BugDescription) values(@UserId,Now(), @PauseReasonStatus);";
                    MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                    cmd.Parameters.Add(new MySqlParameter("@UserId", taskStatus.EmployeeName));
                    cmd.Parameters.Add(new MySqlParameter("@PauseReasonStatus", taskStatus.PauseReasonStatus));
                    taskStatus.response = cmd.ExecuteNonQuery();
                }
                return addTaskBO.response;
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
        }

        public DataSet UserTaskTime(TaskBusinessObject objUserTask)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetUserTaskTime";
                Hashtable obj = new Hashtable();
                obj.Add("@TaskNameId", objUserTask.TaskID);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
                return addTaskBO.dsResult;
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
        }

        public DataSet TaskBugHistory(TaskBusinessObject objUserTask)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetTaskBugHistory";
                Hashtable obj = new Hashtable();
                obj.Add("@TaskNameID", objUserTask.TaskID);
                obj.Add("@UserNameId", objUserTask.LoginUserID);
                addTaskBO.dsResult = new Connection().GetData(spName, obj);
                return addTaskBO.dsResult;
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
        }
    }
}
