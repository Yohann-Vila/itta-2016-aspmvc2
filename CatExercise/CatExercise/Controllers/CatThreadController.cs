﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatExercise.Dao;
using CatExercise.Models;
using System.IO;

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
        [Authorize]
        public ActionResult Create() {
            //CatThreadView miaou = new CatThreadView()
            //{
            //    Titre = "",
            //    CreationDate = DateTime.Now,
            //    UriPhoto = "",
            //    Deleted = false,
            //    UserName = User.Identity.Name,
            //    comments = null,
            //};
            //int id = dao.Insert(miaou);
            //return RedirectToAction("Edit",new { id = id });
            return View(new CatThreadView());
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(CatThreadView cathread) {
            if (ModelState.IsValid) {
                // Use your file here
                using (MemoryStream memoryStream = new MemoryStream()) {
                    cathread.CreationDate = DateTime.Now;

                    cathread.UserID = (int)Session["userID"];
                    cathread.UserName = (String)Session["userName"];
                    cathread.File.InputStream.CopyTo(memoryStream);
                    int name = dao.Insert(cathread);
                    String ext = "";
                    if (cathread.File.FileName.Contains("jpg")) {
                        ext = "jpg";
                    }
                    if (cathread.File.FileName.Contains("png")) {
                        ext = "jpg";
                    }
                    if (cathread.File.FileName.Contains("gif")) {
                        ext = "jpg";
                    }
                    if (ext == String.Empty) {
                        ModelState.AddModelError("File", "Merci de choisir une extension valide");
                    }
                    var fileName = name + "." + ext;

                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    cathread.UriPhoto = path;
                    dao.Update(cathread);
                    return RedirectToAction("AjoutOK");

                }
            }
            return View(cathread);
        }
        [HttpGet]
        public ActionResult Details(int? id) {
            CatThreadView thread = dao.FindByID(id.HasValue ? id.Value : 0);
            if (thread == null) {
                return HttpNotFound();
            }
            return View(thread);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(int? id, string commentContent)
        {
            CatThreadView thread = dao.FindByID(id.HasValue ? id.Value : 0);

            if (thread == null)
            {
                return HttpNotFound();
            }
 
            UserView user = DAOFactory.getInstanceOfUser().FindByLogin(User.Identity.Name);
            var daoComment = DAOFactory.getInstanceOfComment();
            CommentView comment = new CommentView()
            {
                catThread = thread,
                Content = commentContent,
                CreationDate = DateTime.Now,
                Deleted = false,
                UserName = user.Login,
                UserID = user.UserID
            };
            
            daoComment.insert(comment);

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
