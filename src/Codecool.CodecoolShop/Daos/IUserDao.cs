using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Daos
{
    public interface IUserDao 
    {

        void Add(User item);
        void Remove(Guid id);

        User Get(Guid id);
        IEnumerable<User> GetAll();
    }
}
