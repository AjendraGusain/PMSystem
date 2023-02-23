using BussinessObjectLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeamDataAccess : ITeamDataAccess
    {
        DataSet dsResult = new DataSet();
        public int DeleteTeam(int Id)
        {
            throw new NotImplementedException();
        }

        public int EditTeam(TeamBusinessObject createTeam, int Id)
        {
            throw new NotImplementedException();
        }

        public DataSet GetManager()
        {
            throw new NotImplementedException();
        }

        public DataSet GetProject()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.project");
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public DataSet GetTeam()
        {
            throw new NotImplementedException();
        }

        public DataSet GetTeamByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public DataSet GetTeamLeader()
        {
            throw new NotImplementedException();
        }

        public DataSet GetUser()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.team_name t inner join ProjectManagementNew.project p on p.ProjectId=t.ProjectId ");
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            //return dsResult;
        }

        public int InsertTeam(TeamBusinessObject customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateTeam(TeamBusinessObject customer, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
