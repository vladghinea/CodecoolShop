//using Codecool.CodecoolShop.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Codecool.CodecoolShop.Daos.Implementations
//{
//    public class CartDaoMemory : ICartDao
//    {
//        private User john = new User("John", "Doe", "040760368517", "john.doe@gmai.com", "New York", "5'th Avenue", "51B", "Avangard", "A", "25", "99");
//        private static CartDaoMemory instance = null;
//        private Cart cart = new Cart(john.Id);

//        private CartDaoMemory()
//        {
//        }

//        public static CartDaoMemory GetInstance()
//        {
//            if (instance == null)
//            {
//                instance = new CartDaoMemory();
//            }

//            return instance;
//        }

//        public void Add(Product item)
//        {
//            if (cart.Quantity.ContainsKey(item))
//            {
//                cart.Quantity[item] += 1;
//            }
//            else
//            {
//                cart.Quantity[item] = 1;
//            }
            
//        }

//        public void Remove(Product item)
//        {
//            if (cart.Quantity[item] == 1 )
//            {
//                cart.Quantity.Remove(item);
//            }
//            else
//            {
//                cart.Quantity[item] -= 1;
//            }
//        }

//        public Cart Get()
//        {
//            return cart;
//        }
//    }
//}
