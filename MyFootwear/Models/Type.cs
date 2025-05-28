using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Web;
using System.Web.Routing;

namespace MyFootwear.Models
{
    public class Type
    {
        [Key]
        public int TypeID { get; set; }
        public string TypesName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}