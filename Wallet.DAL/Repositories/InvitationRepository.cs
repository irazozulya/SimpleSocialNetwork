using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class InvitationRepository : IRepository<Invitation>
    {
        private Lab3EFContext Db;

        public InvitationRepository(Lab3EFContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Invitation> GetAll()
        {
            return Db.Invitations;
        }

        public Invitation Get(int id)
        {
            return Db.Invitations.Find(id);
        }

        public void Create(Invitation invitation)
        {
            Db.Invitations.Add(invitation);
        }

        public void Update(Invitation invitation)
        {
            if (invitation != null)
            {
                Db.Entry(invitation).State = EntityState.Modified; ;
            }
            Db.SaveChanges();
        }

        public IEnumerable<Invitation> Find(Func<Invitation, Boolean> predicate)
        {
            return Db.Invitations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Invitation invitation = Db.Invitations.Find(id);
            if (invitation != null)
                Db.Invitations.Remove(invitation);
        }
    }
}