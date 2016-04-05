﻿using System;
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
        public String Pseudo { get; set; }
        public Boolean Banish { get; set; }
        public int Seclevel { get; set; }
        public DateTime? Creationdate { get; set; }

        public UserView() { }
    }
}