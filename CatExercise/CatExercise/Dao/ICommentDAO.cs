using CatExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatExercise.Dao {
    public interface ICommentDAO {

        ICollection<CommentView> getPostsFromThread(int IdThread, Boolean actif);
        Boolean insert(CommentView c);
        Boolean update(CommentView c);
        CommentView findByID(int commentID);
    }
}
