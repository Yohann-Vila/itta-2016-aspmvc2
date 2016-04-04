using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatExercise.Dao {
    public interface ICommentDAO {

        ICollection<CommentDAO> getPostsFromThread(int IdThread, Boolean actif);
        Boolean insert(CommentDAO c);
        Boolean update(CommentDAO c);
        CommentDAO findByID(int commentID);
    }
}
