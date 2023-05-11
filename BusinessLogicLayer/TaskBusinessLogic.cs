using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using DataAccessLayer;
using BusinessLogicLayer.Interface;
using System.Data;
using DataAccessLayer.Interface;
using System.Globalization;

namespace BusinessLogicLayer
{
    public class TaskBusinessLogic : ITaskBusinessLogic
    {
        private ITaskDataAccess _dataAccess;
        TaskBusinessObject taskBO = new TaskBusinessObject();
        public TaskBusinessLogic(ITaskDataAccess taskDAL)
        {
            _dataAccess = taskDAL;
        }


        /// <summary>
        /// This commented code is used for Interface implementation without DI.
        /// </summary>
        /// <param name="objTask"></param>

        //int ITaskBLL.InsertTaskDetails(TaskBusinessObjectLayer addTask)
        //{
        //    string sproc = "";
        //    int dtResult = taskDataAccessLayer.InsertTaskDetails(addTask, sproc);
        //    return dtResult;
        //}

        public int InsertTaskDetails(TaskBusinessObject objTask)
        {
            taskBO.response = _dataAccess.InsertTaskDetails(objTask);
            return taskBO.response;
        }

        public int UpdateTaskDetails(TaskBusinessObject objTask)
        {
            taskBO.response = _dataAccess.UpdateTaskDetails(objTask);
            return taskBO.response;
        }

        public DataSet GetAllClients(TaskBusinessObject Client)
        {
            taskBO.dsResult = _dataAccess.GetClients(Client);
            return taskBO.dsResult;
        }

        public DataSet GetAllProject()
        {
            taskBO.dsResult = _dataAccess.GetProject();
            return taskBO.dsResult;
        }


        public DataSet GetAllTeam()
        {
            taskBO.dsResult = _dataAccess.GetTeamName();
            return taskBO.dsResult;
        }

       

        public DataSet GetStatusName()
        {
            taskBO.dsResult = _dataAccess.GetStatusName();
            return taskBO.dsResult;
        }

        public DataSet GetAssignedTask(TaskBusinessObject ObjectName)
        {
            taskBO.dsResult = _dataAccess.GetAssignedTask(ObjectName);
            return taskBO.dsResult;
        }


        public DataSet GetAllCreatedTask(TaskBusinessObject Task)
        {
            taskBO.dsResult = _dataAccess.GetAllCreatedTask(Task);
            return taskBO.dsResult;
        }

        public DataSet GetTaskDetails()
        {
            taskBO.dsResult = _dataAccess.GetTaskDetails();
            return taskBO.dsResult;
        }

        //public DataSet GetProjectByClient(int clientID)
        //{
        //    taskBO.dsResult = _dataAccess.GetProjectByClient(clientID);
        //    return taskBO.dsResult;
        //}

        public DataSet GetProjectByClient(TaskBusinessObject clientID)
        {
            taskBO.dsResult = _dataAccess.GetProjectByClient(clientID);
            return taskBO.dsResult;
        }

        public DataSet ReAssignTask(TaskBusinessObject task)
        {
            taskBO.dsResult = _dataAccess.ReAssignTask(task);
            return taskBO.dsResult;
        }

        public int InsertAssignedTaskDetails(TaskBusinessObject assignTask)
        {
            taskBO.response = _dataAccess.InsertAssignedTaskDetails(assignTask);
            return taskBO.response;
        }

        public DataSet AssignTask(TaskBusinessObject task)
        {
            taskBO.dsResult = _dataAccess.AssignTask(task);
            return taskBO.dsResult;
        }

        public int UpdateAssignedTaskDetails(TaskBusinessObject assignTask)
        {
            taskBO.response = _dataAccess.UpdateAssignedTaskDetails(assignTask);
            return taskBO.response;
        }

        public DataSet SearchResult(TaskBusinessObject projectID)
        {
            taskBO.dsResult = _dataAccess.SearchResult(projectID);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByClient(TaskBusinessObject ClientID)
        {
            taskBO.dsResult = _dataAccess.SearchResultByClient(ClientID);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByProject(TaskBusinessObject ProjectID)
        {
            taskBO.dsResult = _dataAccess.SearchResultByProject(ProjectID);
            return taskBO.dsResult;
        }


        public DataSet SearchResultByClientID(TaskBusinessObject ClientID)
        {
            taskBO.dsResult = _dataAccess.SearchResultByClient(ClientID);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByProjectID(TaskBusinessObject ProjectID)
        {
            taskBO.dsResult = _dataAccess.SearchResultByProject(ProjectID);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByStatus(TaskBusinessObject StatusID)
        {
            taskBO.dsResult = _dataAccess.SearchResultByStatus(StatusID);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByUser(TaskBusinessObject User)
        {
            taskBO.dsResult = _dataAccess.SearchResultByUser(User);
            return taskBO.dsResult;
        }

        public DataSet SearchResultByDate(TaskBusinessObject objDate)
        {
            taskBO.dsResult = _dataAccess.SearchResultByDate(objDate);
            return taskBO.dsResult;
        }

        public DataSet GetAllUsers(TaskBusinessObject objProjectUser)
        {
            taskBO.dsResult = _dataAccess.GetAllUsers(objProjectUser);
            return taskBO.dsResult;
        }

        public int InsertChatDetails(TaskBusinessObject Chat)
        {
            taskBO.response = _dataAccess.InsertChatDetails(Chat);
            return taskBO.response;
        }

        public DataSet GetChatDetails(TaskBusinessObject Chat)
        {
            taskBO.dsResult = _dataAccess.GetChatDetails(Chat);
            DataTable dt = taskBO.dsResult.Tables[0];
            dt.Columns.Add("Abbriviation", typeof(string));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string abbreviation = new string(
    dt.Rows[i]["UserName"].ToString().Split()
          .Where(s => s.Length > 0 && char.IsLetter(s[0]) && char.IsUpper(s[0]))
          .Take(3)
          .Select(s => s[0])
          .ToArray());
                dt.Rows[i]["Abbriviation"] = abbreviation;
            }
            return taskBO.dsResult;
        }

        public DataSet GetTeamMemberID(TaskBusinessObject teammember)
        {
            taskBO.dsResult = _dataAccess.GetTeamMemberID(teammember);
            return taskBO.dsResult;
        }

        public int InsertUserAssignedTask(TaskBusinessObject assignUserTask)
        {
            taskBO.response = _dataAccess.InsertUserAssignedTask(assignUserTask);
            return taskBO.response;
        }

        public DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser)
        {
            taskBO.dsResult = _dataAccess.GetAllCreatedTaskByUser(taskByUser);
            return taskBO.dsResult;
        }

        public int UpdateUserTaskStatus(TaskBusinessObject taskStatus)
        {
            taskBO.response = _dataAccess.UpdateUserTaskStatus(taskStatus);
            return taskBO.response;
        }

        public int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus)
        {
            taskBO.response = _dataAccess.UpdateUserTaskStatusPause(taskStatus);
            return taskBO.response;
        }

        public DataSet TaskBugHistory(TaskBusinessObject taskStatus)
        {
            taskBO.dsResult = _dataAccess.TaskBugHistory(taskStatus);
            return taskBO.dsResult;
        }

        public DataSet UserTaskTime(TaskBusinessObject user)
        {
            taskBO.dsResult = _dataAccess.UserTaskTime(user);
            DataTable dt = taskBO.dsResult.Tables[0];
            dt.Columns.Add("Pause", typeof(DateTime));
            dt.Columns.Add("Resume", typeof(DateTime));
            dt.Columns.Add("Break", typeof(int));
            string startDate = "";
            string startTime = "";
            string userName = "";
            CultureInfo ci = CultureInfo.InvariantCulture;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Description"].ToString() != "")
                {
                    dt.Rows[i]["Pause"] = Convert.ToDateTime(dt.Rows[i]["EndTime"].ToString());
                    if (Convert.ToDateTime(dt.Rows[i]["StartDate"].ToString()).ToShortDateString() == startDate && dt.Rows[i]["UserName"].ToString() == userName)
                    {
                        dt.Rows[i]["StartDate"] = DBNull.Value;
                        dt.Rows[i]["StartTime"] = DBNull.Value;
                        dt.Rows[i]["UserName"] = DBNull.Value;
                    }
                    else
                    {
                        startDate = Convert.ToDateTime(dt.Rows[i]["StartDate"].ToString()).ToShortDateString();
                        startTime = Convert.ToDateTime(dt.Rows[i]["StartTime"].ToString()).ToShortTimeString();
                        userName = dt.Rows[i]["UserName"].ToString();
                    }
                    if (i < (dt.Rows.Count - 1))
                    {
                        if (startDate == Convert.ToDateTime(dt.Rows[i + 1]["StartDate"].ToString()).ToShortDateString() && userName == dt.Rows[i + 1]["UserName"].ToString())
                        {
                            dt.Rows[i]["Resume"] = Convert.ToDateTime(dt.Rows[i + 1]["StartTime"].ToString());
                            DateTime resume = Convert.ToDateTime(dt.Rows[i]["Resume"].ToString());
                            DateTime pause = Convert.ToDateTime(dt.Rows[i]["Pause"].ToString());
                            TimeSpan diffbreak = resume.Subtract(pause);
                            int hour = diffbreak.Hours;
                            int minutes = hour * 60;
                            int min = diffbreak.Minutes;
                            dt.Rows[i]["Break"] = min + minutes;
                            if (dt.Rows[i]["Status"] != DBNull.Value)
                            {
                                dt.Rows[i]["Description"] = DBNull.Value;
                            }
                        }
                        else
                        {
                            //  DateTime pause = Convert.ToDateTime(dt.Rows[i]["Pause"].ToString());
                            if (dt.Rows[i]["Status"] != DBNull.Value)
                            {
                                dt.Rows[i]["Description"] = DBNull.Value;
                            }
                        }
                    }
                    if (i == (dt.Rows.Count - 1) && dt.Rows[i]["Status"] != DBNull.Value)
                    {
                        dt.Rows[i]["Description"] = DBNull.Value;
                    }
                }
            }
            return taskBO.dsResult;
        }

        public int DeleteTaskDetails(TaskBusinessObject addTask)
        {
            taskBO.response = _dataAccess.DeleteTaskDetails(addTask);
            return taskBO.response;
        }

        public DataSet GetTaskDetailsByTask(TaskBusinessObject Task)
        {
            taskBO.dsResult = _dataAccess.GetTaskDetailsByTask(Task);
            return taskBO.dsResult;
        }

        public DataSet SearchTask(TaskBusinessObject Task)
        {
            taskBO.dsResult = _dataAccess.SearchTask(Task);
            return taskBO.dsResult;
        }

        public DataSet GetAllTeamByClient(TaskBusinessObject Team)
        {
            taskBO.dsResult = _dataAccess.GetTeamNameByClient(Team);
            return taskBO.dsResult;
        }
     }
}
