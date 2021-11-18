using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVVM_Shop.SqlTables;

namespace MVVM_Shop.Pages
{
    public class CheckoutModel : PageModel
    {
        SqlDb _sql;

        public CheckoutModel([FromServices] SqlDb sql)
        {
            _sql = sql;
        }

        public List<DeliveryInfo> DeliveryInfos
        {
            get
            {
                return _sql.DeliveryInfos.Where(x => x.UserId == UserId).ToList();
            }
        }
        public int UserId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Session.GetString("Id"));
            }
        }

        [BindProperty]
        public int SelectedAddress { get; set; }

        [BindProperty]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        public string City { get; set; }

        [BindProperty]
        [Required]
        public string Address { get; set; }

        [BindProperty]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [Required]
        public string NameOnTheCard { get; set; }

        [BindProperty]
        [Required]
        [CreditCard]
        public string CardNumber { get; set; }

        [BindProperty]
        [Required]
        public string ExpirationDate { get; set; }

        [BindProperty]
        [Required]
        public string CVV { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostCheckout([FromServices] SqlDb sql)
        {
            int DeliveryInfoId;
            if (SelectedAddress == 0)
            {
                var newAddress = sql.DeliveryInfos.Add(new DeliveryInfo
                {
                    UserId = UserId,
                    FirstName = FirstName,
                    LastName = LastName,
                    City = City,
                    Address = Address,
                    PhoneNumber = PhoneNumber
                }).Entity;
                sql.SaveChanges();
                DeliveryInfoId = newAddress.Id;
            }
            else
            {
                DeliveryInfoId = SelectedAddress;
            }
            var NewOrder = sql.Orders.Add(new Order() { UserId = UserId, DeliveryInfoId = DeliveryInfoId }).Entity;
            sql.SaveChanges();
            foreach (var cartItem in sql.Carts.Where(x => x.UserId == UserId).ToList())
            {
                sql.OrderItems.Add(new OrderItem()
                {
                    UserId = UserId,
                    OrderId = NewOrder.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    TotalPrice = cartItem.Quantity * cartItem.Product.DefaultPrice
                });
                sql.Carts.Remove(cartItem);
            }
            sql.SaveChanges();
            return Redirect("/Purchase");
        }
    }
}
