using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }

        public ChatDTO()
        {
            Messages = new List<MessageDTO>();
        }
    }
}
