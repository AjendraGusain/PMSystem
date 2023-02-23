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
        DataSet GetManager();
        DataSet GetTeamLeader();
        DataSet GetUser();
        DataSet GetProject();
        int EditTeam(TeamBusinessObject createTeam, int Id);
        int DeleteTeam(int Id);
    }
}
