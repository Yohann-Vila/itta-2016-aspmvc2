using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstCat;

namespace CatExercise.Dao
{
    public class CatThreadDAO : ICatThreadDAO
    {
        CatDB db = new CatDB();

        public CatThread FindByID(int id)
        {
            return db.CatThreads.FirstOrDefault(thread => thread.CatThreadId == id);
        }

        public ICollection<CatThread> FindByLogin(string login, bool actif)
        {
            return db.CatThreads.Where(thread => thread.User.Login == login && thread.User.Banish == !actif).ToList();
        }

        public ICollection<CatThread> FindByTitle(string partialTitle, bool actif)
        {
            return db.CatThreads.Where(thread => !(thread.Deleted && actif)).Where(thread => thread.Titre.Contains(partialTitle)).ToList();
        }

        public ICollection<CatThread> GetAll(bool actif)
        {
            return db.CatThreads.ToList();
        }

        public bool Insert(CatThread catThread)
        {
            db.CatThreads.Add(catThread);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(CatThread catThread)
        {
            throw new NotImplementedException();
        }
    }
}