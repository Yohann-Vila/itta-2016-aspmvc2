using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat {
    public class CatThread {
        [Key]
        public int CatThreadID { get; set; }
        public User User { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(300)]
        public String Titre { get; set; }
        public String UriPhoto { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int TemporaryInt { get; set; }
        public CatThread() {

        }
    }
}
