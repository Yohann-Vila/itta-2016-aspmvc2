using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat
{
    public class Comment
    {
        public int CommentID { get; set; } 
        public User User { get; set; }
        public CatThread CatThread;
        public String Login;
        public DateTime? CreationDate;
        public bool Deleted;
        public String Content;

        public Comment()
        {

        }
    }
}
