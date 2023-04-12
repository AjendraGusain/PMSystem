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
        int InsertUserAssignedTask(TaskBusinessObject assignUserTask);
        int UpdateAssignedTaskDetails(TaskBusinessObject assignTask);
        int InsertTaskDetails(TaskBusinessObject addTask);

        int DeleteTaskDetails(TaskBusinessObject addTask);
        int UpdateTaskDetails(TaskBusinessObject addTask);
        int InsertChatDetails(TaskBusinessObject Chat);
        DataSet GetAllClients();
        DataSet GetAllUsers(TaskBusinessObject objProjectUsers);
        DataSet GetChatDetails(TaskBusinessObject chat);
        DataSet GetAllProject();
        DataSet GetStatusName();
        DataSet GetAssignedTask();
        DataSet GetTeamMemberID(TaskBusinessObject teammember);
        DataSet GetAllCreatedTask();
        DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser);
        int UpdateUserTaskStatus(TaskBusinessObject taskStatus);
        int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus);
        DataSet GetTaskDetails();
        DataSet GetProjectByClient(int objClientID);
        DataSet ReAssignTask(int taskID);
        DataSet AssignTask(int taskID);
        DataSet SearchResult(TaskBusinessObject projectID);
        DataSet SearchResultByClient(TaskBusinessObject ClientID);
        DataSet SearchResultByProject(TaskBusinessObject ProjectID);

        DataSet SearchResultByClientID(TaskBusinessObject ClientID);
        DataSet SearchResultByProjectID(TaskBusinessObject ProjectID);

        DataSet SearchResultByStatus(TaskBusinessObject StatusID);
        DataSet SearchResultByUser(TaskBusinessObject User);
        DataSet SearchResultByDate(TaskBusinessObject objDate);

        DataSet UserTaskTime(TaskBusinessObject user);

        DataSet TaskBugHistory(TaskBusinessObject user);

    }
}
