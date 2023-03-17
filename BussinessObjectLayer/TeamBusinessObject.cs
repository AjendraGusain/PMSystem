using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectLayer
{
    public class TeamBusinessObject
    {
        public string TeamName { get; set; }
        public string Manager { get; set; }
        public string TeamLeader { get; set; }
        public string Employee { get; set; }
        public string ProjectId { get; set; }
        public string Role { get; set; }
        public string ParentTeamId { get; set; }
        public int IsActive { get; set; }
    }
}
