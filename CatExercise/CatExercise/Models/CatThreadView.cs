using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class CatThreadView {
        public int CatThreadId { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public String Titre { get; set; }
        public String UriPhoto { get; set; }
        public bool Deleted { get; set; }
        public ICollection<CommentView> comments { get; set; }

        public DateTime? CreationDate { get; set; }
        //public ICollection<CommentView> Comments { get; set; }

        public CatThreadView()
        {

        }
    }
}