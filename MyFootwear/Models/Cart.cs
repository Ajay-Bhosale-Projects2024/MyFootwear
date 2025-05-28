using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFootwear.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
       public int CustomerId{ get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
    }
}