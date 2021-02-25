using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }
        public string UserNames { get; set; }
    }
}