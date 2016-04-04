using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat {
    class Class1 {
        static void Main(string[] args) {
            CatDB cat = new CatDB();
            cat.Users.Add(new User("test", "tesT"));
            cat.SaveChanges();
        }
    }
}
