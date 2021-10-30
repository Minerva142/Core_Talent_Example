using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_core_app.Services
{

    public interface ITradesoftService
    {
        string Login(string username, string password);

    }


    public class TradesoftService : ITradesoftService
    {


        public string Login(string username, string password)
        {
            if (password.Length < 4)
            {
                return "Hata";
            }

 
            if (username == "halil" && password == "1234")
                return "Ok";

            return "Hata";


        }
    }
}
