using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class TaskBusinesLogicLayer
    {
        TaskDataAccessLayer taskDataAccessLayer = new TaskDataAccessLayer();

        public int InsertTaskDetails(TaskBusinessObjectLayer taskName)
        {
            string sproc = "";
            int dtResult = taskDataAccessLayer.InsertTaskDetails(taskName, sproc);
            return dtResult;
        }

    }
}
