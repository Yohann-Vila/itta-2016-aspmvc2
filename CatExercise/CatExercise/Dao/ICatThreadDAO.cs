using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatExercise.Models;

namespace CatExercise.Dao {
    public interface ICatThreadDAO {
        ICollection<CatThreadView> GetAll(bool actif);
        ICollection<CatThreadView> FindByLogin(String login, bool actif);
        ICollection<CatThreadView> FindByTitle(String partialTitle, bool actif);

        bool Update(CatThreadView catThread);
        bool Insert(CatThreadView catThread);
        CatThreadView FindByID(int id);
    }
}
