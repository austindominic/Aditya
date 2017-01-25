using Aditya.Models.Gallery;
using Aditya.Models.Page;
using Aditya.Models.Repository.Gallery;
using Aditya.Models.Repository.Page;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    
    public class PageController : Controller
    {
        private readonly PageContentRepository _contentRepository = new PageContentRepository();
        private readonly GalleryMainRepository _gallery = new GalleryMainRepository();
        private readonly SectionRepository _secRep = new SectionRepository();
        private readonly TestimonialsRepository _testimonialsRepository = new TestimonialsRepository();
        private readonly YoutubeLinkRepository _youtubeLink = new YoutubeLinkRepository();
 
        //private DatabaseContext db = new DatabaseContext();
        // GET: Page

        public ActionResult Index(string contentName)
        {
         
            return View(_contentRepository.GetByContentName(contentName));
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: PageContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(PageContent pageContent)
        {
            if (ModelState.IsValid)
            {
                _contentRepository.Add(pageContent);

                _contentRepository.SaveChanges();
                RedirectToAction("Index", pageContent.PageName);
            }

            return View(pageContent);
        }

        // GET: PageContents/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(_contentRepository.Get(id));
        }

        // POST: PageContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(PageContent pageContent)
        {
            if (ModelState.IsValid)
            {
                _contentRepository.Update(pageContent);
                //db.Entry(pageContent).State = EntityState.Modified;
                //db.SaveChanges();
                _contentRepository.SaveChanges();
                return RedirectToAction("Index", pageContent.PageName);
            }
            return View(pageContent);
        }

        public ActionResult AddYoutubeLink()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddYoutubeLink(YoutubeVideoLinks youtubeVideoLinks)
        {
            _youtubeLink.Add(youtubeVideoLinks);
            _youtubeLink.SaveChanges();
            return RedirectToAction("Index", youtubeVideoLinks.PageContentId);
        }

        public ActionResult EditYoutubeLink(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var youtubeVideoLinks = _youtubeLink.Get((int)id);
            if (youtubeVideoLinks == null)
                return HttpNotFound();
            return View(youtubeVideoLinks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditYoutubeLink(YoutubeVideoLinks youtubeVideoLinks)
        {
            _youtubeLink.Update(youtubeVideoLinks);
            _youtubeLink.SaveChanges();
            return RedirectToAction("Index", youtubeVideoLinks.PageContentId);
        }

        public ActionResult EditSection(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var section = _secRep.Get((int)id);
            if (section == null)
                return HttpNotFound();
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditSection(Section section)
        {
            _secRep.Update(section);
            _secRep.SaveChanges();
            return RedirectToAction("Index", section.PageContentId);
        }

        public ActionResult AddSection()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddSection(Section section)
        {
            _secRep.Add(section);
            _secRep.SaveChanges();
            return RedirectToAction("Index", section.PageContentId);
        }

        [HttpPost]
        public ActionResult DeleteSection()
        {
            string id = Request["sectionID"];
            _secRep.Delete(Convert.ToInt32(id));
            _secRep.SaveChanges();
            return View();
        }

        //Edit Testimonials

        public ActionResult EditTestimonial(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var testimonials = _testimonialsRepository.Get((int)id);
            if (testimonials == null)
                return HttpNotFound();
            return View(testimonials);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditTestimonial(Testimonials testimonials)
        {
            _testimonialsRepository.Update(testimonials);
            _testimonialsRepository.SaveChanges();
            return RedirectToAction("Index", testimonials.PageContentId);
        }

        public ActionResult AddTestimonial(HttpPostedFileBase file)
        {
            if (file == null) return View();
            var desiredFileName = DateTime.Now.ToString("ddMMMyyyyHHMM") +
                                  Request["PageContentId"] + file.FileName;

            var pic = Path.GetFileName(file.FileName);
            var path = Path.Combine(
                Server.MapPath("~/assets/img/testimonial/"), pic);

            var filename = desiredFileName;
            try
            {
                file.SaveAs(path);

                var imageDelete = new FileInfo(Server.MapPath("~/assets/img/testimonial/" + filename));
                if (imageDelete.Exists)
                    imageDelete.Delete();
                // Get a bitmap.
                var imageComp = new Bitmap(path);
                var jpgEncoder = Security.GetEncoder(ImageFormat.Jpeg);
                var myEncoder = Encoder.Quality;
                var myEncoderParameters = new EncoderParameters(1);
                var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                imageComp.Save(Server.MapPath("~/assets/img/testimonial/" + filename), jpgEncoder,
                    myEncoderParameters);
                imageComp.Dispose();
                var info1 = new FileInfo(path);
                if (info1.Exists)
                    info1.Delete();
                var testimonials = new Testimonials
                {
                    UserName = Request["UserName"],
                    UserImage = filename,
                    PageContentId = Convert.ToInt32(Request["PageContentId"]),
                    UserDescription = Request["UserDescription"],
                    Testimonial = Request["Testimonial"]
                };
                _testimonialsRepository.Add(testimonials);
                _testimonialsRepository.SaveChanges();
                return RedirectToAction("Index", testimonials.PageContentId);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }

            // return View();

            //return View();
        }

        //Gallery

        public ActionResult EditGallery(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var galleryMain = _gallery.Get((int)id);
            if (galleryMain == null)
                return HttpNotFound();
            return View(galleryMain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditGallery(GalleryMain galleryMain)
        {
            _gallery.Update(galleryMain);
            _gallery.SaveChanges();
            return RedirectToAction("Index", galleryMain.PageContentId);
        }

        public ActionResult AddGallery(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var desiredFileName = DateTime.Now.ToString("ddMMMyyyyHHMM") +
                                      Request["PageContentId"] + file.FileName;
                //CreateDateTime
                var pic = Path.GetFileName(file.FileName);
                var path = Path.Combine(
                    Server.MapPath("~/assets/img/portfolio/"), pic);

                var filename = desiredFileName;
                try
                {
                    file.SaveAs(path);

                    var imageDelete = new FileInfo(Server.MapPath("~/assets/img/portfolio/" + filename));
                    if (imageDelete.Exists)
                        imageDelete.Delete();
                    // Get a bitmap.
                    var imageComp = new Bitmap(path);
                    var jpgEncoder = Security.GetEncoder(ImageFormat.Jpeg);
                    var myEncoder = Encoder.Quality;
                    var myEncoderParameters = new EncoderParameters(1);
                    var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    imageComp.Save(Server.MapPath("~/assets/img/portfolio/" + filename), jpgEncoder, myEncoderParameters);
                    imageComp.Dispose();
                    var info1 = new FileInfo(path);
                    if (info1.Exists)
                        info1.Delete();
                    var galleryMain = new GalleryMain
                    {
                        GalleryName = Request["GalleryName"],
                        GalleryImageLink = filename,
                        PageContentId = Convert.ToInt32(Request["PageContentId"]),
                        GalleryDescription = Request["GalleryDescription"],
                        CreateDateTime = Convert.ToDateTime(Request["CreateDateTime"])
                    };
                    _gallery.Add(galleryMain);
                    _gallery.SaveChanges();
                    return RedirectToAction("Index", galleryMain.PageContentId);
                }
                catch (Exception ex)
                {
                    return View(ex.Message.ToString());
                }

                // return View();
            }

            return View();
            // after successfully uploading redirect the user
        }

        [Route("FreePublicPrograms")]
        public ActionResult FreePublicProgram (){
            return View();
        }

    }
}