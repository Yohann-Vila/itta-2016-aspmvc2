using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao
{
    public class UserDAO : IUserDAO
    {
        CatDB db = new CatDB();

        // GET: /Default1/

        public User Find(String login)
        {
            User user = db.Users.FirstOrDefault(userx => userx.Login == login);
            if (user == null)
            {
                return null;
            }
           // return CreateModelViewFromModel(user);
            return user;
        }

        public ICollection<User> GetAll()
        {
            IList<User> users = db.Users.Where(userx => userx.Banish != null).ToList();
           
            return users;
        }

  
        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User user)
        {
            throw new NotImplementedException();
        }

    }
}
