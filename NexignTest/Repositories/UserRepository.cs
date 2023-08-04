using NexignTest.Entity;
using NexignTest.Extensions;
using NexignTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexignTest.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public static List<User> UserList { get; set; }

        static UserRepository() => UserList = new List<User>();

        public User Add(User user) 
        {
            var userDb = UserList.FirstOrDefault(x => x.UserName == user.UserName);
            return userDb ?? UserList.AddItem(user);
        }

        public User Update(User t) => throw new NotImplementedException();

        public void Remove(User t) => throw new NotImplementedException();

        public User GetByUserName(string userName) => UserList.Find(x => x.UserName == userName);

        public User Read(Guid id) => UserList.Find(x => x.Id == id);

    }
}
