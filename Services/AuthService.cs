using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static first_core_app.Models.AuthModel;

namespace first_core_app.Services
{
    public interface IAuthService
    {
        bool Login(LoginRequest req);
        bool Logout(LogoutRequest req);
        bool ForgotPassword(string username);
    }
    public class AuthService : IAuthService
    {

        public bool Login(LoginRequest req)
        {

            if (req.Username == "admin" && req.Password == "1234")
            {
                return true;
            }
            return false;
        }



        public bool ForgotPassword(string username)
        {
            return true;
        }

        public bool Logout(LogoutRequest req)
        {

            if (req.Token == "tokenvalue")
            {
                return true;

            }

            return false;
        }


    }
}
