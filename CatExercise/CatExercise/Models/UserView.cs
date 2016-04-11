using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatExercise.Models {
    public class UserView {
        public int UserID { get; set; }
        [Required]
        [MaxLength(300)]
        [Display(Name = "Nom d'utilisateur")]
        [System.Web.Mvc.Remote("isExist", "Account", ErrorMessage = "Le nom d'utilisateur existe déjà")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les 2 password ne correspondent pas")]
        [Display(Name = "Re password")]
        public string RePassword { get; set; }
        public bool Banish { get; set; }
        public int Seclevel { get; set; }
        public DateTime? Creationdate { get; set; }

        public UserView() { }
    }
}