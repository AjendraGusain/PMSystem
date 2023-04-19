using BussinessObjectLayer;
using DataAccessLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserLoginDataAccess: IUserLoginDataAccess
    {
        DataSet dsResult = new DataSet();
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public DataSet GetLoginDetail(UserLoginObject userLogin)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("SELECT u.UserId,u.UserName,u.Email,u.Password,r.RoleId,r.Role, d.Designation FROM ProjectManagementNew.user u inner join role r on u.RoleId=r.RoleId inner join designation d on u.DesignationId=d.Id where u.Email = '" + userLogin.Email + "' and u.Password='" + userLogin.Password + "'");
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    //var role = dsResult.Tables[0].Rows[0]["Role"];
                    //if (role.ToString() == "Admin")
                    //{
                    //    return dsResult;
                    //}
                    //else if(role.ToString() == "User")
                    //{
                    //    return dsResult;
                    //}
                    return dsResult;
                }
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

        public DataSet GetUsersDetailByUID(string uid)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.user where UID='"+uid+"'");
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

        public int ResetPassword(UserLoginObject password)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.user Set Password=@ResetPassword where Email='" + password.Email + "'";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@ResetPassword", password.ResetPassword));                
                password.insertSuccess = cmd.ExecuteNonQuery();
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
            return password.insertSuccess;
        }

        
    }    
}
