﻿using MySql.Data.MySqlClient;
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
                cmd.Parameters.Add(new MySqlParameter("@TeamId", addTask.TeamId));
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
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT c.*,p.* from client c inner join project p on p.ClientId=c.ClientId;");//Modified from project table select distinct p.* from task t inner join client c  " on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;
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


        public DataSet GetTeamName()
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT c.*,p.*,t.* from client c inner join project p on p.ClientId=c.ClientId inner join team t on t.ProjectId=p.ProjectId");
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


        public DataSet GetTeamNameByClient(TaskBusinessObject Team)
        {
            try
            {
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT c.*,p.*,t.* from client c inner join project p on p.ClientId=c.ClientId inner join team t on t.ProjectId=p.ProjectId where p.ProjectId="+ Team.ProjectID);
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

        public DataSet GetAssignedTask(TaskBusinessObject ObjectName)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "";
                Hashtable hashtable = new Hashtable();
                if (ObjectName.RoleID == 2)
                {
                    if (ObjectName.Designation == "Manager")
                    {
                        spName = "sp_GetManagerTaskByIDandRole";
                        hashtable.Add("@UserNames", ObjectName.LoginUserID);
                    }
                    else if(ObjectName.Designation == "TeamLeader")
                    {
                        spName = "sp_GetTLTaskByIDandRole";
                        hashtable.Add("@UserNames", ObjectName.LoginUserID);
                    }
                    else
                    {
                        spName = "sp_GetAllTask";
                    }
                    addTaskBO.dsResult = new Connection().GetData(spName, hashtable);
                }
                else
                {
                    spName = "sp_GetAllTask";
                    addTaskBO.dsResult = new Connection().GetData(spName, hashtable);
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


        public DataSet GetAllCreatedTask(TaskBusinessObject Task)
        {
            addTaskBO.dsResult.Reset();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "";
                Hashtable hashtable = new Hashtable();
                if (Task.RoleID == 1)
                {
                    spName = "sp_ViewCompletedandUnCompletedTask";//sp_GetAllCreatedTask
                }
                else
                {
                    if (Task.Designation == "Manager")
                    {
                        spName = "sp_ViewCompleteandAllTaskByManager";
                        hashtable.Add("@UserNames", Task.LoginUserID);
                    }
                    else if (Task.Designation == "TeamLeader")
                    {
                        spName = "sp_ViewCompletedandAllTaskByTL";
                        hashtable.Add("@UserNames", Task.LoginUserID);
                    }
                    else
                    {
                        spName = "sp_GetAllTask";//sp_GetAllCreatedTask
                    }
                }
                //addTaskBO.dsResult = new Connection().ExecuteSPWithoutID(spName);
                addTaskBO.dsResult = new Connection().GetData(spName, hashtable);
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

        public DataSet GetClients(TaskBusinessObject Client)
        {
            try
            {
                if (Client.RoleID == 1)
                {
                    addTaskBO.dsResult = new Connection().GetDataSetResults("select * from client;");//Modified from client table-- select distinct c.* from task t inner join client c " on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;
                }
                else
                {
                    if (Client.Designation == "Manager")
                    {
                        addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT distinct c.*,p.* FROM team_member tm inner join client c on tm.ClientId=c.ClientId inner join project p on p.ProjectId=tm.ProjectId where tm.RoleId=3 and tm.UserId=" + Client.LoginUserID);//Modified from client table-- select distinct c.* from task t inner join client c " on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;
                    }
                    else if(Client.Designation == "TeamLeader")
                    {
                        addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT distinct c.*, p.* FROM team_member tm inner join client c on tm.ClientId = c.ClientId inner join project p on p.ProjectId = tm.ProjectId where tm.RoleId = 4 and tm.UserId = " + Client.LoginUserID);//Modified from client table-- select distinct c.* from task t inner join client c " on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;
                    }
                    else
                    {
                        addTaskBO.dsResult = new Connection().GetDataSetResults("select * from client;");//Modified from client table-- select distinct c.* from task t inner join client c " on t.ClientId = c.ClientId inner join project p on p.ProjectId = t.ProjectId where t.IsActive != 0;
                    }
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

        //public DataSet GetProjectByClient(int objClientID)
        //{
        //    try
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        string spName = "GetProjectByClient";
        //        addTaskBO.dsResult = new Connection().ExecuteSP(spName, objClientID);
        //        return addTaskBO.dsResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        public DataSet GetProjectByClient(TaskBusinessObject objClientID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                addTaskBO.dsResult.Reset();
                string spName = "GetProjectByClient";
                Hashtable table = new Hashtable();
                table.Add("@ClientId", objClientID.ClientID);
                addTaskBO.dsResult = new Connection().GetData(spName, table);
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

        public DataSet ReAssignTask(TaskBusinessObject task)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_ReAssignTaskByID";
                Hashtable objhashtable = new Hashtable();
                objhashtable.Add("@TaskIdName", task.TaskID);
                addTaskBO.dsResult = new Connection().GetData(spName, objhashtable);
                return addTaskBO.dsResult;
                //MySqlCommand cmd = new MySqlCommand(spName, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //addTaskBO.dsResult = new Connection().ExecuteSPByTaskID(spName, taskID);
                //return addTaskBO.dsResult;
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


        public DataSet AssignTask(TaskBusinessObject task)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                addTaskBO.dsResult.Reset();
                string spName = "";
                Hashtable objhashtable = new Hashtable();
                if (task.StatusID == "5")
                {
                    spName = "sp_GetCompletedTask";
                }
                else
                {
                    spName = "sp_AssignTaskByID";
                }
                objhashtable.Add("@TaskIdName",task.TaskID);
                //MySqlCommand cmd = new MySqlCommand(spName, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //addTaskBO.dsResult = new Connection().ExecuteSPByTaskID(spName, task);
                addTaskBO.dsResult = new Connection().GetData(spName, objhashtable);
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
                //string spName = "sp_SearchAllTaskByUser";
                //Hashtable obj = new Hashtable();
                //obj.Add("@name", searchResult.SearchResult);
                //addTaskBO.dsResult = new Connection().GetData(spName, obj);
                //return addTaskBO.dsResult;
                string spName = "";
                Hashtable hashtable = new Hashtable();
                if (searchResult.RoleID == 2)
                {
                    if (searchResult.Designation == "Manager")
                    {
                        spName = "sp_SearchManagerTaskByIDandRole";
                        hashtable.Add("@UserNameID", searchResult.LoginUserID);
                        hashtable.Add("@name", searchResult.SearchResult);
                    }
                    else if (searchResult.Designation == "TeamLeader")
                    {
                        spName = "sp_SearchTLTaskByIDandRole";
                        hashtable.Add("@UserNameID", searchResult.LoginUserID);
                        hashtable.Add("@name", searchResult.SearchResult);
                    }
                    else
                    {
                        spName = "sp_SearchAllTaskByUser";
                    }
                    addTaskBO.dsResult = new Connection().GetData(spName, hashtable);
                }
                else
                {
                    spName = "sp_SearchAllTaskByUser";
                    addTaskBO.dsResult = new Connection().GetData(spName, hashtable);
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
                addTaskBO.dsResult.Reset();
                string spName = "";
                Hashtable obj = new Hashtable();
                if (objProjectuser.RoleID == 1)
                {
                    spName = "sp_GetTeamByProjectID";
                    obj.Add("@ProjectCheckID", objProjectuser.ProjectID);
                    obj.Add("@TeamIDName", objProjectuser.TeamId);
                }
                else if(objProjectuser.Designation == "Manager")
                {
                    spName = "sp_GetTeamByProjectID";
                    obj.Add("@ProjectCheckID", objProjectuser.ProjectID);
                    obj.Add("@TeamIDName", objProjectuser.TeamId);
                }
                else if(objProjectuser.Designation == "TeamLeader")
                {
                    spName = "sp_GetTeamByProjectIDForTL";
                    obj.Add("@ProjectCheckID", objProjectuser.ProjectID);
                    obj.Add("@TeamIDName", objProjectuser.TeamId);
                    obj.Add("@UserNameId", objProjectuser.LoginUserID);
                }
                else
                {
                    spName = "sp_GetTeamByProjectID";
                    obj.Add("@ProjectCheckID", objProjectuser.ProjectID);
                    obj.Add("@TeamIDName", objProjectuser.TeamId);
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
                addTaskBO.dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.team_member where UserId = " + teamMember.LoginUserID + " and ProjectId = " + teamMember.ProjectID + " and ClientId = " + teamMember.ClientID + " and ParrentTeamMemberId!=0 and Is_Active!=0");//and (RoleId=2 or RoleId=4) 
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
                string spName = "";
                Hashtable obj = new Hashtable();
                if (taskByUser.Designation == "TeamLeader")
                {
                    spName = "sp_GetTLAssignedUnassignedTask";
                }
                else
                {
                    spName = "sp_GetSelfAssignedUnassignedTaskByUser";
                }
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
                string spName = "";
                Hashtable obj = new Hashtable();
                if (taskStatus.RevisedEstimateTime == null)
                {
                    spName = "sp_InitialStartJob";
                    obj.Add("@UserCheckId", taskStatus.EmployeeName);
                    obj.Add("@TaskCheckID", taskStatus.TaskID);
                    obj.Add("@ProjectCheckID", Convert.ToInt32(taskStatus.ProjectID));
                    obj.Add("@ClientCheckID", Convert.ToInt32(taskStatus.ClientID));
                    obj.Add("@EstimatedTime", taskStatus.EstimateTime);
                }
                else
                {
                    spName = "sp_ReviseEstimatedTime";
                    obj.Add("@UserCheckId", taskStatus.EmployeeName);
                    obj.Add("@TaskCheckID", taskStatus.TaskID);
                    obj.Add("@ProjectCheckID", Convert.ToInt32(taskStatus.ProjectID));
                    obj.Add("@ClientCheckID", Convert.ToInt32(taskStatus.ClientID));
                    obj.Add("@RevisedEstimatedTime", taskStatus.RevisedEstimateTime);
                }
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
                addTaskBO.dsResult.Reset();
                Hashtable obj = new Hashtable();
                if (objUserTask.RoleID == 1)
                {
                    string spName = "sp_GetUserTaskTime";
                    obj.Add("@TaskNameID", objUserTask.TaskID);
                    addTaskBO.dsResult = new Connection().GetData(spName, obj);
                }
                else
                {
                    string spName = "";
                    if (objUserTask.Designation == "Manager")
                    {
                        spName = "sp_GetUserTaskTime";
                        obj.Add("@TaskNameID", objUserTask.TaskID);
                    }
                    else if (objUserTask.Designation == "TeamLeader")
                    {
                        spName = "sp_GetUserTaskTime";
                        obj.Add("@TaskNameID", objUserTask.TaskID);
                    }
                    else
                    {
                        spName = "sp_GetUserTaskTimeForUser";
                        obj.Add("@TaskNameID", objUserTask.TaskID);
                        obj.Add("@UserIDName", objUserTask.LoginUserID);
                    }
                    //obj.Add("@TaskNameID", objUserTask.TaskID);
                    //obj.Add("@UserIDName", objUserTask.LoginUserID);
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
                    string spName = "";
                    if (Task.RoleID == 1)
                    {
                        spName = "sp_SearchDateWise";
                    }
                    else
                    {
                        if (Task.Designation == "Manager")
                        {
                            spName = "sp_SearchinViewTaskByManager";
                        }
                        else if (Task.Designation == "TeamLeader")
                        {
                            spName = "sp_SearchinAllTaskByTL";
                        }
                        else
                        {
                            spName = "sp_SearchByDateWiseforUser";
                        }
                        
                    }
                    DateTime startdate = Convert.ToDateTime(Task.StartDate);
                    DateTime enddate = Convert.ToDateTime(Task.EndDate);
                    startTime = startdate.ToString("yyyy-MM-dd");
                    endTime = enddate.ToString("yyyy-MM-dd");
                    hashtable.Add("@StartingTime", startTime);
                    hashtable.Add("@EndingTime", endTime);
                    hashtable.Add("@Stringname", Task.SearchResult);
                    if (Task.RoleID != 1)
                    {
                        hashtable.Add("@UserNameID", Task.EmployeeName);
                    }
                    Task.dsResult = new Connection().GetData(spName, hashtable);
                }                
                else
                {
                    string spName = "";
                    if (Task.RoleID == 1)
                    {
                        spName = "sp_SearchDateWise";
                    }
                    else
                    {
                        if (Task.Designation == "Manager")
                        {
                            spName = "sp_SearchinViewTaskByManager";
                        }
                        else if (Task.Designation == "TeamLeader")
                        {
                            spName = "sp_SearchinAllTaskByTL";
                        }
                        else
                        {
                            spName = "sp_SearchByDateWiseforUser";
                        }
                    }
                    hashtable.Add("@StartingTime", startTime);
                    hashtable.Add("@EndingTime", endTime);
                    hashtable.Add("@Stringname", Task.SearchResult);
                    if (Task.RoleID != 1)
                    {
                        hashtable.Add("@UserNameID", Task.EmployeeName);
                    }
                    Task.dsResult = new Connection().GetData(spName, hashtable);
                }
                return Task.dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
