using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class MenuHeaderController : Controller
    {
        // GET: MenuHeader
        [ChildActionOnly]
        public ActionResult HeaderMenu()
        {
            return PartialView();
        }
    }
}