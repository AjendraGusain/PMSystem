using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
namespace BusinessLogicLayer.Interface
{
    public interface ITaskBusinessLogic
    {
        int InsertTaskDetails(TaskBusinessObject addTask);
        DataSet GetAllClients();
        DataSet GetAllProject();
        DataSet GetAssignedTask();
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);
        DataSet GetTaskDetailsByID(int taskID);
    }
}
