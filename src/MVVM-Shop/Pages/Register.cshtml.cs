using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MVVM_Shop.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [StringLength(30, MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "The password is not the same as previous.")]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostCreateUser([FromServices] SqlDb sql)
        {
            sql.Users.Add(new SqlTables.User() { Email = Email, Password = Helper.HashPassword(Password) });
            sql.SaveChanges();
            return Redirect("/");
        }
    }
}
