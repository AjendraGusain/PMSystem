using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using BussinessObjectLayer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class Connection
    {
        public static string GetPMConnection
        {
            get
            {
              //  MySqlConnection connection = new MySqlConnection(PMSConnectionString);
                string con = ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString;
                return con;
            }
        }

      
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(GetPMConnection);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            else if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

     
        public DataSet GetDataSetResults(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int GetResponeResults(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, GetConnection());
            int insertSuccess = cmd.ExecuteNonQuery();
            return insertSuccess;
        }

        public DataSet ExecuteSP(string sproc, int ClientID)
        {
            MySqlCommand cmd = new MySqlCommand(sproc, GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", ClientID);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public DataSet ExecuteSPByTaskID(string sproc, int taskId)
        {
            MySqlCommand cmd = new MySqlCommand(sproc, GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskId", taskId);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public DataSet ExecuteSPWithoutID(string sproc)
        {
            MySqlCommand cmd = new MySqlCommand(sproc, GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int SPInsert(string spName)
        {
            try
            {
                int respone = 0;
                MySqlCommand cmd = new MySqlCommand(spName, GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery() ;
                return respone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
