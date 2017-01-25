using Aditya.Models.Repository.User;
using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Controllers
{

    public class LoginController : Controller
    {
        private UserMainRepository _userMainRepository = new UserMainRepository();
        private UserRoleRepository _userRoleRepository = new UserRoleRepository();
        private UserStatusRepository _userStatusRepository = new UserStatusRepository();

        // GET: Login
        public ActionResult Login()
        {
            // Communication.ConfirmationMail("Austin", "austindominic@hotmail.com");
            string[] roleRoles = new string[] { "Admin", "Editor", "Teacher", "User" };
            if (_userRoleRepository.GetAll().Count == 0)
            {
                foreach (var roleRolesUpdate in roleRoles)
                {
                    _userRoleRepository.Add(new UserRole { UserRoleName = roleRolesUpdate });
                    _userRoleRepository.SaveChanges();
                }
            }

            string[] userStatus = new string[] { "Active", "Email Confirmation Pending", "Need to Update Profile", "Suspended", "Deleted" };
            if (_userStatusRepository.GetAll().Count == 0)
            {
                foreach (var userStatusData in userStatus)
                {
                    _userStatusRepository.Add(new UserStatus { UserStatusName = userStatusData });
                    _userStatusRepository.SaveChanges();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserMain usermain)
        {
            usermain.UserRoleId = 4;
            usermain.UserStatusId = 2;
            usermain.Password = Security.HashSHA1(Request["Password"]);

            if (_userMainRepository.DuplicateUserCheck(usermain.UserName, usermain.UserEmailId).Count == 0)
            {
                _userMainRepository.Add(usermain);
                _userMainRepository.SaveChanges();
                if (Communication.ConfirmationMail(usermain.UserName, usermain.UserEmailId) == true)
                {
                    ViewBag.RegMainMessage = "Your Registration was Success!";
                    ViewBag.RegBodyMessage = "Please login to your registered emailid to confirm!";
                }
                else
                {
                    ViewBag.RegMainMessage = "Your email id is already been registered";
                    ViewBag.RegBodyMessage = "Please click this link to reset your password!";
                }
            }
            else
            {
            }

            return RedirectToAction("Login");
            //  UserMain userMain = new UserMain { UserName};
        }

        [HttpPost]
        public ActionResult LoginClick(UserMain userMain)
        {
            var userData = _userMainRepository.LoginToTheSite(userMain.UserEmailId, Security.HashSHA1(userMain.Password));

            if (userData.Count > 0)
            {
                foreach (var finalData in userData)
                {
                    if (finalData.UserStatusId == 1)
                    {
                        Session["userName"] = finalData.UserName;
                        Session["userEmail"] = finalData.UserEmailId;
                        Session["userUid"] = finalData.UserId;
                        if (finalData.UserRoleId == 1)
                        {
                            Session["isAdmin"] = "Admin";
                        }
                    }
                    if (finalData.UserStatusId == 2)
                    {
                        Session["userUid"] = finalData.UserId;
                        Session["userEmail"] = finalData.UserEmailId;
                    }
                    if (finalData.UserStatusId == 3)
                    {
                        Session["userUid"] = finalData.UserId;
                    }
                }
            }
            return RedirectToAction("Index", "home");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "home");
        }
    }
}