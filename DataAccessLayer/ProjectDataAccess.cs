using BussinessObjectLayer;
using DataAccessLayer.Interface;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;


namespace DataAccessLayer
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        DataSet dsResult = new DataSet();

        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public DataSet GetAllProject()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("SELECT project.*, client.ClientName FROM project JOIN client ON project.ClientId = client.ClientId");
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetProjectById(int ProjectId)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("SELECT project.*, client.ClientName FROM project JOIN client ON project.ClientId = client.ClientId and project.ProjectId='" + ProjectId + "'");
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetProjectByName(string ProjectName)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("SELECT project.*, client.ClientName FROM project JOIN client ON project.ClientId = client.ClientId and project.ProjectName='" + ProjectName + "'");
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ProjectSearch(ProjectBusinessObject Project)
        {
            try
            {
                var query = "SELECT * FROM project where ";

                if (Project.ProjectName != "")
                {
                    query += "ProjectName LIKE '% " + Project.ProjectName + " %'";
                }
                if (Project.StartDate != "" && Project.EndDate != "")
                {
                    query += "OR StartDate <= '" + Project.StartDate + "' AND EndDate <= '" + Project.EndDate + "'";
                }
                else if (Project.StartDate != "" && Project.EndDate == "")
                {
                    query += " AND StartDate = '" + Project.StartDate + "'";
                }
                else if (Project.StartDate == "" && Project.EndDate != "")
                {
                    query += " AND EndDate = '" + Project.EndDate + "'";
                }
                dsResult = new Connection().GetDataSetResults(query);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int InsertProject(ProjectBusinessObject Project)
        {
            int insertSuccess = 0;

            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string Query = "INSERT INTO ProjectManagementNew.project(ProjectName, ClientId, StartDate) VALUES(@ProjectName, @ClientId, @StartDate)";

                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.Add(new MySqlParameter("@ProjectName", Project.ProjectName));
                cmd.Parameters.Add(new MySqlParameter("@ClientId", Project.ClientId));
                cmd.Parameters.Add(new MySqlParameter("@StartDate", Project.StartDate));
                insertSuccess = cmd.ExecuteNonQuery();

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
            return insertSuccess;

        }

        public int DeleteProject(int ProjectId)
        {
            int deleteSuccess = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string Query = "DELETE FROM ProjectManagementNew.project WHERE ProjectId = @ProjectId";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.Add(new MySqlParameter("@ProjectId", ProjectId));
                deleteSuccess = cmd.ExecuteNonQuery();

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
            return deleteSuccess;


        }

        public int UpdateProject(ProjectBusinessObject Project, int ProjectId)
        {
            int updateSuccess = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string Query = "UPDATE ProjectManagementNew.project SET ProjectName = @ProjectName,ClientId = @ClientId,StartDate = @StartDate where ProjectId = @ProjectId";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.Add(new MySqlParameter("@ProjectId", ProjectId));
                cmd.Parameters.Add(new MySqlParameter("@ProjectName", Project.ProjectName));
                cmd.Parameters.Add(new MySqlParameter("@ClientId", Project.ClientId));
                cmd.Parameters.Add(new MySqlParameter("@StartDate", Project.StartDate));

                updateSuccess = cmd.ExecuteNonQuery();

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
            return updateSuccess;
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
