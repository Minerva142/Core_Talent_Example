using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_core_app.Models
{
    public class MenuModel
    {
        public class Menu
        {
            public int ConnectedMenuItemId { get; set; }
            public int MenuItemId { get; set; }
            public string Name { get; set; }
               
        }
    }
}
