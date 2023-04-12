using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ITeamDataAccess
    {
        DataSet GetTeam();
        DataSet GetTeamByID(int customerId);
        int InsertTeam(TeamBusinessObject customer);
        int UpdateTeam(TeamBusinessObject customer, int Id);
        DataSet GetManager(int Id, int ProjectId);
        DataSet GetTeamLeader(int Id);
        DataSet GetUser();
        DataSet GetProject();
        DataSet GetTeamName();
        DataSet GetTeamNameById(int Id);
        DataSet GetTeamDetails(TeamBusinessObject createTeam);
        DataSet GetTeamLeaderTeam(TeamBusinessObject createTeam);
        DataSet GetTeamMemberMangerTLUser(TeamBusinessObject createTeam);
        DataSet GetTeamMember(int ProjectId, int TeamId, TeamBusinessObject createTeam);
        DataSet GetAllEmployeTeamMemberId(TeamBusinessObject createTeam);
        int InsertTeamMember(TeamBusinessObject createTeam);
        int DeleteTeamMember(int Id, TeamBusinessObject createTeam);
        int UpdateTeamMember(TeamBusinessObject createTeam);
        int EditTeam(TeamBusinessObject createTeam, int Id);
        int DeleteTeam(int Id);
    }
}
