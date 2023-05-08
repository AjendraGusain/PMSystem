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
        int DeleteTaskDetails(TaskBusinessObject task);
        int UpdateTaskDetails(TaskBusinessObject task);
        int InsertChatDetails(TaskBusinessObject Chat);
        DataSet GetClients();
        DataSet GetTaskDetailsByTask(TaskBusinessObject Task);
        DataSet GetTeamMemberID(TaskBusinessObject teamMember);
        DataSet GetProject();
        DataSet GetStatusName();
        DataSet GetAssignedTask(TaskBusinessObject taskByUser);
        DataSet GetAllCreatedTask(TaskBusinessObject Task);
        DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser);
        int UpdateUserTaskStatus(TaskBusinessObject taskStatus);
        int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus);
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);
        DataSet GetAllUsers(TaskBusinessObject objProjectuser);
        DataSet GetChatDetails(TaskBusinessObject Chat);
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
        DataSet SearchResult(TaskBusinessObject searchResult);
        DataSet SearchResultByClient(TaskBusinessObject searchResult);
        DataSet SearchResultByProject(TaskBusinessObject searchResult);
        DataSet SearchResultByClientID(TaskBusinessObject searchResult);
        DataSet SearchResultByProjectID(TaskBusinessObject searchResult);
        DataSet SearchResultByStatus(TaskBusinessObject searchResult);
        DataSet SearchResultByUser(TaskBusinessObject searchResult);
        DataSet SearchResultByDate(TaskBusinessObject searchResult);
        DataSet UserTaskTime(TaskBusinessObject objUserTask);
        DataSet TaskBugHistory(TaskBusinessObject objUserTask);
        DataSet SearchTask(TaskBusinessObject Task);
    }
}
