using Microsoft.AspNetCore.Mvc;

namespace MVVM_Shop.Controllers
{
    public class LogoutController : Controller
    {
        [Route("/Logout")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
