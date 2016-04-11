using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstCat;
using CatExercise.Models;
using System.Data.Entity;

namespace CatExercise.Dao
{
    public class CatThreadDAO : ICatThreadDAO
    {
        CatDB db = new CatDB();

        public CatThreadView FindByID(int id)
        {
            CatThread cat = db.CatThreads.Include("User").FirstOrDefault(thread => thread.CatThreadID == id);
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
            if(partialTitle == null) return new List<CatThreadView>();
            ICollection<CatThread> catlist = GetAllOrOnlyActive(actif)
                .Where(thread => thread.Titre != null && thread.Titre.Contains(partialTitle))
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

        public int Insert(CatThreadView catThreadView)
        {
            if (catThreadView == null)
            {
                throw new ArgumentNullException("CatThreadDAO : Insert : Parameter catThreadView can't be null.");
            }

            /// bind user
            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            UserView userView;
            User user = null;
            if(catThreadView.UserID != 0)
            {
                //id specified : find correct user with this information with that
                userView = userDAO.FindByID(catThreadView.UserID);
                if (userView != null)
                {
                    user = userDAO.Find(userView.Login);
                }
            }
            else
            {
                //no id has been specified : check with username
                user = userDAO.Find(catThreadView.UserName);
            }


            /// create thread
            CatThread catThread;
            int random = new Random().Next() + 1;
            if (catThreadView.Titre == null) {
                throw new NullReferenceException("Titre");
            }

            if (user == null)
            {
                throw new NullReferenceException("User");
            }

            catThread = new CatThread() {
                CreationDate = DateTime.Now,
                Titre = catThreadView.Titre,
                UriPhoto = catThreadView.UriPhoto,
                User = user,
                TemporaryInt = random
            };
            
            db.CatThreads.Attach(catThread);
            db.Entry(catThread).State = EntityState.Added; 
            db.SaveChanges();

            // finds back the newly inserted thread and returns ID
            catThread = db.CatThreads.Where(x => x.TemporaryInt == random).FirstOrDefault();
            if (catThread == null)
            {
                throw new Exception("thread a pas pu être clair");
            }
            
            catThread.TemporaryInt = 0;
            db.SaveChanges();
            return catThread.CatThreadID;

        }

        public bool Update(CatThreadView catThreadView)
        {
            if (catThreadView == null)
            {
                throw new ArgumentNullException("CatThreadDAO : trying to Update with a null parameter");
            }

            CatThread catThread = db.CatThreads.FirstOrDefault(ct => ct.CatThreadID == catThreadView.CatThreadId);
            if (catThread == null)
            {
                return false;
            }

            //catThread.CreationDate = catThreadView.CreationDate;
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

            CatThreadView thread = new CatThreadView()
            {
                CatThreadId = ct.CatThreadID,
                CreationDate = ct.CreationDate,
                Deleted = ct.Deleted,
                Titre = ct.Titre,
                UriPhoto = ct.UriPhoto,
                UserName = ct.User == null ? null : ct.User.Login, /* cat.User */
                UserID = ct.User == null ? 0 : ct.User.UserID
                //comments = new List<CommentView>()
            };

            //attach comments
            thread = DAOFactory.getInstanceOfComment().getPostsFromThread(thread);

            return thread;
        }

        private ICollection<CatThread> GetAllOrOnlyActive(bool actif)
        {
            return db.CatThreads.Where(thread => !(actif && thread.Deleted )).ToList();
        }
    }
}