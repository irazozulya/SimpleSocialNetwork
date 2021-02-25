using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISocialNetworkService
    {
        void AddUser(UserDTO userDTO);
        void AddGroup(GroupDTO groupDTO);
        //void AddChat(ChatDTO chatDTO);
        void AddMessage(MessageDTO messageDTO);
        void AddInvitation(InvitationDTO invitationDTO);
        IEnumerable<UserDTO> GetUsers();
        IEnumerable<GroupDTO> GetGroups();
        //IEnumerable<ChatDTO> GetChats();
        IEnumerable<MessageDTO> GetMessages();
        IEnumerable<InvitationDTO> GetInvitations();
        GroupDTO GetGroup(int? id);
        //ChatDTO GetChat(int? id);
        MessageDTO GetMessage(int? id);
        InvitationDTO GetInvitation(int? id);
        void ConfirmInvitation(int id);
        void Dispose();
    }
}
