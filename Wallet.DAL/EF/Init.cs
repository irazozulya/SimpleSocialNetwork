using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    class Initialiser : DropCreateDatabaseAlways<Lab3EFContext>
    {
        protected override void Seed(Lab3EFContext db)
        {
            User Ira = new User { Name = "Ira", Login = "ira22", Password = "22", Age = 20 };
            User Dima = new User { Name = "Dima", Login = "dima20", Password = "20", Age = 21 };
            User Alyona = new User { Name = "Alyona", Login = "Alyona12", Password = "12", Age = 18 };
            User Kiril = new User { Name = "Kiril", Login = "Kiril20", Password = "20", Age = 22 };
            User Alina = new User { Name = "Alina", Login = "Alina27", Password = "27", Age = 18 };
            
            ICollection<User> boys = new List<User>();
            boys.Add(Dima);
            boys.Add(Kiril);
            ICollection<User> girls = new List<User>();
            girls.Add(Ira);
            girls.Add(Alyona);
            girls.Add(Alina);
            Group Boys = new Group { Name = "Boys", NumberOfMembers = boys.Count, Users = boys, UserNames = "Dima, Kiril" };
            Group Girls = new Group { Name = "Girls", NumberOfMembers = girls.Count, Users = girls, UserNames = "Ira, Alyona, Alina" };
            ICollection<Group> girlGroup = new List<Group>();
            girlGroup.Add(Girls);
            ICollection<Group> boyGroup = new List<Group>();
            boyGroup.Add(Boys);

            Ira.Groups = girlGroup;
            Alyona.Groups = girlGroup;
            Alina.Groups = girlGroup;
            Dima.Groups = boyGroup;
            Kiril.Groups = boyGroup;

            Message mess1 = new Message { Mess = "Hello", ReceiverId = 1, SenderId = 2};
            Message mess2 = new Message { Mess = "Hi", ReceiverId = 2, SenderId = 1 };
            Message mess3 = new Message { Mess = "Hello world!", ReceiverId = 3, SenderId = 2 };
            Invitation inv1 = new Invitation { GroupId = 1, SenderId = 2, ReceiverId = 4 };
            Invitation inv2 = new Invitation { GroupId = 2, SenderId = 4, ReceiverId = 2 };
            Invitation inv3 = new Invitation { GroupId = 1, SenderId = 2, ReceiverId = 5 };

            db.Users.Add(Ira);
            db.Users.Add(Dima);
            db.Users.Add(Alyona);
            db.Users.Add(Kiril);
            db.Users.Add(Alina);
            db.Groups.Add(Boys);
            db.Groups.Add(Girls);
            db.Messages.Add(mess1);
            db.Messages.Add(mess2);
            db.Messages.Add(mess3);
            db.Invitations.Add(inv1);
            db.Invitations.Add(inv2);
            db.Invitations.Add(inv3);

            db.SaveChanges();
        }
    }
}
