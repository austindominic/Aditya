using Aditya.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.Menu
{
    public class MainMenuRepository : Repository<MainMenu>
    {
        public List<MainMenu> mainMenu(string menuRoot)
        {
            return DbSet.Where(m => m.MenuRoot.Contains(menuRoot)).ToList();
        }
    }
}