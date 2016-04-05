using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat
{
    public class CatThread
    {
        public int CatThreadID { get; set; }
        public User User { get; set; }
        public String Titre { get; set; }
        public String UriPhoto { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public CatThread()
        {

        }
    }
}
