using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ClientBusinessLogic : IClientBusinessLogic
    {
        private IClientDataAccess _clientDataAccess;
        private DataSet dtResult;
        private int respone;
        public ClientBusinessLogic(IClientDataAccess clientDataAccess)
        {
            _clientDataAccess = clientDataAccess;
        }

        public int DeleteClient(int Id)
        {
            int dtResult = _clientDataAccess.DeleteClient(Id);
            return dtResult;
        }

        public DataSet GetClientByID(int Id)
        {
            dtResult = _clientDataAccess.GetClientByID(Id);
            return dtResult;
        }

        public DataSet GetClients()
        {
            dtResult = _clientDataAccess.GetClients();
            return dtResult;
        }

        public DataSet GetCountry()
        {
            dtResult = _clientDataAccess.GetClients();
            return dtResult;
        }

        public int InsertClient(ClientBusinessObject addClient)
        {
            respone = _clientDataAccess.InsertClient(addClient);
            return respone;
        }

        public int UpdateClient(ClientBusinessObject clientUpdate, int Id)
        {
            respone = _clientDataAccess.UpdateClient(clientUpdate, Id);
            return respone;
        }
    }
}
