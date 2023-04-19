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
            response = new Connection().GetResponeResults("Delete from ProjectManagementNew.team where Id=" + Id);
            return response;
        }

        public int DeleteTeamMember(int Id, TeamBusinessObject createTeam)
        {
            string spName = "sp_DeleteTeamMember";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectID", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamId", Convert.ToInt32(createTeam.TeamName)));
            cmd.Parameters.Add(new MySqlParameter("@UserId", Convert.ToInt32(Id)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return response; 
        }

        public int EditTeam(TeamBusinessObject createTeam, int Id)
        {
            throw new NotImplementedException();
        }

        public DataSet GetManager(int Id, int ProjectId)
        {
            try
            {
                string spName = "Select * FROM ProjectManagementNew.team_member tm inner join user u on tm.UserId = u.UserId where TeamId=@TeamId and tm.ParrentTeamMemberId=0 and Is_Active=1";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new MySqlParameter("@ProjectID", 7));
                cmd.Parameters.Add(new MySqlParameter("@TeamId", Id));
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dsResult);
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

        public DataSet GetTeamLeader(int Id)
        {
            try
            {
                
                string spName = "Select * FROM ProjectManagementNew.team_member tm inner join user u on tm.UserId = u.UserId where ParrentTeamMemberId=@ParrentTeamMemberId and Is_Active='1'";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@ParrentTeamMemberId", Convert.ToInt32(Id)));
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dsResult);
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

        public DataSet GetTeamMemberMangerTLUser(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sp_GetTeamMemberbyMangerTLUserById";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectNameID", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamNameId", Convert.ToInt32(createTeam.TeamName)));
            cmd.Parameters.Add(new MySqlParameter("@ManagerNameId", Convert.ToInt32(createTeam.Manager)));
            cmd.Parameters.Add(new MySqlParameter("@TLNameId", Convert.ToInt32(createTeam.TeamLeader)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet GetViewTeam(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sp_GetTeamMemberbyMangerTLUserByIdViewTeam";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectNameID", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamNameId", Convert.ToInt32(createTeam.TeamName)));
            cmd.Parameters.Add(new MySqlParameter("@ManagerNameId", Convert.ToInt32(createTeam.Manager)));
            cmd.Parameters.Add(new MySqlParameter("@TLNameId", Convert.ToInt32(createTeam.TeamLeader)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }


        public DataSet CheckTeamTeamMemberExistTask(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sp_CheckProjectExists";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectCheckID", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamCheckId", Convert.ToInt32(createTeam.TeamName)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }
        public DataSet GetTeamMember(int ProjectId, int TeamId, TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "GetTeamMemberById";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectID", ProjectId));
            cmd.Parameters.Add(new MySqlParameter("@TeamId", TeamId));
            cmd.Parameters.Add(new MySqlParameter("@RoleId",  Convert.ToInt32(createTeam.Role)));
            cmd.Parameters.Add(new MySqlParameter("@Manager", Convert.ToInt32(createTeam.Manager)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet GetTeamName()
        {
            dsResult.Reset();
            string spName = "sp_GetProjectTeamName";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
            //dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.team tm inner join ProjectManagementNew.project p on tm.ProjectId=p.ProjectId");
            //return dsResult;
        }

        public DataSet GetTeamNameById(int Id)
        {
            dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.team tm inner join ProjectManagementNew.project p on tm.ProjectId=p.ProjectId where tm.ProjectId=" + Id);
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
                cmd.Parameters.Add(new MySqlParameter("@CheckTeamName", objTeam.TeamName));
                cmd.Parameters.Add(new MySqlParameter("@CheckProjectId", objTeam.ProjectId));
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

        public int InsertTeamMember(TeamBusinessObject createTeam)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_AddTeamMember";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TeamName", Convert.ToInt32(createTeam.TeamName)));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", Convert.ToInt32(createTeam.ProjectId)));
                cmd.Parameters.Add(new MySqlParameter("@Manager", Convert.ToInt32(createTeam.Manager)));
                cmd.Parameters.Add(new MySqlParameter("@ParentTeamMemberId", Convert.ToInt32(createTeam.ParentTeamId)));
                cmd.Parameters.Add(new MySqlParameter("@RoleId", Convert.ToInt32(createTeam.Role)));
                cmd.Parameters.Add(new MySqlParameter("@IsActive", Convert.ToInt32(createTeam.IsActive)));
                //cmd.Parameters.Add(new MySqlParameter("@LabelReferenceId", Convert.ToInt32(createTeam.LabelReferenceId)));
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

        public int UpdateTeamMember(TeamBusinessObject createTeam)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string spName = "sp_UpdateTeamMember";
                MySqlCommand cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TeamName", Convert.ToInt32(createTeam.TeamName)));
                cmd.Parameters.Add(new MySqlParameter("@ProjectID", Convert.ToInt32(createTeam.ProjectId)));
                cmd.Parameters.Add(new MySqlParameter("@Manager", Convert.ToInt32(createTeam.Manager)));
                cmd.Parameters.Add(new MySqlParameter("@ParentTeamMemberId", Convert.ToInt32(createTeam.ParentTeamId)));
                cmd.Parameters.Add(new MySqlParameter("@RoleId", Convert.ToInt32(createTeam.Role)));
                cmd.Parameters.Add(new MySqlParameter("@IsActive", Convert.ToInt32(createTeam.IsActive)));
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

        public DataSet GetTeamLeaderTeam(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sq_GetTeamLeaderTeam";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@Role", Convert.ToInt32(createTeam.Role)));
            cmd.Parameters.Add(new MySqlParameter("@User", Convert.ToInt32(createTeam.Employee)));
            cmd.Parameters.Add(new MySqlParameter("@ProjectId", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamId", Convert.ToInt32(createTeam.TeamName)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet GetTeamDetails(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sq_TeamDetails";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectID", Convert.ToInt32(createTeam.ProjectId)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet GetAllEmployeTeamMemberId(TeamBusinessObject createTeam)
        {
            dsResult.Reset();
            string spName = "sp_GetEmployeeNotExist";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectID", Convert.ToInt32(createTeam.ProjectId)));
            cmd.Parameters.Add(new MySqlParameter("@TeamId", Convert.ToInt32(createTeam.TeamName)));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet SearchTeam(TeamBusinessObject Team)
        {
            try
            {
                var query = "select t.*, p.ProjectName, c.ClientName, c.ClientId, ut.UserId,u.UserName, s.StatusName from task as t inner join project as p " +
                    "on p.ProjectId=t.ProjectId inner join client as c on p.ClientId=c.ClientId inner join status s  on s.StatusId=t.StatusId " +
                    "left join user_task as ut on ut.TaskId=t.TaskId and ut.IsActive!='0' left join user as u on u.UserId=ut.UserId WHERE t.IsActive!=0 ";

                if (!string.IsNullOrEmpty(Team.SearchTeam))
                {
                    query += " AND (p.ProjectName like '%" + Team.SearchTeam + "%' or t.TaskNumber like '%" + Team.SearchTeam + "%' or t.TaskName like '%"
                        + Team.SearchTeam + "%' or t.StartTime like '%" + Team.SearchTeam + "%' or t.EndTime like '%"
                        + Team.SearchTeam + "%' or u.UserName like '%" + Team.SearchTeam + "%' or s.StatusName like '%" + Team.SearchTeam + "%'); ";
                }
                //if (!string.IsNullOrEmpty(Task.StartDate.ToShortTimeString()) && !string.IsNullOrEmpty(Task.EndDate.ToShortTimeString()))
                //{
                //    query += " AND t.StartTime = '" + Task.StartDate + "' AND t.EndTime = '" + Task.EndDate + "'";
                //}
                //else if (!string.IsNullOrEmpty(Task.StartDate.ToShortTimeString()))
                //{
                //    query += " AND t.StartTime = '" + Task.StartDate + "'";
                //}
                //else if (!string.IsNullOrEmpty(Task.EndDate.ToShortTimeString()))
                //{
                //    query += " AND t.EndTime = '" + Task.EndDate + "'";
                //}
                dsResult = new Connection().GetDataSetResults(query);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
