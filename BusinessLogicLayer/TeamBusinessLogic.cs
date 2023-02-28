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

        public DataSet GetTeamByID(int customerId)
        {
            throw new NotImplementedException();
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

        public int UpdateTeam(TeamBusinessObject customer, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
