using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MVVM_Shop.Controllers
{
    public class AddCartItemController : Controller
    {
        [Route("/Cart/Add/{ProductId}")]
        public IActionResult Index([FromServices] SqlDb sql, int ProductId)
        {
            int userId = String.IsNullOrEmpty(HttpContext.Session.GetString("Id")) ? 0 : Convert.ToInt32(HttpContext.Session.GetString("Id"));
            var existingProduct = sql.Carts.FirstOrDefault(x => x.ProductId == ProductId && x.UserId == userId);
            if (userId != 0)
            {
                if (existingProduct != null)
                {
                    existingProduct.Quantity += 1;
                }
                else
                {
                    sql.Carts.Add(new SqlTables.Cart() { UserId = userId, ProductId = ProductId, Quantity = 1 });
                }
                sql.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [Route("/Cart/GetCartItems")]
        public int GetCart([FromServices] SqlDb sql)
        {
            int userId = String.IsNullOrEmpty(HttpContext.Session.GetString("Id")) ? 0 : Convert.ToInt32(HttpContext.Session.GetString("Id"));
            int products = 0;
            if (userId != 0)
            {
                products = sql.Carts.Where(x => x.UserId == userId).Sum(x => x.Quantity);
            }
            return products;
        }
    }
}
