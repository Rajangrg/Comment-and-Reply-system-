using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommentAndReplySystem.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string userInput { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; } //foreign key 
        public virtual Comment Comment { get; set; }

        public DateTime? CreatedOn { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}