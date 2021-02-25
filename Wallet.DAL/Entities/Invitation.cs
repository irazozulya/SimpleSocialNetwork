using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Invitation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public bool IsConfirmed { get; set; }

        public Invitation()
        {
            IsConfirmed = false;
        }
    }
}
