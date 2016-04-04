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
            if (cat == null)
            {
                return null;
            }
            return CreateModelViewFromModel(cat);
        }

        public ICollection<CatThreadView> FindByLogin(string login, bool actif)
        {
            IList<CatThread> catlist = db.CatThreads.Where(thread => thread.User.Login == login && thread.User.Banish == !actif).ToList();
            IList<CatThreadView> ctvlist = catlist.Select( catthread => CreateModelViewFromModel(catthread) ).ToList();
            return ctvlist;
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


        ///////////////////////////////////////////////

        private CatThreadView CreateModelViewFromModel(CatThread ct)
        {
            return new CatThreadView()
            {
                CatThreadId = ct.CatThreadId,
                //Comments = null /* cat.Comments */,
                CreationDate = ct.CreationDate,
                Deleted = ct.Deleted,
                Titre = ct.Titre,
                UriPhoto = ct.UriPhoto,
                UserName = ct.User.Login /* cat.User */
            };
        }
    }
}