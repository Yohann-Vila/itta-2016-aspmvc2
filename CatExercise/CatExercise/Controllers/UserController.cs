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
        IUserDAO dao = DAOFactory.getInstanceOfUser();
        [HttpGet]
        public ActionResult Index(int? id)
        {
         
           // UserView user = dao.FindByID(id);
           
            ICollection<UserView> vuser = dao.GetAll();
            return View(vuser);

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            UserView vuser = dao.FindByID(id.HasValue ? id.Value : 0);
           // UserView vuser = dao.FindByID(id);
            if (vuser == null)
            {
                return HttpNotFound();
            }

            return View(vuser);
        }
        [HttpPost]
        public ActionResult Edit(UserView vuser)
        {

            if (vuser == null)
            {
                return HttpNotFound();
            }

            dao.Update(vuser);

            return View(vuser);
        }
    }
}