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
            objTask.response= _dataAccess.InsertTaskDetails(objTask);
            return objTask.response;
        }

        public DataSet GetAllClients()
        {
            DataSet dtResult = _dataAccess.GetClients();
            return dtResult;
        }

        public DataSet GetAllProject()
        {
            DataSet dtResult = _dataAccess.GetProject();
            return dtResult;
        }


        public DataSet GetAssignedTask()
        {
            DataSet dtResult = _dataAccess.GetAssignedTask();
            return dtResult;
        }

        public DataSet GetTaskDetails()
        {
            DataSet dtResult = _dataAccess.GetTaskDetails();
            return dtResult;
        }

        public DataSet GetProjectByClient(int clientID)
        {
            DataSet dtResult = _dataAccess.GetProjectByClient(clientID);
            return dtResult;
        }
    }
}
