using BussinessObjectLayer;
using DataAccessLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeamDataAccess: ITeamDataAccess
    {
        private DataSet dsResult;
        private int respone;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);

        public DataSet GetManager()
        {
            try
            {

                dsResult = new Connection().GetDataSetResults("select UserId, us.UserName, r.role from ProjectManagementNew.user us inner join ProjectManagementNew.role r on us.RoleId=r.RoleId where r.Role='Manager'");
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
            try
            {
                dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.team_new");
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

        public DataSet GetTeamByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public DataSet GetTeamLeader()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("select UserId, us.UserName, r.role from ProjectManagementNew.user us inner join ProjectManagementNew.role r on us.RoleId=r.RoleId where r.Role='TeamLeader'");
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

        public DataSet GetTeamMembers(int ProjectId)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_GetTeamByProjectID";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                dsResult = new Connection().ExecuteSPByProjectID(spName, ProjectId);
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

       

        public DataSet GetUser()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("select UserId, us.UserName, r.role from ProjectManagementNew.user us inner join ProjectManagementNew.role r on us.RoleId=r.RoleId where r.Role='User'");
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

        public int InsertTeam(TeamBusinessObject createTeam)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.team_new(TeamName,ManagerId,TeamLeaderId,EmployeeId) values(@TeamName,@ManagerId,@TeamLeader,@EmployeeId)";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@TeamName", createTeam.TeamName));
                cmd.Parameters.Add(new MySqlParameter("@ManagerId", createTeam.Manager));
                cmd.Parameters.Add(new MySqlParameter("@TeamLeader", createTeam.TeamLeader));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeId", createTeam.Employee));
                respone = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return respone;
        }

        public int UpdateTeam(TeamBusinessObject customer, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
