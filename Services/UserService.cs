using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static first_core_app.Models.UserModel;

namespace first_core_app.Services
{

    public interface IUserService
    {

        UserLoginModel GetUserLogin(string username);
         
    }
    public class UserService : IUserService
    {
        public UserLoginModel GetUserLogin(string username)
        {

            return new UserLoginModel()
            {
                Email = "ahmet@tradesoft.com.tr",
                FullName = "Ahmet Bey",
                EmployeeDate = new DateTime(2020, 10, 5),
                RoleId = 5,
                Title = "Stajer"
            };


        }
        
    }
}
