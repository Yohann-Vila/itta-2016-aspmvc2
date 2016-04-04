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
        public ActionResult Index()
        {
            ICommentDAO dao = DAOFactory.getInstanceOfComment();
            ICollection<CommentView> cms = dao.getPostsFromThread(1, false);
            return View(cms);

        }
    }
}