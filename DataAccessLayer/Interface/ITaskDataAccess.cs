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
        int InsertChatDetails(TaskBusinessObject Chat);
        DataSet GetClients();
        DataSet GetProject();
        DataSet GetAssignedTask();
        DataSet GetAllCreatedTask();
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);

        DataSet GetAllUsers(TaskBusinessObject objProjectuser);
        DataSet GetChatDetails();
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
        DataSet SearchResult(TaskBusinessObject searchResult);
        DataSet SearchResultByClient(TaskBusinessObject searchResult);
        DataSet SearchResultByProject(TaskBusinessObject searchResult);
        DataSet SearchResultByUser(TaskBusinessObject searchResult);
    }
}
