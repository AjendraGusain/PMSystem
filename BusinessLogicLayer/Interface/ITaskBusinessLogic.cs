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
        int InsertAssignedTaskDetails(TaskBusinessObject assignTask);
        int UpdateAssignedTaskDetails(TaskBusinessObject assignTask);
        int InsertTaskDetails(TaskBusinessObject addTask);
        DataSet GetAllClients();
        DataSet GetAllProject();
        DataSet GetAssignedTask();
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
        DataSet SearchResult(TaskBusinessObject projectID);
        DataSet SearchResultByClient(TaskBusinessObject ClientID);
        DataSet SearchResultByProject(TaskBusinessObject ProjectID);
        DataSet SearchResultByUser(TaskBusinessObject User);

    }
}
