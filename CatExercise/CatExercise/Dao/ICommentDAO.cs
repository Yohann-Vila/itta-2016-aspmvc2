using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatExercise.Dao {
    public interface ICommentDAO {

        ICollection<Comment> getPostsFromThread(int IdThread, Boolean actif);
        Boolean insert(Comment c);
        Boolean update(Comment c);
        Comment findByID(int commentID);
    }
}
