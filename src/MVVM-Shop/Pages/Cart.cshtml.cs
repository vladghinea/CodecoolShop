using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVVM_Shop.SqlTables;

namespace MVVM_Shop.Pages
{
    public class CartModel : PageModel
    {
        //public List<Cart> CartItems { get; set; }
        SqlDb _sql;
        public CartModel([FromServices] SqlDb sql)
        {
            _sql = sql;
        }
        public List<Cart> CartItems
        {
            get
            {
                return _sql.Carts.Where(x => x.UserId == GetUserId()).ToList();
            }
        }
        public void OnGet([FromServices] SqlDb sql)
        {
        }

        public void OnGetIncreaseQuantity([FromServices] SqlDb sql, int ProductId)
        {
            sql.Carts.FirstOrDefault(x => x.UserId == GetUserId() && x.ProductId == ProductId).Quantity += 1;
            sql.SaveChanges();
        }

        public void OnGetDecreaseQuantity([FromServices] SqlDb sql, int ProductId)
        {
            var product = sql.Carts.FirstOrDefault(x => x.UserId == GetUserId() && x.ProductId == ProductId);
            if (product.Quantity == 1)
            {
                sql.Carts.Remove(product);
            }
            else
            {
                product.Quantity -= 1;
            }
            sql.SaveChanges();
        }

        private int GetUserId() => Convert.ToInt32(HttpContext.Session.GetString("Id"));
    }
}
