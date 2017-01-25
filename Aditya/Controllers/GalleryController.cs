using Aditya.Models.Repository.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class GalleryController : Controller
    {
        private PageContentRepository _pageContentRepository = new PageContentRepository();

        // GET: Gallery
        [Route("gallery/all")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("gallery/{id}")]
        public ActionResult Calender(int id)
        {
            return View(_pageContentRepository.Get(id));
        }
    }
}