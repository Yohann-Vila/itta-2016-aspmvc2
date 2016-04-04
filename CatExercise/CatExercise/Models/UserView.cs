using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class UserView {
        public int UserID { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Pseudo { get; set; }
        public Boolean Banish { get; set; }
        public int Seclevel { get; set; }
        public DateTime? Creationdate { get; set; }

        public UserView() { }
    }
}