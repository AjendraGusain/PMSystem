using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
namespace DataAccessLayer.Interface
{
   public interface ITaskDataAccess
    {
        int InsertAssignedTaskDetails(TaskBusinessObject assignTask);
        int UpdateAssignedTaskDetails(TaskBusinessObject assignTask);
        int InsertTaskDetails(TaskBusinessObject task);
        DataSet GetClients();
        DataSet GetProject();
        DataSet GetAssignedTask();
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
    }
}
