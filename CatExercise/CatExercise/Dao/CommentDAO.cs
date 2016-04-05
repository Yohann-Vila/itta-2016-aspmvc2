using CatExercise.Models;
using CodeFirstCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public class CommentDAO : ICommentDAO {
        private CatDB model = new CatDB();
        public CatThreadView getPostsFromThread(CatThreadView catThread) {

            var comments = model.Comments.Where(c => c.CatThread.CatThreadId == catThread.CatThreadId).ToList();
            ICollection<CommentView> result = comments.Select(
                c => CreateModelViewFromModel(c)
                ).ToList();
            return catThread;
        }

        public bool insert(CommentView c) {
            model.Comments.Add(CreateOrGetModelFromModelView(c));
            return model.SaveChanges() > 0;
        }

        public bool update(CommentView c) {
            var reslut = model.Comments.Where(com => com.CommentID == c.CommentID).FirstOrDefault();
            if (reslut != null) {
                reslut.Content = c.Content;
                reslut.Deleted = c.Deleted;
            }
            return model.SaveChanges() > 0;
        }

        public CommentView findByID(int commentID) {
            var result = model.Comments.Include("User").Include("CatThread").Where(c => c.CommentID == commentID).FirstOrDefault();
            if (result != null) { 
                return CreateModelViewFromModel(result);
            }
            return null;
        }
        private CommentView CreateModelViewFromModel(Comment comment) {
            return new CommentView() {
                UserName = comment.User.Pseudo,
                CommentID = comment.CommentID,
                catThread = CatThreadDAO.CreateModelViewFromModel(comment.CatThread),
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
                    CatThread = model.CatThreads.Where(ct => ct.CatThreadId == comment.catThread.CatThreadId).First(),
                    Content = comment.Content,
                    CreationDate = comment.CreationDate,
                    Deleted = comment.Deleted
                };
            }
        }

    }
}