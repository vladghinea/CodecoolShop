using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MVVM_Shop.Controllers
{
    public class DeliveryInfoController : Controller
    {
        [Route("/DeliveryInfo/{id}")]
        public IActionResult Index([FromServices] SqlDb sql, int id)
        {
            var info = sql.DeliveryInfos.FirstOrDefault(x => x.Id == id);
            return Json(new
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                City = info.City,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber
            });
        }
    }
}
