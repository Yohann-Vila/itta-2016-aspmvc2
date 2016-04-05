using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class UserView {
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public String Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les 2 password ne correspondent pas")]
        [Display(Name = "Re password")]
        public String RePassword { get; set; }
        public String Pseudo { get; set; }
        public Boolean Banish { get; set; }
        public int Seclevel { get; set; }
        public DateTime? Creationdate { get; set; }

        public UserView() { }
    }
}