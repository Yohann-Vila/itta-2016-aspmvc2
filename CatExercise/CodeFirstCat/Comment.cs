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
        public CatThread CatThread  { get; set; }
        public String Login  { get; set; }
        public DateTime? CreationDate  { get; set; }
        public bool Deleted  { get; set; }
        public String Content  { get; set; }

        public Comment()
        {

        }
    }
}
