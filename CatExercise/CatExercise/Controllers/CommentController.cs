using CatExercise.Dao;
using CatExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatExercise.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index(int id)
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            CatThreadView ct = dao.FindByID(id);
            //ICollection<CommentView> cms = dao.getPostsFromThread(id, true);
            //return View(cms);
            throw new NotImplementedException();

        }
    }
}