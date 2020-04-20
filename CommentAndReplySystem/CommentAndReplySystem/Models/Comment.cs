using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommentAndReplySystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string userInput { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime? CreatedOn { get; set; }
        public ICollection<Reply> Replies { get; set; } // comment can have many replies 
    }
}