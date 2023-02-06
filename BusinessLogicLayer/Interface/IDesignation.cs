using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    interface IDesignation
    {
        DataSet GetDesignation();
        DataSet GetDesignationById(int Id);
        //AddClientBussinessObject GetClientByID(int customerId);
        int InsertDesignation(AddDesignationBusinessObject addDesignation);
        int DeleteDesignation(int Id);
        int UpdateDesignation(AddDesignationBusinessObject addDesignation, int Id);
    }
}
