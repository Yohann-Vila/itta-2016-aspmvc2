﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatExercise.Models;

namespace CatExercise.Dao {
    public interface ICatThreadDAO {
        /// <summary>
        /// Returns all CatThread
        /// </summary>
        /// <param name="onlyActif">if set to true, returns only the active threads.
        /// if set to false, returns all threads.</param>
        /// <returns></returns>
        ICollection<CatThreadView> GetAll(bool onlyActif);
        ICollection<CatThreadView> GetAll();

        /// <summary>
        /// Returns CatThread created by a certain user
        /// </summary>
        /// <param name="login">the exact login name of a user</param>
        /// <param name="onlyActif">if set to true, returns only the active threads.
        /// if set to false, returns all threads.</param>
        /// <returns></returns>
        ICollection<CatThreadView> FindByLogin(String login, bool onlyActif);
        ICollection<CatThreadView> FindByLogin(String login);

        /// <summary>
        /// Returns CatThread containing a certain string in the title
        /// </summary>
        /// <param name="partialTitle">a string that is part of some title(s)</param>
        /// <param name="onlyActif">if set to true, returns only the active threads.
        /// if set to false, returns all threads.</param>
        /// <returns></returns>
        ICollection<CatThreadView> FindByTitle(String partialTitle, bool onlyActif);
        ICollection<CatThreadView> FindByTitle(String partialTitle);

        bool Update(CatThreadView catThreadView);
        bool Insert(CatThreadView catThreadView);
        CatThreadView FindByID(int id);
    }
}
