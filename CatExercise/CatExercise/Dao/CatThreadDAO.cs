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
            IQueryable<CatThread> catlist = GetAllOrOnlyActive(actif)
                .Where(thread => thread.User.Login == login);
            IList<CatThreadView> ctvlist = catlist.Select( catthread => CreateModelViewFromModel(catthread) ).ToList();
            return ctvlist;
        }

        public ICollection<CatThreadView> FindByTitle(string partialTitle, bool actif)
        {
            IQueryable<CatThread> catlist = GetAllOrOnlyActive(actif)
                .Where(thread => thread.Titre.Contains(partialTitle));
            IList<CatThreadView> ctvlist = catlist.Select(catthread => CreateModelViewFromModel(catthread)).ToList();
            return ctvlist;
        }

        public ICollection<CatThreadView> GetAll(bool actif)
        {
            IQueryable<CatThread> catlist = GetAllOrOnlyActive(actif);
            IList<CatThreadView> ctvlist = catlist.Select(catthread => CreateModelViewFromModel(catthread)).ToList();
            return ctvlist;
        }

        public bool Insert(CatThreadView catThreadView)
        {
            if (catThreadView == null)
            {
                return false;
            }

            var catThread = db.CatThreads.Create();
            catThread.CreationDate = catThreadView.CreationDate;
            catThread.Titre = catThreadView.Titre;
            catThread.UriPhoto = catThreadView.UriPhoto;

            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            catThread.User = userDAO.Find(catThreadView.UserName);
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

        private CatThreadView CreateModelViewFromModel(CatThread ct)
        {
            return new CatThreadView()
            {
                CatThreadId = ct.CatThreadId,
                CreationDate = ct.CreationDate,
                Deleted = ct.Deleted,
                Titre = ct.Titre,
                UriPhoto = ct.UriPhoto,
                UserName = ct.User.Login /* cat.User */
            };
        }

        private IQueryable<CatThread> GetAllOrOnlyActive(bool actif)
        {
            return db.CatThreads.Where(thread => !(thread.Deleted && actif));
        }
    }
}