using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Group> Groups { get; }
        //IRepository<Chat> Chats { get; }
        IRepository<Message> Messages { get; }
        IRepository<Invitation> Invitations { get; }
        void Save();
    }
}
