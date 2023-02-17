using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectLayer
{
    public class TaskBusinessObject
    {
        public DataSet dsResult = new DataSet();
        public int response=0;
        public string ClientID { get; set; }
        public string ProjectID { get; set; }
        public string TaskNumber { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string EmployeeName { get; set; }
        public int LoginUserID { get; set; }
        public int TaskID { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
