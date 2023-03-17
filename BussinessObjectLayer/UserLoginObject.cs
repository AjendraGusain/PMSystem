using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectLayer
{
    public class UserLoginObject
    {
        public int insertSuccess = 0;
        public int response = 0;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ResetPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
