using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class User
    {        
        public Guid Id { get; } = Guid.NewGuid();
        public Cart UserCart { get; set; } = new Cart();
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int PhoneNumber { get; set; }
        public string email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Building { get; set; }
        public string BuilldingStaircase { get; set; }
        public string Floor { get; set; }
        public string Appartment { get; set; }
        
    }
}
