using CatExercise.Dao;
using CatExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CatExercise.Controllers {
    [Authorize]
    public class AccountController : Controller {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewLogin model, string returnUrl) {
            if (ModelState.IsValid) {
                IUserDAO dao = DAOFactory.getInstanceOfUser();
                UserView userFromDB = dao.getUserIfExist(model);
                if (userFromDB != null) {
                    //FormsAuthentication.SetAuthCookie(userFromDB.UserID.ToString(), false);
                    string role = "user";
                    if (userFromDB.Seclevel == 100) {
                        role += ";admin";
                    }
                    return AuthUser(returnUrl, userFromDB, role);
                }
            }
            ModelState.AddModelError("", "Le nom d'utilisateur ou mot de passe fourni est incorrect.");
            return View(model);
        }

        private ActionResult AuthUser(string returnUrl, UserView userFromDB, string role) {
            var authTicket = new FormsAuthenticationTicket(1, userFromDB.UserID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(120), false, role);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            var nameCookie = new HttpCookie("name", userFromDB.Login);

            HttpContext.Response.Cookies.Add(authCookie);
            HttpContext.Response.Cookies.Add(nameCookie);

            if (returnUrl != null && returnUrl.Length > 0 && !returnUrl.Contains("LogOff")) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "CatThread");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public String TestLogin() {
            Boolean test = User.IsInRole("user");
            Boolean test2 = User.IsInRole("admin");

            return User.ToString();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserView model, string returnUrl) {
            if (ModelState.IsValid) {
                IUserDAO dao = DAOFactory.getInstanceOfUser();
                if (dao.FindByLogin(model.Login) == null) {
                    model.Seclevel = 0;
                    model.Banish = false;
                    model.Creationdate = DateTime.Now;
                    if (dao.Insert(model)) {
                        return AuthUser(returnUrl, dao.FindByLogin(model.Login), "user");
                    }
                } else {
                    ModelState.AddModelError("", "Le nom d'utilisateur exist deja");
                }
            }
            return View(model);
        }

        public ActionResult LogOff(string returnUrl) {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View();
        }
    }
}