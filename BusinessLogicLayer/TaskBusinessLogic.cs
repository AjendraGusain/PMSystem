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
            taskBO.response= _dataAccess.InsertTaskDetails(objTask);
            return taskBO.response;
        }

        public DataSet GetAllClients()
        {
            taskBO.dsResult = _dataAccess.GetClients();
            return taskBO.dsResult;
        }

        public DataSet GetAllProject()
        {
            taskBO.dsResult = _dataAccess.GetProject();
            return taskBO.dsResult;
        }

        public DataSet GetStatusName()
        {
            taskBO.dsResult = _dataAccess.GetStatusName();
            return taskBO.dsResult;
        }

        public DataSet GetAssignedTask()
        {
            taskBO.dsResult = _dataAccess.GetAssignedTask();
            return taskBO.dsResult;
        }


        public DataSet GetAllCreatedTask()
        {
            taskBO.dsResult = _dataAccess.GetAllCreatedTask();
            return taskBO.dsResult;
        }

        public DataSet GetTaskDetails()
        {
            taskBO.dsResult = _dataAccess.GetTaskDetails();
            return taskBO.dsResult;
        }

        public DataSet GetProjectByClient(int clientID)
        {
            taskBO.dsResult = _dataAccess.GetProjectByClient(clientID);
            return taskBO.dsResult;
        }

        public DataSet ReAssignTask(int taskID)
        {
            taskBO.dsResult = _dataAccess.ReAssignTask(taskID);
            return taskBO.dsResult;
        }

        public int InsertAssignedTaskDetails(TaskBusinessObject assignTask)
        {
            taskBO.response = _dataAccess.InsertAssignedTaskDetails(assignTask);
            return taskBO.response;
        }

        public DataSet AssignTask(int taskID)
        {
            //DataSet dsFilter = new DataSet();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Pause");
            //dt.Columns.Add("Resume");
            //dt.Columns.Add("Break");
            
            taskBO.dsResult = _dataAccess.AssignTask(taskID);
            //for (int i = 0; i < taskBO.dsResult.Tables[0].Rows.Count; i++)
            //{
            //    if (taskBO.dsResult.Tables[0].Rows[i]["Description"].ToString() != "")
            //    {
            //        dt.Rows[i]["Pause"] = taskBO.dsResult.Tables[0].Rows[i]["EndTime"].ToString();
            //        dt.Rows[i]["Resume"] = taskBO.dsResult.Tables[0].Rows[i+1]["StartTime"].ToString();
            //    }
            //}
            
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

        public DataSet GetChatDetails()
        {
            taskBO.dsResult = _dataAccess.GetChatDetails();
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

        public DataSet UserTaskTime(TaskBusinessObject user)
        {
             DataSet dsFilter = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Pause");
            dt.Columns.Add("Resume");
            dt.Columns.Add("Break");

            taskBO.dsResult = _dataAccess.UserTaskTime(user);
            //foreach (var i in taskBO.dsResult.Tables[0].Rows.Count)
            //{
            //    if (taskBO.dsResult.Tables[0].Rows[i]["Description"].ToString() != "")
            //    {
            //        dt.Rows[i]["Pause"] = taskBO.dsResult.Tables[0].Rows[i]["EndTime"].ToString();
            //        dt.Rows[i]["Resume"] = taskBO.dsResult.Tables[0].Rows[i + 1]["StartTime"].ToString();
            //    }
            //}
            return taskBO.dsResult;
        }
    }
}
