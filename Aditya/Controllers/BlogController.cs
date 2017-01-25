using Aditya.Models.Blog;
using Aditya.Models.Repository.Blog;
using Aditya.Models.Repository.User;
using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
   public class BlogController : Controller
    {
        // GET: Blog
        private BlogContentRepository _blogContentRepository = new BlogContentRepository();
        private BlogSectionRepository _blogSectionRepository = new BlogSectionRepository();
        private UserCommentsRepository _BlogCommentRepository = new UserCommentsRepository();
        [Route("blog/all")]
        public ActionResult Index()
        {
            return View();
        }

 
        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("blog/Create")]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (file == null) return RedirectToAction("/Index");
            bool blogApproved = false;
            string url = Request["BlogCaption"].Replace(" ", "_").Trim();
            string imageFileName = DateTime.Now.ToString("ddMMMyyyyHHMM") + url + file.FileName;
            if (Session["isAdmin"] != null) {
                blogApproved = true;
            }


            if (Security.UploadFile(file, "Blog", imageFileName) != null)
            {

                BlogContent blogContent = new BlogContent { BlogCaption = Request["BlogCaption"], BlogMainContent = Request["BlogMainContent"], BackgroundImage = imageFileName, BlogTags = Request["BlogTags"], BlogUrl = url, UserId = (Guid)Session["userUid"], isApproved = blogApproved, BlogCreatedDate = DateTime.Now, BlogPostingDate = Convert.ToDateTime(Request["BlogPostingDate"]),BlogCategoryId  = Convert.ToInt32(Request["BlogCategoryId"])};

                _blogContentRepository.Add(blogContent);
                _blogContentRepository.SaveChanges();
                return RedirectToAction("/Index");
            }


            return View();
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {  
            return View(_blogContentRepository.Get(id));
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogContent blogContent)
        {
            if (ModelState.IsValid)
            {
                _blogContentRepository.Update(blogContent);
                _blogContentRepository.SaveChanges();
                return RedirectToAction("~/Blog/" + blogContent.BlogUrl);
            }

            return View(blogContent);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_blogContentRepository.Get(id));
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _blogContentRepository.Delete(id);
            _blogContentRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _blogSectionRepository.Dispose();
                _blogContentRepository.Dispose();
                _BlogCommentRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public ActionResult BlogSidebar()
        {
            return PartialView();
        }
        [Route("blog/{BlogUrl}")]
        public ActionResult Blog(string BlogUrl)
        {
            return View(_blogContentRepository.GetBlogContentByUrl(BlogUrl));
        }

        [HttpPost]
        [Route("blog/AddBlogSection")]
        public void AddBlogSection(BlogSection blogSection) {
            if (ModelState.IsValid)
            {
                _blogSectionRepository.Add(blogSection);
                _blogSectionRepository.SaveChanges();
            }
               
        }
        [HttpPost]
        [Route("blog/AddBlogComment")]
        public void AddBlogComment(UserComments BlogComment) {
            BlogComment.UserId =  Guid.Parse(Session["userUid"].ToString());
            BlogComment.CreatedDate = DateTime.Now;

            if (ModelState.IsValid) {
                _BlogCommentRepository.Add(BlogComment);
                _BlogCommentRepository.SaveChanges();
            }
        }
    }
}