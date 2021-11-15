using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM_Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public int SupplierId { get; set; } = 0;

        [BindProperty]
        public int ProductCategoryId { get; set; } = 0;

        public List<SqlTables.Product> Products = new List<SqlTables.Product>();

        public void OnGet([FromServices] SqlDb sql)
        {
            Products = sql.Products.ToList();
        }

        public void OnPostSearch([FromServices] SqlDb sql)
        {
            if (SupplierId == 0 && ProductCategoryId == 0)
                Products = sql.Products.ToList();
            else
            {
                Products = sql.Products.Where(x => (SupplierId == 0 ? true : x.SuplierId == SupplierId) && (ProductCategoryId == 0 ? true : x.ProductCategoryId == ProductCategoryId)).ToList();
            }
        }
    }
}
