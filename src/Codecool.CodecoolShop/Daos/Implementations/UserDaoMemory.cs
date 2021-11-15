using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class UserDaoMemory : IUserDao
    {
        private List<User> users = new List<User>();
        private static UserDaoMemory instance = null;

        private UserDaoMemory()
        {
        }

        public static UserDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new UserDaoMemory();
            }

            return instance;
        }
        public void Add(User item)
        {
            users.Add(item);
        }

        public User Get(Guid id)
        {
            return users.Find(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Remove(Guid id)
        {
            users.Remove(this.Get(id));
        }
    }
}
