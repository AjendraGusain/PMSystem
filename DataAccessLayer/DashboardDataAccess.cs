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
                dsResult = new Connection().GetDataSetResults("select t.*, p.ProjectName, c.ClientName, c.ClientId, ut.UserId, u.UserName,s.StatusName from task as t inner join project as p on p.ProjectId = t.ProjectId inner join client as c on p.ClientId = c.ClientId inner join user_task as ut on ut.TaskId = t.TaskId inner join user as u on u.UserId = ut.UserId inner join status s on s.StatusId=t.StatusId");
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
