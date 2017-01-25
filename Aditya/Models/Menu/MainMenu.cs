using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Menu
{
    public class MainMenu
    {

        public MainMenu()
        {
            this.ChildMenuItems = new List<MainMenu>();
        }

        [Key]
        public int MenuItemId { get; set; }

        public string MenuItemName { get; set; }
        public string MenuItemPath { get; set; }
        public string MenuRoot { get; set; }
        public int MenuOrder { get; set; }
        public Nullable<int> ParentItemId { get; set; }
        public virtual ICollection<MainMenu> ChildMenuItems { get; set; }
    }
}