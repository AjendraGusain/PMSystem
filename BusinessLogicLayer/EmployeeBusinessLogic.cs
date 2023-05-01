using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class EmployeeBusinessLogic
    {
        EmployeeDataAccess addEmployeeData = new EmployeeDataAccess();
        DataSet dtResultDS = new DataSet();

        public int InsertAllEmployeeDetails(EmployeeBusinessObject userLogin)
        {
            string sproc = "sp_InsertEmployeeDetails";
            int dtResult = addEmployeeData.InsertEmployeeDetails(userLogin, sproc);
            return dtResult;
        }

        public DataSet GetAllEmployee()
        {
            DataSet dtResult = addEmployeeData.GetAllEmployee();
            return dtResult;
        }
        public DataSet GetAllInTeamEmployee()
        {
            DataSet dtResult = addEmployeeData.GetAllInTeamEmployee();
            return dtResult;
        }


        public DataSet GetAllEmployeeByEmail(string mail)
        {
            DataSet dtResult = addEmployeeData.GetAllEmployeeByEmail(mail);
            return dtResult;
        }

        public DataSet GetEmployeeById(int UserId)
        {
            DataSet dtResult = addEmployeeData.GetEmployeeById(UserId);
            return dtResult;
        }

        public int DeleteEmployee(int Id)
        {
            int dtResult = addEmployeeData.DeleteEmployee(Id);
            return dtResult;
        }

        public DataSet GetAllRole()
        {
            DataSet dtResult = addEmployeeData.GetRole();
            return dtResult;
        }

        public DataSet GetAllDesignation()
        {
            DataSet dtResult = addEmployeeData.GetDesignation();
            return dtResult;
        }

        public int UpdateAllEmployee(EmployeeBusinessObject userUpdate, int UserId)
        {
            int dtResult = addEmployeeData.UpdateAllEmployee(userUpdate, UserId);
            return dtResult;
        }

        public void UserCheck(EmployeeBusinessObject userLogin, out string code, out string email, out string phone)
        {
            code = "";
            email = "";
            phone = "";
            DataSet dtResult = addEmployeeData.UserCheck(userLogin);
            bool checkCode = dtResult.Tables[0].AsEnumerable().Any(row => row.Field<string>("EmployeeCode") == userLogin.EmployeeCode);
            bool checkEmail = dtResult.Tables[0].AsEnumerable().Any(row => row.Field<string>("Email") == userLogin.EmployeeEmail);
            bool checkPhone = dtResult.Tables[0].AsEnumerable().Any(row => row.Field<string>("PhoneNumber") == userLogin.EmployeePhone);

            if (checkCode == true)
            {
                code = "EmployeeCode";
            }
            if (checkEmail == true)
            {
                email = "EmployeeEmail";
            }
            if (checkPhone == true)
            {
                phone = "EmployeePhone";
            }
        }

        public int UpdateToken(string token, string email)
        {
            int dtResult = addEmployeeData.UpdateToken(token, email);
            return dtResult;
        }
        public DataSet GetProjectCurrent(int Id, int IsActive)
        {
            dtResultDS = addEmployeeData.GetProjectCurrent(Id, IsActive);
            return dtResultDS;
        }

        public DataSet GetAllTaskByUserEmployeeTask(int ProjectId, int UserId)
        {
            dtResultDS = addEmployeeData.GetAllTaskByUserEmployeeTask(ProjectId, UserId);
            return dtResultDS;
        }

        public DataSet SearchEmployee(EmployeeBusinessObject user)
        {
            DataSet dtResult = addEmployeeData.SearchEmployee(user);
            return dtResult;
        }

        public DataSet GetAllTeamMember()
        {
            DataSet dtResult = addEmployeeData.GetAllTeamMember();
            return dtResult;
        }

    }
}
