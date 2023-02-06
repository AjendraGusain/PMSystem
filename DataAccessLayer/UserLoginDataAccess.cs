using BussinessObjectLayer;
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
    public class UserLoginDataAccess
    {
        DataSet dsResult = new DataSet();
        public DataSet GetLoginDetail(UserLoginObject userLogin)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.user where Email = '" + userLogin.Email + "' and Password='" + userLogin.Password + "'");
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    var role = dsResult.Tables[0].Rows[0]["RoleID"];
                    if (role.ToString() == "1")
                    {
                        return dsResult;
                    }
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
    }
}
