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
using System.Globalization;

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
                cmd.Parameters.Add(new MySqlParameter("@UserID", addTask.LoginUserID));
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
                addTaskBO.dsResult = new Connection().GetDataSetResults("select distinct p.* from task t inner join client c  " +
                    "on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;");//Modified from project table
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
            addTaskBO.dsResult.Reset();
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
                addTaskBO.dsResult = new Connection().GetDataSetResults("select distinct c.* from task t inner join client c " +
                    "on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0; ");//Modified from client table
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
                string dsResult = "insert  into ProjectManagementNew.user_task(UserId,TeamMemberId,TaskId,AssignedByUserID,AssignedDate,ProjectId,IsActive,TeamId) values(@UserId,@TeamMemberId, @TaskId,@AssignedByUserID,@AssignedDate,@ProjectId,'1',@TeamId);  Update ProjectManagementNew.task set StatusID=2 where TaskId=" + assignTask.TaskID + " and ProjectId=" + assignTask.ProjectID;
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UserId", assignTask.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@TeamMemberId", assignTask.TeamMemberID));
                cmd.Parameters.Add(new MySqlParameter("@TaskId", assignTask.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedByUserID", assignTask.LoginUserID));
                cmd.Parameters.Add(new MySqlParameter("@AssignedDate", assignTask.AssignedDate));
                cmd.Parameters.Add(new MySqlParameter("@ProjectId", Convert.ToInt32(assignTask.ProjectID)));
                cmd.Parameters.Add(new MySqlParameter("@TeamId", Convert.ToInt32(assignTask.TeamId)));
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
                    "UnassignedDate=@UnassignedDate,IsActive='0',StatusId=7 where TaskId=" + assignTask.TaskID + " and ProjectId="
                    + assignTask.ProjectID + " and TeamMemberId=" + assignTask.TeamMemberID;
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UnassignedByUserID", assignTask.LoginUserID));
                cmd.Parameters.Add(new MySqlParameter("@UnassignedDate", assignTask.AssignedDate));
                assignTask.response = cmd.ExecuteNonQuery();
                //string spName = "sp_ReassignTaskByTeamMemberID";
                //Hashtable obj = new Hashtable();
                //obj.Add("@UserCheckId", assignTask.EmployeeName);
                //obj.Add("@TaskCheckID", assignTask.TaskID);
                //obj.Add("@UnassignedByUser", assignTask.LoginUserID);
                //obj.Add("@ProjectCheckID", assignTask.ProjectID);
                //obj.Add("@TeamMemberID", assignTask.TeamMemberID);
              //  addTaskBO.response = new Connection().InsertEntry(spName, false, obj);
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

        public DataSet SearchResultByClientID(TaskBusinessObject searchResult)
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

        public DataSet SearchResultByProjectID(TaskBusinessObject searchResult)
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

        public DataSet GetChatDetails(TaskBusinessObject Chat)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetChatHistory";
                Hashtable obj = new Hashtable();
                obj.Add("@TaskChatID", Chat.TaskID);
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

        public DataSet GetTeamMemberID(TaskBusinessObject teamMember)
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.team_member where UserId = " + teamMember.LoginUserID + " and ProjectId = " + teamMember.ProjectID + " and ClientId = " + teamMember.ClientID + " and (RoleId=2 or RoleId=4) and ParrentTeamMemberId!=0");
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
                string spName = "sp_GetSelfAssignedUnassignedTaskByUser";
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
                    taskStatus.PauseReasonStatus.Contains("Ready for Test") ||taskStatus.PauseReasonStatus.Contains("Reassign"))
                {
                    string spName = "sp_PauseReasonStatusJob";
                    Hashtable obj = new Hashtable();
                    obj.Add("@UserCheckId", taskStatus.EmployeeName);
                    obj.Add("@TaskCheckID", taskStatus.TaskID);
                    obj.Add("@PauseReasonStatus", taskStatus.PauseReasonStatus);
                    addTaskBO.response = new Connection().InsertEntry(spName, false, obj);
                }
                else
                {
                    string dsResult = "insert  into ProjectManagementNew.user_task_Bug (UserId,Date,BugDescription,TaskId) values(@UserId,Now(), @PauseReasonStatus,@UserTaskID);";
                    MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                    cmd.Parameters.Add(new MySqlParameter("@UserId", taskStatus.EmployeeName));
                    cmd.Parameters.Add(new MySqlParameter("@UserTaskID", taskStatus.TaskID));
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
                if (objUserTask.RoleID == 1)
                {
                    addTaskBO.dsResult.Reset();
                    string spName = "sp_GetUserTaskTime";
                    Hashtable obj = new Hashtable();
                    obj.Add("@TaskNameID", objUserTask.TaskID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
                else
                {
                    addTaskBO.dsResult.Reset();
                    string spName = "sp_GetUserTaskTimeForUser";
                    Hashtable obj = new Hashtable();
                    obj.Add("@TaskNameID", objUserTask.TaskID);
                    obj.Add("@UserIDName", objUserTask.LoginUserID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
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
                //obj.Add("@UserNameId", objUserTask.LoginUserID);
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

        public int UpdateTaskDetails(TaskBusinessObject task)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_UpdateCreatedTask";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TaskNameID", task.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@ClientNameID", task.ClientID));
                cmd.Parameters.Add(new MySqlParameter("@ProjectNameID", task.ProjectID));
                cmd.Parameters.Add(new MySqlParameter("@TaskNumberName", task.TaskNumber));
                cmd.Parameters.Add(new MySqlParameter("@TaskNames", task.TaskName));
                cmd.Parameters.Add(new MySqlParameter("@TaskDescriptions", task.TaskDescription));
                task.response = cmd.ExecuteNonQuery();
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
            return task.response;
        }

        public int DeleteTaskDetails(TaskBusinessObject task)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_DeleteCreatedTask";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TaskNameID", task.TaskID));
                cmd.Parameters.Add(new MySqlParameter("@ClientNameID", task.ClientID));
                cmd.Parameters.Add(new MySqlParameter("@ProjectNameID", task.ProjectID));
                task.response = cmd.ExecuteNonQuery();
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
            return task.response;
        }

        public DataSet SearchResultByClient(TaskBusinessObject searchResult)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                Hashtable obj = new Hashtable();
                if (searchResult.RoleID == 1)
                {
                    string spName = "sp_SearchAllTaskByClientForAdmin";
                    obj.Add("@ClientCheckID", searchResult.ClientID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
                else
                {
                    string spName = "sp_SearchAllTaskByClientID";
                    obj.Add("@ClientCheckID", searchResult.ClientID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }

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
                Hashtable obj = new Hashtable();
                if (searchResult.RoleID == 1)
                {
                    string spName = "sp_SearchAllTaskByProjectForAdmin";
                    obj.Add("@ProjectCheckID", searchResult.ProjectID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
                else
                {
                    string spName = "sp_SearchAllTaskByProjectID";
                    obj.Add("@ProjectCheckID", searchResult.ProjectID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
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

        public DataSet GetTaskDetailsByTask(TaskBusinessObject Task)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetTaskbyTaskID";
                Hashtable obj = new Hashtable();
                obj.Add("@CheckTaskID", Task.TaskID);
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

        public DataSet SearchTask(TaskBusinessObject Task)
        {
            try
            {
                string startTime = "0";
                string endTime = "0";
                Hashtable hashtable = new Hashtable();
                if (Task.StartDate.ToString()!="" || Task.EndDate.ToString() != "")
                {
                    string spName = "sp_SearchDateWise";
                    DateTime startdate = Convert.ToDateTime(Task.StartDate.ToString());
                    DateTime enddate = Convert.ToDateTime(Task.EndDate);
                    startTime = startdate.ToString("yyyy-MM-dd");
                    endTime = enddate.ToString("yyyy-MM-dd");
                    hashtable.Add("@StartingTime", startTime);
                    hashtable.Add("@EndingTime", endTime);
                    hashtable.Add("@Stringname", Task.SearchResult);
                    Task.dsResult = new Connection().GetData(spName, hashtable);
                }                
                else
                {
                    string spName = "sp_SearchDateWise";
                    hashtable.Add("@StartingTime", startTime);
                    hashtable.Add("@EndingTime", endTime);
                    hashtable.Add("@Stringname", Task.SearchResult);
                    Task.dsResult = new Connection().GetData(spName, hashtable);
                }
                //if (!string.IsNullOrEmpty(Task.SearchResult))
                //{
                //    query += " AND (p.ProjectName like '%" + Task.SearchResult + "%' or t.TaskNumber like '%" + Task.SearchResult + "%' or t.TaskName like '%" 
                //        + Task.SearchResult + "%' or t.StartTime like '%" + Task.SearchResult + "%' or t.EndTime like '%" 
                //        + Task.SearchResult + "%' or u.UserName like '%" + Task.SearchResult + "%' or s.StatusName like '%" + Task.SearchResult + "%'); ";
                //}
                //if (!string.IsNullOrEmpty(Task.StartDate.ToShortTimeString()) && !string.IsNullOrEmpty(Task.EndDate.ToShortTimeString()))
                //{
                //    query += " AND t.StartTime = '" + Task.StartDate + "' AND t.EndTime = '" + Task.EndDate + "'";
                //}
                //else if (!string.IsNullOrEmpty(Task.StartDate.ToShortTimeString()))
                //{
                //    query += " AND t.StartTime = '" + Task.StartDate + "'";
                //}
                //else if (!string.IsNullOrEmpty(Task.EndDate.ToShortTimeString()))
                //{
                //    query += " AND t.EndTime = '" + Task.EndDate + "'";
                //}
                return Task.dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
