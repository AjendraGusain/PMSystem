using BussinessObjectLayer;
using DataAccessLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClientDataAccess : IClientDataAccess
    {
        DataSet dsResult = new DataSet();
        int insertSuccess = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);

        public int DeleteClient(int Id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Delete  from ProjectManagementNew.client where ClientId=@Id";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@Id", Id));
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

        public DataSet GetClients()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("select * from ProjectManagementNew.client cd inner join country c on cd.countryid=c.id");
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return dsResult;
        }

        public int InsertClient(ClientBusinessObject addClient)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.client(ClientName, CountryId) values(@ClientName, @Country)";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@ClientName", addClient.ClientName));
                cmd.Parameters.Add(new MySqlParameter("@Country", addClient.Country));
                insertSuccess=cmd.ExecuteNonQuery();

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

        public DataSet GetClientByID(int Id)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.client where ClientId='" + Id + "'");
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

        public int UpdateClient(ClientBusinessObject addClient, int Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.client Set ClientName=@ClientName,CountryId=@Country where ClientId=@Id";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                cmd.Parameters.Add(new MySqlParameter("@ClientName", addClient.ClientName));
                cmd.Parameters.Add(new MySqlParameter("@Country", addClient.Country));
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

        public DataSet GetCountry()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM  ProjectManagementNew.country");
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
    }
}
