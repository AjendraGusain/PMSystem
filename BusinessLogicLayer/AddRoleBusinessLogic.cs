using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AddRoleBusinessLogic : IRole
    {
        AddRoleDataAccess addRoleDataAccess = new AddRoleDataAccess();
       

        public int DeleteRole(int Id)
        {
            int dtResult = addRoleDataAccess.DeleteRole(Id);
            return dtResult;
        }

        public DataSet GetRole()
        {
            DataSet dtResult = addRoleDataAccess.GetRole();
            return dtResult;
        }

        public DataSet GetRoleById(int Id)
        {
            DataSet dtResult = addRoleDataAccess.GetRoleById(Id);
            return dtResult;
        }

        public int InsertRole(AddRoleBusinessObject addClient)
        {
            int dtResult = addRoleDataAccess.InsertRole(addClient);
            return dtResult;
        }


        public int UpdateRole(AddRoleBusinessObject addRole, int Id)
        {
            int dtResult = addRoleDataAccess.UpdateRole(addRole, Id);
            return dtResult;
        }
    }
}
