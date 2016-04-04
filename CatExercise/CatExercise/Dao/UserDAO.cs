using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatExercise.Models;

namespace CatExercise.Dao
{
    public class UserDAO : IUserDAO
    {
        CatDB db = new CatDB();

        // GET: /Default1/

        public User Find(String login)
        {
            User user = db.Users.FirstOrDefault(userx => userx.Login.Equals(login));
            if (user == null)
            {
                return null;
            }
           // return CreateModelViewFromModel(user);
            return user;
        }

        public ICollection<User> GetAll()
        {
            IList<User> users = db.Users.Where(userx => userx.Banish != false).ToList();
           
            return users;
        }


        public bool Update(User userView)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User userView)
        {
            if (userView == null)
            {
                return false;
            }

            var user = db.Users.Create();
            user.Creationdate = userView.Creationdate;
            user.Login = userView.Login;
            user.Password = userView.Password;
            user.Pseudo= userView.Pseudo;
           // user.UserID = userView.UserID;
            user.Banish = userView.Banish;
            user.Seclevel = userView.Seclevel;
 
            return db.SaveChanges() > 0;
        }

    }
}
