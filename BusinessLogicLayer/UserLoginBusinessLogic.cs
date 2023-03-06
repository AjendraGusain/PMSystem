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

        public DataSet GetUsersDetailByUID(string uid)
        {
            DataSet dsResult = userDetail.GetUsersDetailByUID(uid);
            return dsResult;
        }

        

        public int ResetPassword(UserLoginObject password)
        {
            int dsResult = userDetail.ResetPassword(password);
            return dsResult;
        }

        DataSet IUserLogin.UserLogin(UserLoginObject user)
        {
            DataSet dsResult = userDetail.GetLoginDetail(user);
            return dsResult;
        }

    }
}
