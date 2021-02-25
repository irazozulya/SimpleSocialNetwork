using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Group
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int NumberOfMembers { get; set; }

        public string UserNames { get; set; }

        public ICollection<User> Users { get; set; }

        public Group()
        {
            Users = new List<User>();
        }
    }
}
