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
    }
}
