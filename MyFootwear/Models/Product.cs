using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MyFootwear.Models;

namespace MyFootwear.Models
{
    public class Product
    {
        [Key]
        public int ProudctId { get; set; }
        public string ProuductName { get; set; }        
        public int BrandID { get; set; }    //foregin key        
        public int TypeID { get; set; }    //foregin kek
        public int SellerId { get; set; }  //foregin key
        public int Size { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
         public bool Availability { get; set; }

        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        [ForeignKey("TypeID")]
        public Type Type{ get; set; }

        [ForeignKey("BrandID")]
        public Brand Brand { get; set; }

      

       
        


    }
}