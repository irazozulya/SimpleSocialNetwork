using System;
using DAL;
using System.Collections.Generic;
using AutoMapper;

namespace BLL
{
    public class SocialNetworkService : ISocialNetworkService
    {
        IUnitOfWork Database { get; set; }

        public SocialNetworkService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddUser(UserDTO userDTO)
        {
            if(userDTO.Name != null && userDTO.Login != null && userDTO.Password != null)
            {
                var user = new User { Name = userDTO.Name, Login = userDTO.Login, Password = userDTO.Password, Age = userDTO.Age };
                Database.Users.Create(user);
                Database.Save();
            }
        }

        public void AddGroup(GroupDTO groupDTO)
        {
            var group = new Group { Name = groupDTO.Name, NumberOfMembers = 0};
            Database.Groups.Create(group);
            Database.Save();
        }

        /*public void AddChat(ChatDTO chatDTO)
        {
            User user = Database.Users.Get(chatDTO.FirstUserId);

            if (user == null)
            {
                user = Database.Users.Get(chatDTO.SecondUserId);
                if (user == null)
                    throw new ValidationException("User is not found", "");
            }

            Chat chat = new Chat { FirstUserId = chatDTO.FirstUserId, SecondUserId = chatDTO.SecondUserId};
            Database.Chats.Create(chat);
            user.Chats.Add(chat);
            Database.Users.Update(user);
            Database.Save();
        }*/

        public void AddMessage(MessageDTO messageDTO)
        {
            //Chat chat = Database.Chats.Get(messageDTO.ChatId);
            User user1 = Database.Users.Get(messageDTO.ReceiverId);
            User user2 = Database.Users.Get(messageDTO.SenderId);

            if (user1 == null || user2 == null)
                throw new ValidationException("User is not found", "");

            Message mess = new Message { Mess = messageDTO.Mess, SenderId = messageDTO.SenderId, ReceiverId = messageDTO.ReceiverId};
            Database.Messages.Create(mess);
            Database.Save();
        }

        public void AddInvitation(InvitationDTO invitationDTO)
        {
            Group group = Database.Groups.Get(invitationDTO.GroupId);
            User sender = Database.Users.Get(invitationDTO.SenderId);
            User receiver = Database.Users.Get(invitationDTO.ReceiverId);
            if (sender == null || receiver == null)
                throw new ValidationException("User is not found", "");

            if (group == null)
                throw new ValidationException("Group is not found", "");

            Invitation inv = new Invitation { GroupId = invitationDTO.GroupId, SenderId = invitationDTO.SenderId, ReceiverId = invitationDTO.ReceiverId, IsConfirmed = false};
            Database.Invitations.Create(inv);
            receiver.Invitations.Add(inv);
            Database.Users.Update(receiver);
            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap <User, UserDTO> ());
            var mapper = config.CreateMapper();
            var assignments = mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
            return assignments;
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap <Group, GroupDTO> ());
            var mapper = config.CreateMapper();
            var assignments = mapper.Map<IEnumerable<Group>, List<GroupDTO>>(Database.Groups.GetAll());
            return assignments;
        }

        /*public IEnumerable<ChatDTO> GetChats()
        {
            IEnumerable<Message> messages = Database.Messages.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap <Chat, ChatDTO> ());
            var mapper = config.CreateMapper();
            var assignments = mapper.Map<IEnumerable<Chat>, List<ChatDTO>>(Database.Chats.GetAll());
            return assignments;
        }*/

        public IEnumerable<MessageDTO> GetMessages()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap <Message, MessageDTO> ());
            var mapper = config.CreateMapper();
            var assignments = mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages.GetAll());
            return assignments;
        }

        public IEnumerable<InvitationDTO> GetInvitations()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap <Invitation, InvitationDTO> ());
            var mapper = config.CreateMapper();
            var assignments = mapper.Map<IEnumerable<Invitation>, List<InvitationDTO>>(Database.Invitations.GetAll());
            return assignments;
        }

        public GroupDTO GetGroup(int? id)
        {
            if (id == null)
                throw new ValidationException("Enter id!", "");
            var group = Database.Groups.Get(id.Value);
            if (group == null)
                throw new ValidationException("Group is not found", "");

            return new GroupDTO {  };
        }

        /*public ChatDTO GetChat(int? id)
        {
            if (id == null)
                throw new ValidationException("Enter id!", "");
            var chat = Database.Chats.Get(id.Value);
            if (chat == null)
                throw new ValidationException("Chat is not found", "");

            return new ChatDTO { };
        }*/

        public MessageDTO GetMessage(int? id)
        {
            if (id == null)
                throw new ValidationException("Enter id!", "");
            var message = Database.Messages.Get(id.Value);
            if (message == null)
                throw new ValidationException("Message is not found", "");

            return new MessageDTO { };
        }

        public InvitationDTO GetInvitation(int? id)
        {
            if (id == null)
                throw new ValidationException("Enter id!", "");
            var invitation = Database.Invitations.Get(id.Value);
            if (invitation == null)
                throw new ValidationException("Invitation is not found", "");

            return new InvitationDTO { };
        }

        public void ConfirmInvitation(int id)
        {
            Invitation invitation = Database.Invitations.Get(id);
            if (invitation == null)
                throw new ValidationException("Invitation is not found", "");
            if (invitation.IsConfirmed == true)
                throw new ValidationException("the invitation is already accepted", "");
            Group group = Database.Groups.Get(invitation.GroupId);
            if (group == null)
                throw new ValidationException("Group is not found", "");
            User sender = Database.Users.Get(invitation.SenderId);
            User receiver = Database.Users.Get(invitation.ReceiverId);
            if (sender == null || receiver == null)
                throw new ValidationException("User is not found", "");
            foreach (User us in group.Users)
            {
                if(us.Id == receiver.Id)
                {
                    throw new ValidationException("This user is already in this group", "");
                }
            }
            
            invitation.IsConfirmed = true;
            group.Users.Add(receiver);
            group.NumberOfMembers++;
            Database.Groups.Update(group);
            Database.Invitations.Update(invitation);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
