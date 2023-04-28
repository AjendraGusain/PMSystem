using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using MySql.Data.MySqlClient;


namespace DataAccessLayer
{
    public class EmployeeDataAccess
    {
        DataSet dsResult = new DataSet();


        int insertSuccess = 0;
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
        public int InsertEmployeeDetails(EmployeeBusinessObject addEmployee, string sproc)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "insert  into ProjectManagementNew.user(EmployeeCode,UserName,Email,PhoneNumber,RoleId,DesignationId, IsAdmin) values(@EmployeeCode, @EmployeeName,@EmployeeEmail,@EmployeePhone, @Role,@Designation, @IsAdmin)";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@EmployeeCode", addEmployee.EmployeeCode));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeName", addEmployee.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeEmail", addEmployee.EmployeeEmail));
                cmd.Parameters.Add(new MySqlParameter("@EmployeePhone", addEmployee.EmployeePhone));
                cmd.Parameters.Add(new MySqlParameter("@Role", addEmployee.Role));
                cmd.Parameters.Add(new MySqlParameter("@Designation", addEmployee.Designation));
                cmd.Parameters.Add(new MySqlParameter("@IsAdmin", addEmployee.IsAdmin));
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

        public int UpdateAllEmployee(EmployeeBusinessObject addEmployee, int Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.user Set EmployeeCode=@EmployeeCode,UserName=@EmployeeName, PhoneNumber=@EmployeePhone,Email=@EmployeeEmail,RoleId=@Role,DesignationId=@Designation, IsAdmin=@IsAdmin where UserId=@UserId";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@UserId", Id));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeCode", addEmployee.EmployeeCode));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeName", addEmployee.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeEmail", addEmployee.EmployeeEmail));
                cmd.Parameters.Add(new MySqlParameter("@EmployeePhone", addEmployee.EmployeePhone));
                cmd.Parameters.Add(new MySqlParameter("@Role", addEmployee.Role));
                cmd.Parameters.Add(new MySqlParameter("@Designation", addEmployee.Designation));
                cmd.Parameters.Add(new MySqlParameter("@IsAdmin", addEmployee.IsAdmin));
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

        public DataSet GetAllEmployee()
        {
            dsResult.Reset();
            try
            {
                dsResult = new Connection().GetDataSetResults("Select UserID, EmployeeCode, UserName, PhoneNumber, Email, Role, Designation,UID FROM ProjectManagementNew.user as UD inner join ProjectManagementNew.role As RO on UD.RoleId=RO.RoleId inner join ProjectManagementNew.designation As DS on UD.DesignationId=DS.Id");
                return dsResult;
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


        public DataSet GetAllEmployeeByEmail(string mail)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.user as UD inner join ProjectManagementNew.role As RO on UD.RoleId=RO.RoleId inner join ProjectManagementNew.designation As DS on UD.DesignationId=DS.Id where UD.Email='" + mail + "'");
                return dsResult;
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

        public DataSet GetAllInTeamEmployee()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select UserID, UserName FROM ProjectManagementNew.user as UD inner join ProjectManagementNew.role As RO on UD.RoleId=RO.RoleId");
                return dsResult;
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

        public DataSet GetEmployeeById(int UserId)
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.user as UD inner join ProjectManagementNew.role As RO on UD.RoleId=RO.RoleId inner join ProjectManagementNew.designation As DS on UD.DesignationId=DS.Id where UserId='" + UserId + "'");
                return dsResult;
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

        public int DeleteEmployee(int Id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Delete from ProjectManagementNew.user where UserId=@Id";
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

        public DataSet GetRole()
        {
            try
            {

                dsResult = new Connection().GetDataSetResults("Select * FROM  ProjectManagementNew.role");
                return dsResult;

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

        public DataSet GetDesignation()
        {
            try
            {

                dsResult = new Connection().GetDataSetResults("Select * FROM  ProjectManagementNew.designation");
                return dsResult;

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

        public DataSet UserCheck(EmployeeBusinessObject addEmployee)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "SELECT * FROM ProjectManagementNew.user where Employeecode=@EmployeeCode or Email=@EmployeeEmail or PhoneNumber=@EmployeePhone";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
                cmd.Parameters.Add(new MySqlParameter("@EmployeeCode", addEmployee.EmployeeCode));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeName", addEmployee.EmployeeName));
                cmd.Parameters.Add(new MySqlParameter("@EmployeeEmail", addEmployee.EmployeeEmail));
                cmd.Parameters.Add(new MySqlParameter("@EmployeePhone", addEmployee.EmployeePhone));
                cmd.Parameters.Add(new MySqlParameter("@Role", addEmployee.Role));
                cmd.Parameters.Add(new MySqlParameter("@Designation", addEmployee.Designation));
                cmd.Parameters.Add(new MySqlParameter("@IsAdmin", addEmployee.IsAdmin));
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
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
            return ds;
        }


        public int UpdateToken(string token, string email)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string dsResult = "Update  ProjectManagementNew.user Set UID='" + token + "',UIDDate=Now() where Email='" + email + "'";
                MySqlCommand cmd = new MySqlCommand(dsResult, conn);
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

        public DataSet GetProjectCurrent(int Id, int IsActive)
        {
            dsResult.Reset();
            string spName = "sp_GetProjectCurrent";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@UserId", Id));
            cmd.Parameters.Add(new MySqlParameter("@IsActive", IsActive));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet GetAllTaskByUserEmployeeTask(int ProjectId, int UserId)
        {
            dsResult.Reset();
            string spName = "sp_GetAllTaskByUserEmployeeTask";
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@ProjectId", ProjectId));
            cmd.Parameters.Add(new MySqlParameter("@UserId", UserId));

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dsResult);
            return dsResult;
        }

        public DataSet SearchEmployee(EmployeeBusinessObject Project)
        {
            try
            {
                var query = "SELECT u.*,r.Role,d.Designation FROM ProjectManagementNew.user u inner join role r on r.RoleId=u.RoleId inner join designation d on d.Id=u.designationId ";

                if (!string.IsNullOrEmpty(Project.EmployeeName))
                {
                    query += "WHERE u.EmployeeCode LIKE '%" + Project.EmployeeName + "%' or u.UserName LIKE '%" + Project.EmployeeName + "%' or u.PhoneNumber LIKE '%" + Project.EmployeeName + "%' or u.Email LIKE '%" + Project.EmployeeName + "%' or r.Role LIKE '%" + Project.EmployeeName + "%' or d.Designation LIKE '%" + Project.EmployeeName + "%'";
                }
                dsResult = new Connection().GetDataSetResults(query);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllTeamMember()
        {
            try
            {
                var query = "select * from team_member where Is_Active!=0;";
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
