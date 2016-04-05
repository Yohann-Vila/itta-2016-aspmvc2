using CatExercise.Dao;
using CatExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatExercise.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            IUserDAO dao = DAOFactory.getInstanceOfUser();
            ICollection<UserView> user = dao.getPostsFromUser("test");
            return View(user);

        }
    }
}