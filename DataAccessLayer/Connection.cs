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
       //AJAYj
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
           // MySqlConnection connection = new MySqlConnection(PMSConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, GetConnection());
            //_cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
