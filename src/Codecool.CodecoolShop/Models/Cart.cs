using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }        
        public decimal SubTotal { get => Products.Select(p=>p.DefaultPrice).Sum();}
        public decimal Shipping { get; set; }
        public decimal Vat { get => (SubTotal /100) * 19;}
        public decimal Total { get => SubTotal + Shipping + Vat; }
        public override string ToString()
        {
            return new string($"Id: Id Name: Name Description: Description");
        }
    }
}
