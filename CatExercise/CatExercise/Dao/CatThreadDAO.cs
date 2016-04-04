using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstCat;
using CatExercise.Models;

namespace CatExercise.Dao
{
    public class CatThreadDAO : ICatThreadDAO
    {
        CatDB db = new CatDB();

        public CatThreadView FindByID(int id)
        {
            CatThread cat = db.CatThreads.FirstOrDefault(thread => thread.CatThreadId == id);
            return new CatThreadView()
            {
                CatThreadId = cat.CatThreadId,
                //Comments = null /* cat.Comments */,
                CreationDate = cat.CreationDate,
                Deleted = cat.Deleted,
                Titre = cat.Titre,
                UriPhoto = cat.UriPhoto,
                UserName = cat.User.Login /* cat.User */
                
            };
        }

        public ICollection<CatThreadView> FindByLogin(string login, bool actif)
        {
            throw new NotImplementedException();
            //return db.CatThreads.Where(thread => thread.User.Login == login && thread.User.Banish == !actif).ToList();
        }

        public ICollection<CatThreadView> FindByTitle(string partialTitle, bool actif)
        {
            throw new NotImplementedException();
            //return db.CatThreads.Where(thread => !(thread.Deleted && actif)).Where(thread => thread.Titre.Contains(partialTitle)).ToList();
        }

        public ICollection<CatThreadView> GetAll(bool actif)
        {
            throw new NotImplementedException();
            //return db.CatThreads.ToList();
        }

        public bool Insert(CatThreadView catThread)
        {
            throw new NotImplementedException();
            //db.CatThreads.Add(catThread);
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch
            //{
            //    return false;
            //}
            //return true;
        }

        public bool Update(CatThreadView catThread)
        {
            throw new NotImplementedException();
        }
    }
}