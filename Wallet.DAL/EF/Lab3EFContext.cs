using System.Data.Entity;

namespace DAL
{
    public class Lab3EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        //public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        static Lab3EFContext()
        {
            Database.SetInitializer<Lab3EFContext>(new Initialiser());
        }
        public Lab3EFContext() : base("DataBase")
        {
        }
    }
}