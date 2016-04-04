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
                UriPhoto = "TEST"
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
