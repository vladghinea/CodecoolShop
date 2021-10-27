using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDaoMemory : ICartDao
    {
        private List<Product> data = new List<Product>();
        private static CartDaoMemory instance = null;

        private CartDaoMemory()
        {
        }

        public static CartDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new CartDaoMemory();
            }

            return instance;
        }

        public void Add(Cart item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Cart Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
