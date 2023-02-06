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
        DataSet GetManager();
        DataSet GetTeamLeader();
        DataSet GetUser();
    }
}
