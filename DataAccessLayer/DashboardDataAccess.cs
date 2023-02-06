using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DashboardDataAccess
    {
        DataSet dsResult = new DataSet();
        public DataSet GetDashboard()
        {
            try
            {
                dsResult = new Connection().GetDataSetResults("Select * FROM ProjectManagementNew.task as TL inner join ProjectManagementNew.client CD on TL.ClientId=CD.ClientId " +
                    "inner join ProjectManagementNew.project AS PD  on TL.ProjectId = PD.ProjectId inner join ProjectManagementNew.user As UD on TL.UserId = UD.UserId");
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            //return dsResult;
        }
    }
}
