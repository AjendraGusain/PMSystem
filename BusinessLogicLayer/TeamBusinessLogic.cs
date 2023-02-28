using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TeamBusinessLogic:ITeamBusinessLogic
    {
        private DataSet dtResult;
        private int respone;
        private ITeamDataAccess _teamDataAccess;

        public TeamBusinessLogic(ITeamDataAccess teamDataAccess)
        {
            _teamDataAccess = teamDataAccess;
        }
        public DataSet GetManager()
        {
            dtResult = _teamDataAccess.GetManager();
            return dtResult;
        }

        public DataSet GetTeam()
        {
            dtResult = _teamDataAccess.GetTeam();
            return dtResult;
        }

        public DataSet GetTeamByID(int Id)
        {
            dtResult = _teamDataAccess.GetTeamByID(Id);
            return dtResult;
        }

        public DataSet GetTeamLeader()
        {
            dtResult = _teamDataAccess.GetTeamLeader();
            return dtResult;
        }

        public DataSet GetTeamMember(int ProjectId)
        {
            dtResult = _teamDataAccess.GetTeamMembers(ProjectId);
            return dtResult;
        }

        public DataSet GetUser()
        {
            dtResult = _teamDataAccess.GetUser();
            return dtResult;
        }

        public int InsertTeam(TeamBusinessObject createTeam)
        {
            respone = _teamDataAccess.InsertTeam(createTeam);
            return respone;
        }

        public int UpdateTeam(TeamBusinessObject createTeam, int Id)
        {
            respone = _teamDataAccess.UpdateTeam(createTeam, Id);
            return respone;
        }

        public DataSet GetProject()
        {
            dtResult = _teamDataAccess.GetProject();
            return dtResult;
        }

        public int EditTeam(TeamBusinessObject createTeam, int Id)
        {
            throw new NotImplementedException();
        }

        public int DeleteTeam(int Id)
        {
            respone = _teamDataAccess.DeleteTeam(Id);
            return respone;
        }

        public DataSet GetTeamName()
        {
            dtResult = _teamDataAccess.GetTeamName();
            return dtResult;
        }

        public DataSet GetTeamNameById(int Id)
        {
            dtResult = _teamDataAccess.GetTeamNameById(Id);
            return dtResult;
        }
    }
}
