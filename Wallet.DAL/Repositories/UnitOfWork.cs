using System;

namespace DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private Lab3EFContext db;
        private UserRepository userRepository;
        private GroupRepository groupRepository;
        //private ChatRepository chatRepository;
        private InvitationRepository invitationRepository;
        private MessageRepository messageRepository;

        public UnitOfWork()
        {
            db = new Lab3EFContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Group> Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }

        /*public IRepository<Chat> Chats
        {
            get
            {
                if (chatRepository == null)
                    chatRepository = new ChatRepository(db);
                return chatRepository;
            }
        }*/

        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }

        public IRepository<Invitation> Invitations
        {
            get
            {
                if (invitationRepository == null)
                    invitationRepository = new InvitationRepository(db);
                return invitationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}