using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BussinessObjectLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class AddProjectBusinessLogic
    {
        AddProjectDataAccess addProjectDA = new AddProjectDataAccess();
        public int InsertProjectDetails(AddProjectBusinessObject addProject)
        {
            int dtResult = addProjectDA.InsertProjectDetails(addProject);
            return dtResult;
        }
        public DataSet GetClientDetails()
        {
            DataSet dtResult = addProjectDA.GetClientDetails();
            return dtResult;
        }
    }
}
