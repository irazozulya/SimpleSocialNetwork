using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Chat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int FirstUserId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int SecondUserId { get; set; }

        public ICollection<Message> Messages { get; set; }

        public Chat()
        {
            Messages = new List<Message>();
        }
    }
}
