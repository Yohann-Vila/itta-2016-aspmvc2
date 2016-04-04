using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstCat;

namespace CatExercise.Dao {
    public interface ICatThreadDAO {
        ICollection<CatThread> GetAll(bool actif);
        ICollection<CatThread> FindByLogin(String login, bool actif);
        ICollection<CatThread> FindByTitle(String partialTitle, bool actif);

        bool Update(CatThread catThread);
        bool Insert(CatThread catThread);
        CatThread FindByID(int id);
    }
}
