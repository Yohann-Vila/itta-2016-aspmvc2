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
        //
        // GET: /CatThread/

        public ActionResult Index()
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            ICollection<CatThreadView> catThreads = dao.GetAll();
            return View(catThreads);
        }

    }
}
