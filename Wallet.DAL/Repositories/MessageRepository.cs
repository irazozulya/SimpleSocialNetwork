using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class MessageRepository : IRepository<Message>
    {
        private Lab3EFContext Db;

        public MessageRepository(Lab3EFContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return Db.Messages;
        }

        public Message Get(int id)
        {
            return Db.Messages.Find(id);
        }

        public void Create(Message message)
        {
            Db.Messages.Add(message);
        }

        public void Update(Message message)
        {
            if (message != null)
            {
                Db.Entry(message).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }

        public IEnumerable<Message> Find(Func<Message, Boolean> predicate)
        {
            return Db.Messages.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Message message = Db.Messages.Find(id);
            if (message != null)
                Db.Messages.Remove(message);
        }
    }
}