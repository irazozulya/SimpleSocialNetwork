using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using AutoMapper;

namespace WEB
{
    public class HomeController : Controller
    {
        ISocialNetworkService socialNetworkService;

        public HomeController(ISocialNetworkService serv)
        {
            socialNetworkService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDTOs = socialNetworkService.GetUsers();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>());
            var mapper = config.CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDTOs);
            return View(users);
        }

        public ActionResult Group()
        {
            IEnumerable<GroupDTO> groupDTOs = socialNetworkService.GetGroups();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupViewModel>());
            var mapper = config.CreateMapper();
            var groups = mapper.Map<IEnumerable<GroupDTO>, List<GroupViewModel>>(groupDTOs);
            return View(groups);
        }
        /*
        public ActionResult Chat()
        {
            IEnumerable<ChatDTO> chatDTOs = socialNetworkService.GetChats();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ChatDTO, ChatViewModel>());
            var mapper = config.CreateMapper();
            var chats = mapper.Map<IEnumerable<ChatDTO>, List<ChatViewModel>>(chatDTOs);
            return View(chats);
        }*/

        public ActionResult Message()
        {
            IEnumerable<MessageDTO> messageDTOs = socialNetworkService.GetMessages();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>());
            var mapper = config.CreateMapper();
            var messages = mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messageDTOs);
            return View(messages);
        }

        public ActionResult Invitation()
        {
            IEnumerable<InvitationDTO> invitationDTOs = socialNetworkService.GetInvitations();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InvitationDTO, InvitationViewModel>());
            var mapper = config.CreateMapper();
            var invitations = mapper.Map<IEnumerable<InvitationDTO>, List<InvitationViewModel>>(invitationDTOs);
            return View(invitations);
        }

        public ActionResult Summary()
        {
            IEnumerable<UserDTO> userDTOs = socialNetworkService.GetUsers();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>());
            var mapper = config.CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDTOs);
            return View(users);
        }

        public ActionResult AddGroup()
        {
            var group = new GroupViewModel();
            return View(group);
        }

        [HttpPost]
        public ActionResult AddGroup(GroupViewModel group)
        {
            try
            {
                var groupDTO = new GroupDTO { Name = group.Name };
                socialNetworkService.AddGroup(groupDTO);
                return Redirect("Group");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(group);
        }

        /*public ActionResult AddChat()
        {
            var chat = new ChatViewModel();
            return View(chat);
        }

        [HttpPost]
        public ActionResult AddChat(ChatViewModel chat)
        {
            try
            {
                var chatDTO = new ChatDTO { FirstUserId = chat.FirstUserId, SecondUserId = chat.SecondUserId };
                socialNetworkService.AddChat(chatDTO);
                return Redirect("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(chat);
        }*/

        public ActionResult AddMessage()
        {
            var message = new MessageViewModel();
            return View(message);
        }

        [HttpPost]
        public ActionResult AddMessage(MessageViewModel message)
        {
            try
            {
                var messageDTO = new MessageDTO { Mess = message.Mess, SenderId = message.SenderId, ReceiverId = message.ReceiverId };
                socialNetworkService.AddMessage(messageDTO);
                return Redirect("Message");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(message);
        }

        public ActionResult AddInvitation()
        {
            var invitation = new InvitationViewModel();
            return View(invitation);
        }

        [HttpPost]
        public ActionResult AddInvitation(InvitationViewModel invitation)
        {
            try
            {
                var invitationDTO = new InvitationDTO { GroupId = invitation.GroupId, SenderId = invitation.SenderId, ReceiverId = invitation.ReceiverId };
                socialNetworkService.AddInvitation(invitationDTO);
                return Redirect("Invitation");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(invitation);
        }

        public ActionResult AddUser()
        {
            var user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {
            try
            {
                var userDTO = new UserDTO { Name = user.Name, Login = user.Login, Password = user.Password, Age = user.Age };
                socialNetworkService.AddUser(userDTO);
                return Redirect("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(user);
        }

        public ActionResult ConfirmInvitation()
        {
            var invitation = new InvitationViewModel();
            return View(invitation);
        }

        [HttpPost]
        public ActionResult ConfirmInvitation(InvitationViewModel invitation)
        {
            try
            {
                socialNetworkService.ConfirmInvitation(invitation.Id);
                return Redirect("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(invitation);
        }
        /*
        public ActionResult GetUsersFromGroup()
        {
            var group = new GroupViewModel();
            return View(group);
        }

        [HttpPost]
        public ActionResult GetUsersFromGroup(GroupViewModel group)
        {
            try
            {
                IEnumerable<UserDTO> userDTOs = socialNetworkService.GetUsersFromGroup(group.Id);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>());
                var mapper = config.CreateMapper();
                var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDTOs);
                return View(users);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(group);
        }

        public ActionResult UsersFromGroup(int id)
        {
            IEnumerable<UserDTO> userDTOs = socialNetworkService.GetUsersFromGroup(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>());
            var mapper = config.CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDTOs);
            return View(users);
        }*/

        protected override void Dispose(bool disposing)
        {
            socialNetworkService.Dispose();
            base.Dispose(disposing);
        }
    }
}
