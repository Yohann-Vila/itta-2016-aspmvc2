using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstCat;

namespace CatExercise.Dao {
    interface ICatThreadDAO {
        IList<CatThread> GetAll(bool actif);
        IList<CatThread> FindByLogin(String login, bool actif);
        IList<CatThread> FindByTitle(String partialTitle, bool actif);

        bool Update(CatThread catThread);
        bool Insert(CatThread catThread);
        CatThread FindByID(int id);
    }
}
