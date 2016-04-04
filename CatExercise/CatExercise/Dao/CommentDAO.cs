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
            var comments = model.Comments.Where(c => c.CatThread.CatThreadId == IdThread && c.Deleted != actif).ToList();
            ICollection<CommentView> result = comments.Select(
                c => CreateModelViewFromModel(c)
                ).ToList();
            return result;
        }

        public bool insert(CommentView c) {
            model.Comments.Add(CreateOrGetModelFromModelView(c));
            return model.SaveChanges() > 0;
        }

        public bool update(CommentView c) {
            model.Comments.Attach(CreateOrGetModelFromModelView(c));
            var entry = model.Entry(c);
            entry.Property(e => e.CommentID).IsModified = true;
            return model.SaveChanges() > 0;
        }

        public CommentView findByID(int commentID) {
            var result = model.Comments.Where(c => c.CommentID == commentID).FirstOrDefault();
            if (result != null) { 
                return CreateModelViewFromModel(result);
            }
            return null;
        }
        private CommentView CreateModelViewFromModel(Comment comment) {
            return new CommentView() {
                UserName = comment.User.Pseudo,
                CommentID = comment.CommentID,
                CatThreadId = comment.CatThread.CatThreadId,
                Content = comment.Content,
                CreationDate = comment.CreationDate,
                Deleted = comment.Deleted
            };
        }
        private Comment CreateOrGetModelFromModelView(CommentView comment) {
            if (comment.CommentID != null) {
               return model.Comments.Where(c => c.CommentID == comment.CommentID).First();
            } else {
                return new Comment() {
                    User = model.Users.Where(u => u.UserID == comment.UserID).First(),
                    CatThread = model.CatThreads.Where(ct => ct.CatThreadId == comment.CatThreadId).First(),
                    Content = comment.Content,
                    CreationDate = comment.CreationDate,
                    Deleted = comment.Deleted
                };
            }
        }

    }
}