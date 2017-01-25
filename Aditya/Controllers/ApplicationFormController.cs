using Aditya.Models.Application;
using Aditya.Models.Repository.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class ApplicationFormController : Controller
    {
        ApplicationRepository _applicationRepository = new ApplicationRepository();
        
        // GET: ApplicationForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicationCreate(ApplicationForm applicationForm)
        {

            Scripts script = new Scripts();

            _applicationRepository.Add(applicationForm);
            _applicationRepository.SaveChanges();

            Communication.ConfirmationMail(applicationForm.CompleteName, applicationForm.UserEmailId);

            return RedirectToAction("/Index");

        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}