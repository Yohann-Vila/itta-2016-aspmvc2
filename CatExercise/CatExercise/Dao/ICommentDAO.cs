using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatExercise.Dao {
    public interface ICommentDAO {
        public ICollection<Comment> getPostsFromThread(int IdThread, Boolean actif);
        public Boolean insert(Comment c);
        public Boolean update(Comment c);
        public Comment findByID(int commentID);
    }
}
