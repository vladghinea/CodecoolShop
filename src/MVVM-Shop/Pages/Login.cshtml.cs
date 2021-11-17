using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVVM_Shop.SqlTables;

namespace MVVM_Shop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPostLoginUser([FromServices] SqlDb sql)
        {
            User user = sql.Users.FirstOrDefault(x => x.Email == Email);
            if (user != null)
            {
                if (user.Password == Helper.HashPassword(Password))
                {
                }
            }
            return Redirect("/");
        }
    }
}
