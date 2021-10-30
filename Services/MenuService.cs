using first_core_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_core_app.Services
{

    public interface IMenuService
    {
        List<MenuModel.Menu> GetUserMenu(int roleId);

    }

    public class MenuService : IMenuService
    {
        public List<MenuModel.Menu> GetUserMenu(int roleId)
        {
            List<MenuModel.Menu> userMenuList = new List<MenuModel.Menu>();


            userMenuList.Add(new MenuModel.Menu()
            {
                ConnectedMenuItemId = 1,
                MenuItemId = 4,
                Name = "Vaka oluştur"
            });


            userMenuList.Add(new MenuModel.Menu()
            {
                ConnectedMenuItemId = 1,
                MenuItemId = 5,
                Name = "Tüm vakaları getir"
            });

            userMenuList.Add(new MenuModel.Menu()
            {
                ConnectedMenuItemId = 2,
                MenuItemId = 7,
                Name = "Görevlerim"
            });
            userMenuList.Add(new MenuModel.Menu()
            {
                ConnectedMenuItemId = 2,
                MenuItemId = 8,
                Name = "Zaman çizelgesi"
            });

            return userMenuList;

        }

    }
}
