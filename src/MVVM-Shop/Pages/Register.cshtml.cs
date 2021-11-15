using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVVM_Shop.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Street { get; set; }

        [BindProperty]
        public string StreetNumber { get; set; }

        [BindProperty]
        public string Building { get; set; }

        [BindProperty]
        public string BuilldingStaircase { get; set; }

        [BindProperty]
        public string Floor { get; set; }

        [BindProperty]
        public string Appartment { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostCreateUser()
        {
            return Redirect("/");
        }
    }
}
