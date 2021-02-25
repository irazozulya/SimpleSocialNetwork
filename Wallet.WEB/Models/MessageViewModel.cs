using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Mess { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime DateSent { get; set; }
    }
}