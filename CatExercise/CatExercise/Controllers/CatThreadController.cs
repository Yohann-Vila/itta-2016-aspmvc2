using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatExercise.Dao;
using CatExercise.Models;

namespace CatExercise.Controllers
{
    public class CatThreadController : Controller
    {
       ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();

        public ActionResult Index()
        {
            ICollection<CatThreadView> catThreads = dao.GetAll();
            return View(catThreads);
        }

        public ActionResult Edit(int catThreadId)
        {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null) {
                return HttpNotFound();
            }
            return View(thread);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int catThreadId)
        {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Delete(int catThreadId)
        {
            CatThreadView thread = dao.FindByID(catThreadId);
            if (thread == null)
            {
                return HttpNotFound();
            }
            throw new NotImplementedException();
        }

        //////////////////

    }
}
