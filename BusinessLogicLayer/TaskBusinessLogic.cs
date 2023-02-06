using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using DataAccessLayer;
using BusinessLogicLayer.Interface;
using System.Data;

namespace BusinessLogicLayer
{
    public class TaskBusinessLogicLayer : ITaskBLL
    {
        TaskDataAccessLayer taskDataAccessLayer = new TaskDataAccessLayer();

        int ITaskBLL.InsertTaskDetails(TaskBusinessObjectLayer addTask)
        {
            string sproc = "";
            int dtResult = taskDataAccessLayer.InsertTaskDetails(addTask, sproc);
            return dtResult;
        }

        public DataSet GetAllClients()
        {
            DataSet dtResult = taskDataAccessLayer.GetClient();
            return dtResult;
        }

        public DataSet GetAllProject()
        {
            DataSet dtResult = taskDataAccessLayer.GetProject();
            return dtResult;
        }


        public DataSet GetAssignedTask()
        {
            DataSet dtResult = taskDataAccessLayer.GetAssignedTask();
            return dtResult;
        }

        public DataSet GetTaskDetails()
        {
            DataSet dtResult = taskDataAccessLayer.GetTaskDetails();
            return dtResult;
        }

        public DataSet GetProjectByClient(int clientID)
        {
            DataSet dtResult = taskDataAccessLayer.GetProjectByClient(clientID);
            return dtResult;
        }
    }
}
