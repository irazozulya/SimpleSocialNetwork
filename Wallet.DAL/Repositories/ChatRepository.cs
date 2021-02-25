using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    /*public class ChatRepository : IRepository<Chat>
    {
        private Lab3EFContext Db;

        public ChatRepository(Lab3EFContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Chat> GetAll()
        {
            return Db.Chats;
        }

        public Chat Get(int id)
        {
            return Db.Chats.Find(id);
        }

        public void Create(Chat chat)
        {
            Db.Chats.Add(chat);
        }

        public void Update(Chat chat)
        {
            if (chat != null)
            {
                Db.Entry(chat).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }

        public IEnumerable<Chat> Find(Func<Chat, Boolean> predicate)
        {
            return Db.Chats.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Chat chat = Db.Chats.Find(id);
            if (chat != null)
                Db.Chats.Remove(chat);
        }
    }*/
}