using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public Cart(Guid userId)
        {
            UserId = userId;
            Shipping = 0;
            Quantity = new Dictionary<Product, int>();
        }

        public Guid UserId { get; set; }
        //public List<Product> Products { get; set; }
        public decimal SubTotal { get => Quantity.Keys.Select(p=>p.DefaultPrice).Sum();}
        public decimal Shipping { get; set; }
        public Dictionary<Product,int> Quantity { get; set; }
        public decimal Vat { get => (SubTotal /100) * 19;}
        public decimal Total { get => SubTotal + Shipping + Vat; }
        public override string ToString()
        {
            return new string($"Id: Id Name: Name Description: Description");
        }


        public void Add(Product item)
        {
            if (this.Quantity.ContainsKey(item))
            {
                this.Quantity[item] += 1;
            }
            else
            {
                this.Quantity[item] = 1;
            }

        }

        public void Remove(Product item)
        {
            if (this.Quantity[item] == 1)
            {
                this.Quantity.Remove(item);
            }
            else
            {
                this.Quantity[item] -= 1;
            }
        }
    }
}
