﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}