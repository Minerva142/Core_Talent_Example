using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_core_app.Models
{
    public class UserModel
    {
        public class UserLoginModel
        {
            public string Email { get; set; }
            public string FullName { get; set; }
            public string Title { get; set; }
            public int RoleId { get; set; }
            public DateTime EmployeeDate { get; set; }
        }
    }
}
