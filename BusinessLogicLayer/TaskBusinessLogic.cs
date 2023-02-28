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


        public DataSet GetAssignedTask()
        {
            taskBO.dsResult = _dataAccess.GetAssignedTask();
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
            taskBO.dsResult = _dataAccess.AssignTask(taskID);
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

        public DataSet SearchResultByUser(TaskBusinessObject User)
        {
            taskBO.dsResult = _dataAccess.SearchResultByUser(User);
            return taskBO.dsResult;
        }
    }
}
