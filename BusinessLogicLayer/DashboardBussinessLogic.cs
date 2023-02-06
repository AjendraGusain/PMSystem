using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DashboardBussinessLogic
    {
        DashboardDataAccess getDashboard = new DashboardDataAccess();
        public DataSet GetDashboard()
        {
            DataSet dtResult = getDashboard.GetDashboard();
            return dtResult;
        }
    }
}
