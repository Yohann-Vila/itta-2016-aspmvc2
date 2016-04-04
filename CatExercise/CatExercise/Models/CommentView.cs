using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class CommentView {
        public int CommentID { get; set; } 
        public UserView User { get; set; }
        public CatThreadView CatThread;
        public String Login;
        public DateTime? CreationDate;
        public bool Deleted;
        public String Content;

        public CommentView()
        {

        }
    }
}