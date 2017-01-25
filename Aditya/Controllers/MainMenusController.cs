using Aditya.Models;
using Aditya.Models.Menu;
using Aditya.Models.Repository.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{
    public class MainMenusController : Controller
    {
       

        private readonly MainMenuRepository _mainMenuRepository = new MainMenuRepository();

        // GET: MainMenus
        public ActionResult Index()
        {
            return View(_mainMenuRepository.GetAll());
        }
 
        // GET: MainMenus/Details/5
        public ActionResult Details(int id)
        { 
            return View(_mainMenuRepository.Get(id));
        }

        // GET: MainMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainMenu mainMenu)
        {
            if (ModelState.IsValid)
            {
               
               _mainMenuRepository.Add(mainMenu);
                _mainMenuRepository.SaveChanges();
                return RedirectToAction("/Index");
            }

            return View(mainMenu);
        }

        // GET: MainMenus/Edit/5
        public ActionResult Edit(int id)
        { 
            return View(_mainMenuRepository.Get(id));
        }

        // POST: MainMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainMenu mainMenu)
        {
            if (ModelState.IsValid)
            {
                _mainMenuRepository.Update(mainMenu);
                _mainMenuRepository.SaveChanges();
                return RedirectToAction("/Index");
            }
            return View(mainMenu);
        }

 
        // POST: MainMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
           
            _mainMenuRepository.Delete(id);
            _mainMenuRepository.SaveChanges();
            return RedirectToAction("/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _mainMenuRepository.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult FooterMenu()
        {
            return PartialView(_mainMenuRepository.mainMenu("f"));
        }
    }
}