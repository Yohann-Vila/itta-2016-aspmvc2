using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class CommentView {
        public int? CommentID { get; set; }
       
        public CatThreadView catThread { get; set; } 
        public String UserName { get; set; }
        public int UserID { get; set; }

        public DateTime? CreationDate { get; set; }
        public bool Deleted { get; set; }
        public String Content { get; set; }

        public CommentView()
        {

        }
    }
}