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
    public class AddDesignationBusinessLogic : IDesignation
    {
        AddDesignationDataAccess addDesignationDataAccess = new AddDesignationDataAccess();
       
        public int DeleteDesignation(int Id)
        {
            int dtResult = addDesignationDataAccess.DeleteDesignation(Id);
            return dtResult;
        }

        public DataSet GetDesignation()
        {
            DataSet dtResult = addDesignationDataAccess.GetDesignation();
            return dtResult;
        }

        public DataSet GetDesignationById(int Id)
        {
            DataSet dtResult = addDesignationDataAccess.GetDesignationById(Id);
            return dtResult;
        }

        public int InsertDesignation(AddDesignationBusinessObject addDesignation)
        {
            int dtResult = addDesignationDataAccess.InsertDesignation(addDesignation);
            return dtResult;
        }


        public int UpdateDesignation(AddDesignationBusinessObject addDesignation, int Id)
        {
            int dtResult = addDesignationDataAccess.UpdateDesignation(addDesignation, Id);
            return dtResult;
        }
    }
}
