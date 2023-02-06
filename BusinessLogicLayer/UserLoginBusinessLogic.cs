using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjectLayer;
using BusinessLogicLayer.Interface;

namespace BusinessLogicLayer
{
    public class UserLoginBusinessLogic : IUserLogin
    {
        UserLoginDataAccess userDetail = new UserLoginDataAccess();
       DataSet IUserLogin.UserLogin(UserLoginObject user)
        {
            DataSet dsResult = userDetail.GetLoginDetail(user);
            return dsResult;
        }

    }
}
