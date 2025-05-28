using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFootwear.Models
{
    public class RegCust
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Fill the Column")]
        [StringLength(60)]
        [RegularExpression(@"[a-zA-Z\s]{3,}",ErrorMessage ="Don't Fill Digit Min length will be 3 char")]
        public string CName { get; set; }
        [Required(ErrorMessage = "Fill the Column")]
        [StringLength(80)]
        [EmailAddress(ErrorMessage ="Please Enter valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill the Column")]
        [StringLength(16)]
        [RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@#$&*_-])(?=\S+$).{8,16}",ErrorMessage ="Password atleast hava 1 char,1digit,1special char,not space,min8,max16,1small,1capital")]
        public string Password { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Fill the Column")]
        [Compare("Password",ErrorMessage ="Password Not Match")]
        public string ConfirmPassword { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Fill the Column")]
        [RegularExpression(@"[6-9]\d{9}",ErrorMessage ="don't fill char must have 10 digits and starts with 6,7,8,9")]
        public string PrimaryMobile { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Fill the Column")]
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "don't fill char must have 10 digits and starts with 6,7,8,9")]
        public string SecondaryMobile { get; set; }
        [Required(ErrorMessage = "Fill the Column")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string Shipping_Address { get; set; }        
        public bool Status { get; set; }


    }
}