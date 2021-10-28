using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao
    {
        void Add(Product item);
        void Remove(Product product);

        Cart Get();

    }
}
