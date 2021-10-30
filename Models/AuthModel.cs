using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_core_app.Models
{
    public class AuthModel
    {
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


        public class LogoutRequest
        {
            public string Token { get; set; }
        }
    }
}
