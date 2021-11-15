using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;        
        private readonly IUserDao userDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao, IUserDao userDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;            
            this.userDao = userDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }
        public Supplier GetProductForSupplier(int suplierId)
        {
            return this.supplierDao.Get(suplierId);
        }

        public IEnumerable<Product> GetProductsForSupplier(int suplierId)
        {
            Supplier supplier = this.supplierDao.Get(suplierId);
            return this.productDao.GetBy(supplier);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return this.productDao.GetAll();
        }
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return this.productCategoryDao.GetAll();
        }
        public IEnumerable<User> GetAllUsers()
        {
            return this.userDao.GetAll();
        }
        public IEnumerable<Supplier> GetAllSupliers()
        {
            return this.supplierDao.GetAll();
        }
        public Cart GetCart(User user)
        {
            return user.UserCart;
        }
    }
}
