using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class CatThreadView {
        public int CatThreadId { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Titre")]
        [MaxLength(300)]
        [System.Web.Mvc.Remote("isExist","CatThread", ErrorMessage = "Le titre existe déjà")]
        public String Titre { get; set; }
        public String UriPhoto { get; set; }
        public bool Deleted { get; set; }
        public ICollection<CommentView> comments { get; set; }
        [Required]
        [Display(Name = "Photo de chat")]
        public HttpPostedFileBase File { get; set; }
        public DateTime? CreationDate { get; set; }
        //public ICollection<CommentView> Comments { get; set; }

        public CatThreadView()
        {

        }
    }
}