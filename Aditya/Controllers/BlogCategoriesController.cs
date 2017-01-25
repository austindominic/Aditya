using Aditya.Models.Blog;
using Aditya.Models.Repository.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class BlogCategoriesController : Controller
    {
        BlogCategoryRepository _blogCategoryRepository = new BlogCategoryRepository();
        BlogContentRepository _blogContentRepository = new BlogContentRepository();
        // GET: BlogCategories
        [Route("blogcategory/all")]
        public ActionResult Index()
        {
            return View(_blogCategoryRepository.GetAll());
        }

        // GET: BlogCategories/Details/5
        [Route("blogcategory/{id}")]
        public ActionResult Details(int id)

        {

            return View(_blogCategoryRepository.Get(id));
        }

        // GET: BlogCategories/Create

        // POST: BlogCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Create(HttpPostedFileBase file)
        {

            if (file == null) return RedirectToAction("/Index");
            string imageFileName = DateTime.Now.ToString("ddMMMyyyyHHMM") + Request["BlogCategoryName"] + file.FileName;


            if (Security.UploadFile(file, "Blog", imageFileName) != null)
            {
                BlogCategory blogCategory = new BlogCategory { BlogCategoryName = Request["BlogCategoryName"], BackgroundImage = imageFileName };
                _blogCategoryRepository.Add(blogCategory);
                _blogCategoryRepository.SaveChanges();
                return RedirectToAction("/Index");
            }

            return RedirectToAction("/Index");
        }

        // GET: BlogCategories/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_blogCategoryRepository.Get(id));
        }

        // POST: BlogCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                _blogCategoryRepository.Update(blogCategory);
                _blogCategoryRepository.SaveChanges();
                return RedirectToAction("/Index");
            }
            return View(blogCategory);
        }

        // GET: BlogCategories/Delete/5
        public ActionResult Delete(int id)
        {
            _blogCategoryRepository.Delete(id);
            _blogCategoryRepository.SaveChanges();
            return RedirectToAction("/Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _blogCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult BlogCommentsView(int id)
        {


            return PartialView(_blogContentRepository.Get(id));
        }


    }
}