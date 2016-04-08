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

        [HttpGet]
        public ActionResult Index() {
            return View("find");
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            CatThreadView thread = dao.FindByID(id.HasValue ? id.Value : 0);
            if (thread == null) {
                return HttpNotFound();
            }
            return View(thread);
        }

        [HttpPost]
        public ActionResult Edit(CatThreadView thread)
        {
            if (thread == null)
            {
                return HttpNotFound();
            }

            dao.Update(thread);
            return RedirectToAction("Details", new { id = thread.CatThreadId });
        }

        [HttpGet]
        public ActionResult Create() {
            CatThreadView miaou = new CatThreadView()
            {
                Titre = "",
                CreationDate = DateTime.Now,
                UriPhoto = "",
                Deleted = false,
                UserName = "",
                comments = null,
            };
            int id = dao.Insert(miaou);
            return RedirectToAction("Edit",new { id = miaou.CatThreadId });
        }

        [HttpGet]
        public ActionResult Details(int? id) {
            CatThreadView thread = dao.FindByID(id.HasValue ? id.Value : 0);
            if (thread == null) {
                return HttpNotFound();
            }
            return View(thread);
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult Delete(int? id, string whatIn) {
            return DeleteORNot(id.HasValue ? id.Value : 0, whatIn, true);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult UnDelete(int? id, string whatIn) {
            return DeleteORNot(id.HasValue ? id.Value : 0, whatIn, false);
        }
        private ActionResult DeleteORNot(int id, string whatIn, bool delete) {
            CatThreadView thread = dao.FindByID(id);
            thread.Deleted = delete;
            if (thread == null) {
                return HttpNotFound();
            }
            dao.Update(thread);
            return RedirectToAction("Find", new { what = whatIn });
        }
        //////////////////
        [HttpGet]
        public ActionResult Find(string what) {
            ICollection<CatThreadView> threads = null;
            if (what == null || what == "*" || what.Length == 0) {
                if (User.IsInRole("admin")) {
                    threads = dao.GetAll();
                } else {
                    threads = dao.GetAll(true);
                }
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
