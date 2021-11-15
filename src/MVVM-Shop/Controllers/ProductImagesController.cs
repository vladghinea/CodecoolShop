using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MVVM_Shop.Controllers
{
    public class ProductImagesController : Controller
    {
        [Route("/images/products/{id}.jpg")]
        public IActionResult Index([FromServices] SqlDb sql, int id)
        {
            var product = sql.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                return File(product.Image, "image/jpeg");
            }

            else
                return Redirect("/");
        }
    }
}
