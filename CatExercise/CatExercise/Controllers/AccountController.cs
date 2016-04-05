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
                        return RedirectToAction("Index","CatThread");
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
        [HttpGet]
        public ActionResult LogOff(string returnUrl) {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction(returnUrl);
        }
    }
}