using CatExercise.Models;
using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public interface IUserDAO {
        ICollection<UserView> getPostsFromUser(String Login);
        UserView FindByID(int UserID);
        ICollection<User> GetAll();
        UserView Find(String login);
        bool Insert(User user);
        bool Update(User user);

    }
}