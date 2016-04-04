using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstCat;

namespace CatExercise.Dao {
    interface ICatThreadDAO {
        public ICollection<CatThread> GetAll(bool actif);
        public ICollection<CatThread> FindByLogin(String login, bool actif);
        public ICollection<CatThread> FindByTitle(String partialTitle, bool actif);

        public bool Update(CatThread catThread);
        public bool Insert(CatThread catThread);
        public CatThread FindByID(int id);
    }
}
