using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat {
    class Init {
        public static void Main(string[] args) {
            CatDB cat = new CatDB();
            User u = new User("test", "tesT");
            cat.Users.Add(u);
            CatThread ct = new CatThread(){
                Titre="Test",
                User = u,
                CreationDate = DateTime.Now,
                Deleted = false,
                UriPhoto = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTBXkaWZEoI79WfgrigJV4IeHCFTqKnZA4yzJhnrks5SX7h-k48qw"
            };
            cat.CatThreads.Add(ct);
            cat.Comments.Add(new Comment() {
                CatThread = ct,
                User = u,
                Content = "TEST",
                Deleted = false,
                CreationDate = DateTime.Now
            });
            cat.SaveChanges();
        }
    }
}
