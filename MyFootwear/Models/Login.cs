using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFootwear.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Enter UserName .")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]          
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Passwod Shoud Contain 1 alphabets , 1 char , 1upeercase ,1 lowecase,and on special char with min8 and max16")]
        public string Password { get; set; }
    }
}