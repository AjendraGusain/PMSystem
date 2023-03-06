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
using System.Net.Mail;
using System.Net;

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

        public void SendResetPasswordEmail(string tomail, string UniqueID)
        {
            string from = "deepak.dhiman1988@gmail.com";
            MailMessage mailMsg = new MailMessage(from, tomail);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dear " + tomail + ",<br/><br/>");
            stringBuilder.Append("Please click on the below link to reset your password");
            stringBuilder.Append("<br/>");
            stringBuilder.Append("https://localhost:44399/ResetPassword.aspx?UID=" + UniqueID);
            stringBuilder.Append("<br/><br/>");

            mailMsg.IsBodyHtml = true;
            mailMsg.Body = stringBuilder.ToString();
            mailMsg.Subject = "Reset Your Password";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential NetworkCred = new NetworkCredential(from, "zqgfvyigriszjcej");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mailMsg);
               // ScriptManager.RegisterStartupScript(this, GetType(), "mail", "alert('Mail sent successfully.');", true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

    }
}
