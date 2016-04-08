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
        UserView FindByLogin(String login);
        ICollection<UserView> GetAll();
        User Find(String login);
        bool Insert(UserView user);
        bool Update(UserView user);

        UserView getUserIfExist(UserView user);


        UserView getUserIfExist(UserViewLogin model);
    }
}