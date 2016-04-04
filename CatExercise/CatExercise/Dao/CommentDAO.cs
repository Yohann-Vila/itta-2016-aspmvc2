using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public class CommentDAO : ICommentDAO {
        private CatDB cat = new CatDB();
        public ICollection<CommentDAO> getPostsFromThread(int IdThread, bool actif) {
            throw new NotImplementedException();
        }

        public bool insert(CommentDAO c) {
            throw new NotImplementedException();
        }

        public bool update(CommentDAO c) {
            throw new NotImplementedException();
        }

        public CommentDAO findByID(int commentID) {
            throw new NotImplementedException();
        }
    }
}