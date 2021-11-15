using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public ProductService ProductService { get; set; }
        private readonly ILogger<ProductController> _logger;


        public CartController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance(),                
                UserDaoMemory.GetInstance());
            
                
        }

        public List<Product> GetCart()
        {
            return (List<Product>)ProductService.GetCart();
        }

        public ActionResult Index()
        {
            List<Product> cart = (List<Product>)ProductService.GetCart();
            return View(cart);
        }

        public ActionResult AddToCart(string ProductId)
        {
            int id = Convert.ToInt32(ProductId);
            var products = ProductService.GetAllProducts() ;
            Product product = products.Where(x => x.Id == id).First();
            List<Product> cart = (List<Product>)ProductService.GetCart();
            ProductService.cartDao.Add(product);

            return RedirectToAction("Index", "Product");
        }

        // GET: CartController/Create
        public ActionResult Delete(int Id)
        {
            ProductService.cartDao.Remove(Id);

            return RedirectToAction("Index", "Product");
        }

        
    }
}
