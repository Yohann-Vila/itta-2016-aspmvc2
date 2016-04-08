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
                    var authTicket = new FormsAuthenticationTicket(1,userFromDB.Login,DateTime.Now,DateTime.Now.AddMinutes(120),false,role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    Session.Add("userName", userFromDB.Login);
                    Session.Add("userID", userFromDB.UserID);

                    if (returnUrl != null && returnUrl.Length > 0) {
                        return Redirect(returnUrl);
                    } else {
                        return RedirectToAction("Index", "CatThread");
                    }
                }
            }
            ModelState.AddModelError("", "Le nom d'utilisateur ou mot de passe fourni est incorrect.");
            return View(model);
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
                if (dao.Find(model.Login) == null) {
                    model.Seclevel = 0;
                    model.Banish = false;
                    model.Creationdate = DateTime.Now;
                    if (dao.Insert(model)) {
                        FormsAuthentication.SetAuthCookie(model.UserID.ToString(), false);
                        Session.Add("userName", model.Login);
                        if (returnUrl != null && returnUrl.Length > 0) {
                            return Redirect(returnUrl);
                        } else {
                            return RedirectToAction("Index", "CatThread");
                        }
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
            return RedirectToAction(returnUrl);
        }
    }
}