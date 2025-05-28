using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFootwear.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [Required(ErrorMessage ="Seller Name Can't Have Empty.")]
        [RegularExpression(@"[a-zA-Z\s]{3,}",ErrorMessage ="Don't Enter Digits,Min 3 char")]
        [StringLength(50)]        
        [Column(TypeName="varchar")]
        public string SellerName { get; set; }
        [Required(ErrorMessage ="Email Can't have Empty")]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        [StringLength(60)]        
        public string Email { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Enter Mobile No.")]
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Mobile Number shoud starts with 6,7,8,9 and 10 digit only.")]
        public string Mobile { get; set; }
        [StringLength(16)]
        [Required(ErrorMessage = "Enter Password")]        
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage ="Passwod Shoud Contain 1 alphabets , 1 char , 1upeercase ,1 lowecase,and on special char with min8 and max16")]
        public string Password{ get; set; }
        [NotMapped]
        [Compare("Password",ErrorMessage ="Password do not match.")]
        public string ConfirmPassword { get; set; }        
        public bool Status { get; set; }
    }
}