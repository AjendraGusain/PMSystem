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
using System.Collections;

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
            return new MySqlConnection(GetPMConnection);
        }

     
        public DataSet GetDataSetResults(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
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


        public DataSet ExecuteSPByProjectID(string sproc, int ProjectId)
        {
            MySqlCommand cmd = new MySqlCommand(sproc, GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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


        public DataSet GetData(string sproc, Hashtable myParameters)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sproc, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 2000000;
            foreach (DictionaryEntry entry in myParameters)
            {
                MySqlParameter objParms = new MySqlParameter();
                objParms.ParameterName = entry.Key.ToString();

                objParms.Value = entry.Value.ToString();
                if (objParms.Value.ToString() == "")
                {
                    objParms.Value = DBNull.Value;
                }
                objParms.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(objParms);
            }
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }



    }
}
