using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao
{
    public class UserDAO : IUserDAO
    {
        //
        // GET: /Default1/

        public User Find(String login)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> getAll(string login, bool actif)
        {
            throw new NotImplementedException();
        }

        public bool insert(User user)
        {
            throw new NotImplementedException();
        }

        public bool update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CatThread catThread)
        {
            throw new NotImplementedException();
        }

    }
}
