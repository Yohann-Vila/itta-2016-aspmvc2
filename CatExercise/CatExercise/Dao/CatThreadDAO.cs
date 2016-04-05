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

        public ICollection<CatThreadView> FindByLogin(string login)
        {
            return FindByLogin(login, false);
        }

        public ICollection<CatThreadView> FindByLogin(string login, bool actif)
        {
            ICollection<CatThread> catlist = GetAllOrOnlyActive(actif)
                .Where(thread => thread.User != null && thread.User.Login == login)
                .ToList();
            IList<CatThreadView> ctvlist = catlist.Select( catthread => CreateModelViewFromModel(catthread) ).ToList();
            return ctvlist;
        }

        public ICollection<CatThreadView> FindByTitle(string partialTitle)
        {
            return FindByTitle(partialTitle, false);
        }

        public ICollection<CatThreadView> FindByTitle(string partialTitle, bool actif)
        {
            ICollection<CatThread> catlist = GetAllOrOnlyActive(actif)
                .Where(thread => thread.Titre.Contains(partialTitle))
                .ToList();
            IList<CatThreadView> ctvlist = catlist.Select(catthread => CreateModelViewFromModel(catthread)).ToList();
            return ctvlist;
        }

        public ICollection<CatThreadView> GetAll()
        {
            return GetAll(false);
        }

        public ICollection<CatThreadView> GetAll(bool actif)
        {
            ICollection<CatThread> catlist = GetAllOrOnlyActive(actif);
            IList<CatThreadView> ctvlist = catlist.Select(catthread => CreateModelViewFromModel(catthread)).ToList();
            return ctvlist;
        }

        public bool Insert(CatThreadView catThreadView)
        {
            if (catThreadView == null)
            {
                return false;
            }

            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            User user = userDAO.Find(catThreadView.UserName);

            var catThread = new CatThread()
            {
                CreationDate = catThreadView.CreationDate,
                Titre = catThreadView.Titre,
                UriPhoto = catThreadView.UriPhoto,
                User = user
            };

            var catThreadResult = db.CatThreads.Add(catThread);
            
            return db.SaveChanges() > 0;
        }

        public bool Update(CatThreadView catThreadView)
        {
            if (catThreadView == null)
            {
                throw new ArgumentNullException("CatThreadDAO : trying to Update with a null parameter");
            }

            CatThread catThread = db.CatThreads.FirstOrDefault(ct => ct.CatThreadId == catThreadView.CatThreadId);
            if (catThread == null)
            {
                return false;
            }

            catThread.CreationDate = catThreadView.CreationDate;
            catThread.Titre = catThreadView.Titre;
            catThread.Deleted = catThreadView.Deleted;
            catThread.UriPhoto = catThreadView.UriPhoto;

            return db.SaveChanges() > 0;

        }


        ///////////////////////////////////////////////

        public static CatThreadView CreateModelViewFromModel(CatThread ct)
        { 
            if (ct == null)
            {
                return null;
            }

            return new CatThreadView()
            {
                CatThreadId = ct.CatThreadId,
                CreationDate = ct.CreationDate,
                Deleted = ct.Deleted,
                Titre = ct.Titre,
                UriPhoto = ct.UriPhoto,
                UserName = ct.User == null ? null : ct.User.Login /* cat.User */
            };
        }

        private ICollection<CatThread> GetAllOrOnlyActive(bool actif)
        {
            return db.CatThreads.Where(thread => !(thread.Deleted && actif)).ToList();
        }
    }
}