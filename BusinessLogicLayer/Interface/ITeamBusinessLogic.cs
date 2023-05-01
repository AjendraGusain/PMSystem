using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ITeamBusinessLogic
    {
        DataSet GetTeam();
        DataSet GetTeamByID(int customerId);
        int InsertTeam(TeamBusinessObject customer);
        int UpdateTeam(TeamBusinessObject customer, int Id);
        DataSet GetManager(int Id, int projectId);
        //DataSet GetTeamLeader(int TeamMemberId);
        DataSet GetTeamLeader(int TeamMemberId);
        DataSet GetUser();
        DataSet GetProject();
        DataSet GetTeamName();
        DataSet GetTeamDetails(TeamBusinessObject createTeam);
        DataSet GetTeamLeaderTeam(TeamBusinessObject createTeam);
        DataSet GetTeamNameById(int Id);
        DataSet GetTeamMemberMangerTLUser(TeamBusinessObject createTeam);
        DataSet GetTeamMemberTeamLeader(TeamBusinessObject createTeam);
        DataSet GetViewTeam(TeamBusinessObject createTeam);
        DataSet CheckTeamTeamMemberExistTask(TeamBusinessObject createTeam);
        DataSet GetTeamMemberEmployee(TeamBusinessObject createTeam);
        DataSet GetAllEmployeTeamMemberId(TeamBusinessObject createTeam);
        DataSet GetTeamMember(TeamBusinessObject createTeam);
        int InsertTeamMember(TeamBusinessObject createTeam);
        int DeleteTeamMember(int Id, TeamBusinessObject createTeam);
        int UpdateTeamMember(TeamBusinessObject createTeam);
        int EditTeam(TeamBusinessObject createTeam, int Id);
        int DeleteTeam(int Id);
        DataSet SearchTeam(TeamBusinessObject Team);
    }
}
