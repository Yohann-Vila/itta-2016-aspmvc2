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
        public ActionResult Login(UserView model, string returnUrl) {
            if (ModelState.IsValid) {
                IUserDAO dao = DAOFactory.getInstanceOfUser();
                UserView userFromDB = dao.getUserIfExist(model);
                if (userFromDB != null) {
                    FormsAuthentication.SetAuthCookie(userFromDB.UserID.ToString(), false);
                    Session.Add("userName", userFromDB.Login);
                    if (returnUrl != null && returnUrl.Length > 0) {
                        return RedirectToAction(returnUrl);
                    } else {
                        return RedirectToAction("Index", "CatThread");
                    }
                }
            }
            ModelState.AddModelError("", "Le nom d'utilisateur ou mot de passe fourni est incorrect.");
            return View(model);
        }
        [HttpGet]
        public String TestLogin() {
            return "OK";
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
                            return RedirectToAction(returnUrl);
                        } else {
                            return RedirectToAction("Index", "CatThread");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Le nom d'utilisateur exist deja");
            return View(model);
        }

        public ActionResult LogOff(string returnUrl) {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction(returnUrl);
        }
    }
}