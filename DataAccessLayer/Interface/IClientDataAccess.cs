using BussinessObjectLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IClientDataAccess
    {
        DataSet GetClients();
        DataSet GetClientByID(int customerId);
        int InsertClient(ClientBusinessObject customer);
        int DeleteClient(int Id);
        int UpdateClient(ClientBusinessObject customer, int Id);
        DataSet GetCountry();
        DataSet ClientSearch(ClientBusinessObject Client);
    }
}
