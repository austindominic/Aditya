using Aditya.Models.Page;
using Aditya.Models.Repository.Page;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class HomeController : Controller
    {
        private PageContentRepository _pageContentRep = new PageContentRepository();

        // GET: Home
        public ActionResult Index()
        {

            return View(_pageContentRep.GetByContentName("Home"));
        }

     

        //[HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/assets/img/parallax/"), pic);

            
                var filename = Request["filename"];
                try
                {
                    file.SaveAs(path);

                    FileInfo imageDelete = new FileInfo(Server.MapPath("~/assets/img/parallax/" + filename));
                    if (imageDelete.Exists)
                    {
                        imageDelete.Delete();
                    }
                    // Get a bitmap.
                    Bitmap imageComp = new Bitmap(path);
                    ImageCodecInfo jpgEncoder = Security.GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    imageComp.Save(Server.MapPath("~/assets/img/parallax/" + filename), jpgEncoder, myEncoderParameters);
                    imageComp.Dispose();
                    FileInfo info1 = new FileInfo(path);
                    if (info1.Exists)
                    {
                        info1.Delete();
                    }
                }
                catch (Exception ex)
                {
                    string messageError = ex.Message.ToString();
                }
            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
        }



    }
}