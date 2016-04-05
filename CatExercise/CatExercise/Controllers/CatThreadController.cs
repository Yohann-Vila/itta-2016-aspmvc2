using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatExercise.Dao;
using CatExercise.Models;

namespace CatExercise.Controllers {
    public class CatThreadController : Controller {
        ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();

        public ActionResult Index() {
            return View("find");
        }

        public ActionResult Edit(int catThreadId) {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null) {
                return HttpNotFound();
            }
            return View(thread);
        }

        public ActionResult Create() {
            return View();
        }

        public ActionResult Details(int catThreadId) {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null) {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Delete(int catThreadId) {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null) {
                return HttpNotFound();
            }
            throw new NotImplementedException();
        }

        //////////////////
        [HttpGet]
        public ActionResult Find(string what) {
            ICollection<CatThreadView> threads = null;
            if (what == "*") {
                threads = dao.GetAll();
            } else {
                threads = dao.FindByTitle(what);
            }
            if (threads != null && threads.Count > 0) {
                return View("Result", threads);
            } else {
                ViewBag.NoResult = "Pas de résultat";
                return View("Find");

            }

        }


    }
}
