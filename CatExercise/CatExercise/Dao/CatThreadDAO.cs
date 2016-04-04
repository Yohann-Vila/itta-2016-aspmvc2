using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstCat;

namespace CatExercise.Dao
{
    public class CatThreadDAO : ICatThreadDAO
    {
        public CatThread FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<CatThread> FindByLogin(string login, bool actif)
        {
            throw new NotImplementedException();
        }

        public ICollection<CatThread> FindByTitle(string partialTitle, bool actif)
        {
            throw new NotImplementedException();
        }

        public ICollection<CatThread> GetAll(bool actif)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CatThread catThread)
        {
            throw new NotImplementedException();
        }

        public bool Update(CatThread catThread)
        {
            throw new NotImplementedException();
        }
    }
}