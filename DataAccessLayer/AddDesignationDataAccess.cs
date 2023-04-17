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
    public class AddDesignationDataAccess : IDesignationDataAccess
    {
        DataSet dsResult = new DataSet();
        int insertSuccess = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public int DeleteDesignation(int Id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Delete from ProjectManagementNew.designation where Id=@Id";
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

        public DataSet GetDesignation()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.designation");
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDesignationById(int Id)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.designation where Id='" + Id + "'");
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertDesignation(AddDesignationBusinessObject addDesignation)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //string dsResult = "insert  into ProjectManagementNew.designation(Designation) values(@Designation)";
                string dsResult = "sp_CheckDesignation";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@CheckDesignation", addDesignation.Designation));
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

        public int UpdateDesignation(AddDesignationBusinessObject addDesignation, int Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.designation Set Designation=@Designation where Id=@Id";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                cmd.Parameters.Add(new MySqlParameter("@Designation", addDesignation.Designation));
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
    }
}
