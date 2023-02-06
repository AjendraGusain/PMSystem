using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
namespace BusinessLogicLayer.Interface
{
    public interface ITaskBLL
    {
        int InsertTaskDetails(TaskBusinessObjectLayer addTask);
    }
}
