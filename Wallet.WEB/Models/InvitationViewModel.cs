﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    public class InvitationViewModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}