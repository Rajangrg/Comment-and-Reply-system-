using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentAndReplySystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string email { get; set; }


        public string ImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}