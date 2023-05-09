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
        DataSet GetAllClients(TaskBusinessObject Client);
        DataSet GetAllUsers(TaskBusinessObject objProjectUsers);
        DataSet GetChatDetails(TaskBusinessObject chat);
        DataSet GetAllProject();
        DataSet GetAllTeam();

        DataSet GetAllTeamByClient(TaskBusinessObject Team);
        DataSet GetStatusName();
        DataSet GetAssignedTask(TaskBusinessObject ObjectName);
        DataSet GetTeamMemberID(TaskBusinessObject teammember);
        DataSet GetAllCreatedTask(TaskBusinessObject Task);
        DataSet GetAllCreatedTaskByUser(TaskBusinessObject taskByUser);
        int UpdateUserTaskStatus(TaskBusinessObject taskStatus);
        int UpdateUserTaskStatusPause(TaskBusinessObject taskStatus);
        DataSet GetTaskDetails();
        DataSet GetTaskDetailsByTask(TaskBusinessObject Task);
        //DataSet GetProjectByClient(int objClientID);
        DataSet GetProjectByClient(TaskBusinessObject objClientID);
        DataSet ReAssignTask(TaskBusinessObject task);
        DataSet AssignTask(TaskBusinessObject task);
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

        DataSet SearchTask(TaskBusinessObject Task);
    }
}
