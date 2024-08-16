using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.netAJAXMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string pname { get; set; }
        public string pcat { get; set; }
        public double price { get; set; }
    }
}