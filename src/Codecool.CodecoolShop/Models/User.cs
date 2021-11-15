using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class User
    {
        public User( string firstName, string lastName, string phoneNumber, string email, string city, string street, string streetNumber, string building, string builldingStaircase, string floor, string appartment)
        {
            Id = Guid.NewGuid();
            UserCart = new Cart (Id);
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            this.email = email;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Building = building;
            BuilldingStaircase = builldingStaircase;
            Floor = floor;
            Appartment = appartment;
        }

        public Guid Id { get; }
        public Cart UserCart { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string PhoneNumber { get; set; }
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
