using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class UserRepository : IRepository<User>
    {
        private Lab3EFContext Db;

        public UserRepository(Lab3EFContext context)
        {
            this.Db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return Db.Users;
        }

        public User Get(int id)
        {
            return Db.Users.Find(id);
        }

        public void Create(User user)
        {
            Db.Users.Add(user);
        }

        public void Update(User user)
        {
            if (user != null)
            {
                Db.Entry(user).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return Db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = Db.Users.Find(id);
            if (user != null)
                Db.Users.Remove(user);
        }
    }
}
