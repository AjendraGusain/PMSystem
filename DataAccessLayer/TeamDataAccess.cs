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
    public class TeamDataAccess : ITeamDataAccess
    {
        DataSet dsResult = new DataSet();
        int response = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public int DeleteTeam(int Id)
        {
            dsResult = new Connection().GetDataSetResults("Delete from ProjectManagementNew.team where Id=" + Id);
            return response;
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

        public DataSet GetTeamByID(int Id)
        {
            dsResult = new Connection().GetDataSetResults("SELECT * FROM ProjectManagementNew.team where Id="+Id);
            return dsResult;
        }

        public DataSet GetTeamLeader()
        {
            throw new NotImplementedException();
        }

        public DataSet GetTeamName()
        {
            dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.team_member tm inner join ProjectManagementNew.team t on tm.TeamId=t.Id inner join ProjectManagementNew.user u on tm.UserId = u.UserId inner join ProjectManagementNew.project p on tm.ProjectId = p.ProjectId");
            return dsResult;
        }

        public DataSet GetTeamNameById(int Id)
        {
            dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.team_member tm inner join ProjectManagementNew.team t on tm.TeamId=t.Id inner join ProjectManagementNew.user u on tm.UserId = u.UserId inner join ProjectManagementNew.project p on tm.ProjectId = p.ProjectId where tm.ProjectId="+Id);
            return dsResult;
        }

        public DataSet GetUser()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.team t inner join ProjectManagementNew.project p on p.ProjectId=t.ProjectId ");
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

        public int InsertTeam(TeamBusinessObject objTeam)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_AddTeamName";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TeamName", objTeam.TeamName));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", objTeam.ProjectId));
                response = cmd.ExecuteNonQuery();
                return response;
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
        }

        public int UpdateTeam(TeamBusinessObject objTeam, int Id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.team Set TeamName=@TeamName,ProjectID=@ProjectID where Id=" + Id; 
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@TeamName", objTeam.TeamName));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", objTeam.ProjectId));
                response = cmd.ExecuteNonQuery();
                return response;
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
        }
    }
}
