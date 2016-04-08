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
        private CatDB model = new CatDB();
     
        public ICollection<UserView> getPostsFromUser(String Login)
        {
            var users = model.Users.Where(c => c.Login.Equals(Login)).ToList();
            ICollection<UserView> result = users.Select(
                c => CreateModelUserViewFromModel(c)
                ).ToList();
            return result;
        }

        private UserView CreateModelUserViewFromModel(User user)
        {
            UserView userview = new UserView()
            {
                Login = user.Login,
                Pseudo = user.Pseudo,
                UserID = user.UserID,
                Banish = user.Banish,
                Seclevel = user.Seclevel,
                Creationdate = user.Creationdate,
            };

            return userview;
        }

        public User Find(String login)
        {
            User user = db.Users.FirstOrDefault(userx => userx.Login.Equals(login));
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public UserView FindByID(int id)
        {
            var user = db.Users.FirstOrDefault(userx => userx.UserID == id);
            if (user != null)
            {
                return CreateModelUserViewFromModel(user);
            }
            return null;

        }
        public ICollection<UserView> GetAll()
        {

            ICollection <UserView> vusers = db.Users.ToList().Select(u => CreateModelUserViewFromModel(u)).ToList();
            return vusers;
        }


        public bool Update(UserView userView)
        {
            if (userView == null)
            {
                throw new ArgumentNullException("UserDAO : trying to Update with a null parameter");
            }

            User user = db.Users.FirstOrDefault(ct => ct.UserID == userView.UserID);
            if (userView == null)
            {
                return false;
            }


         // user.Creationdate = userView.Creationdate;
            user.Login = userView.Login;
            user.Password = userView.Password;
            user.Pseudo = userView.Pseudo;
           // user.UserID = userView.UserID;
            user.Banish = userView.Banish;
            user.Seclevel = userView.Seclevel;

            return db.SaveChanges() > 0;
        }

        public bool Insert(UserView userView)
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
            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }
        public UserView getUserIfExist(UserView user) {
            User u = db.Users.FirstOrDefault(ct => ct.Login == user.Login && ct.Password == user.Password);
            return u == null ? null : CreateModelUserViewFromModel(u);
        }



        public UserView getUserIfExist(UserViewLogin user) {
            User u = db.Users.FirstOrDefault(ct => ct.Login == user.Login && ct.Password == user.Password);
            return u == null ? null : CreateModelUserViewFromModel(u);
        }
    }
}
