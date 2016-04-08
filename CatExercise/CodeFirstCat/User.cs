using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCat {
    public class User {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Banish { get; set; }
        public int Seclevel { get; set; }
        public DateTime? Creationdate { get; set; }
        public ICollection<CatThread> CatThreads { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public User(string login, string password) {
            this.Login = login;
            this.Password = password;
        }
        public User() {

        }
        public static int ADMINISTRATEUR = 100;
        public static int UTILISATEUR = 0;
    }
}
