using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }

        public ChatViewModel()
        {
            Messages = new List<MessageViewModel>();
        }
    }
}