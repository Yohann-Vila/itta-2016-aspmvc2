using CatExercise.Models;
using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public class CommentDAO : ICommentDAO {
        private CatDB model = new CatDB();
        public ICollection<CommentView> getPostsFromThread(int IdThread, bool actif) {
            //var dbmodel = model.Comments.Where(c => c.CatThread.CatThreadId == IdThread && c.Deleted == !actif).ToList();
            //dbmodel.Cast<CommentView>().Select(c.)
            throw new NotImplementedException();

            //return model.Comments.Where(c => c.CatThread.CatThreadId == IdThread && c.Deleted == !actif).ToList();
        }

        public bool insert(CommentView c) {
            throw new NotImplementedException();
            //model.Comments.Add(c);
            //return model.SaveChanges() > 0;
        }

        public bool update(CommentView c) {
            throw new NotImplementedException();
            //model.Comments.Attach(c);
            //var entry = model.Entry(c);
            //entry.Property(e => e.CommentID).IsModified = true;
            //return model.SaveChanges() > 0;
        }

        public CommentView findByID(int commentID) {
            throw new NotImplementedException();
            //return model.Comments.Where(c => c.CommentID == commentID).FirstOrDefault();

        }
    }
}