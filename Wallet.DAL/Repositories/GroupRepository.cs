using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class GroupRepository : IRepository<Group>
    {
        private Lab3EFContext Db;

        public GroupRepository(Lab3EFContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return Db.Groups;
        }

        public Group Get(int id)
        {
            return Db.Groups.Find(id);
        }

        public void Create(Group group)
        {
            Db.Groups.Add(group);
        }

        public void Update(Group group)
        {
            if (group != null)
            {
                foreach (User user in group.Users)
                {
                    group.UserNames += String.Concat(", ", user.Name);
                }
                //group.UserNames = temp;
                Db.Entry(group).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }

        public IEnumerable<Group> Find(Func<Group, Boolean> predicate)
        {
            return Db.Groups.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Group group = Db.Groups.Find(id);
            if (group != null)
                Db.Groups.Remove(group);
        }
    }
}