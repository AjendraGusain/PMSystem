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

        int InsertUserAssignedTask(TaskBusinessObject assignUserTask);
        int UpdateAssignedTaskDetails(TaskBusinessObject assignTask);
        int InsertTaskDetails(TaskBusinessObject task);
        int InsertChatDetails(TaskBusinessObject Chat);
        DataSet GetClients();
        DataSet GetTeamMemberID(TaskBusinessObject teamMember);
        DataSet GetProject();

        DataSet GetStatusName();
        DataSet GetAssignedTask();
        DataSet GetAllCreatedTask();
        DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser);

        int UpdateUserTaskStatus(TaskBusinessObject taskStatus);

        int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus);

        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);

        DataSet GetAllUsers(TaskBusinessObject objProjectuser);
        DataSet GetChatDetails();
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
        DataSet SearchResult(TaskBusinessObject searchResult);
        DataSet SearchResultByClient(TaskBusinessObject searchResult);
        DataSet SearchResultByProject(TaskBusinessObject searchResult);

        DataSet SearchResultByStatus(TaskBusinessObject searchResult);
        DataSet SearchResultByUser(TaskBusinessObject searchResult);
        DataSet SearchResultByDate(TaskBusinessObject searchResult);

        DataSet UserTaskTime(TaskBusinessObject objUserTask);

    }
}
