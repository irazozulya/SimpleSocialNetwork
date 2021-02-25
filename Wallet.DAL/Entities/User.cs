using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public int Age { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Invitation> Invitations { get; set; }

        public User()
        {
            Groups = new List<Group>();
            Invitations = new List<Invitation>();
        }
    }
}
