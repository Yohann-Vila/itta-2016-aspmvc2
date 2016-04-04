using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public class CommentDAO : ICommentDAO {
        private CatDB model = new CatDB();
        public ICollection<Comment> getPostsFromThread(int IdThread, bool actif) {
            return model.Comments.Where(c => c.CatThread.CatThreadId == IdThread && c.Deleted == !actif).ToList();
        }

        public bool insert(Comment c) {
            model.Comments.Add(c);
            return model.SaveChanges() > 0;
        }

        public bool update(Comment c) {
            model.Comments.Attach(c);
            var entry = model.Entry(c);
            entry.Property(e => e.CommentID).IsModified = true;
            return model.SaveChanges() > 0;
        }

        public Comment findByID(int commentID) {
            return model.Comments.Where(c => c.CommentID == commentID).FirstOrDefault();

        }
    }
}