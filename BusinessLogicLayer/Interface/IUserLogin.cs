using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
   public interface IUserLogin
    {
        DataSet UserLogin(UserLoginObject user);
        int ResetPassword(UserLoginObject password);

        DataSet GetUsersDetailByUID(string uid);

    }

}
