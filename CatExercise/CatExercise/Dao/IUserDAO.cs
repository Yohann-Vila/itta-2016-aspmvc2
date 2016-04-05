using CatExercise.Models;
using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public interface IUserDAO {
        ICollection<UserView> getPostsFromUser(String Login);
        ICollection<User> GetAll();
        User Find(String login);
        bool Insert(User user);
        bool Update(User user);

    }
}