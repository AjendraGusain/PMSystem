using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    interface IDesignationDataAccess
    {
        DataSet GetDesignation();
        DataSet GetDesignationById(int Id);
        int InsertDesignation(AddDesignationBusinessObject addRole);
        int DeleteDesignation(int Id);
        int UpdateDesignation(AddDesignationBusinessObject addRole, int Id);
    }
}
