using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    interface IRoleDataAccess
    {
        DataSet GetRole();
        DataSet GetRoleById(int Id);
        int InsertRole(AddRoleBusinessObject addRole);
        int DeleteRole(int Id);
        int UpdateRole(AddRoleBusinessObject addRole, int Id);
    }
}
