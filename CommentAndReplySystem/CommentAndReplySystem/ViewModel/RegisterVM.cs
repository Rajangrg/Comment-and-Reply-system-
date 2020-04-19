using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentAndReplySystem.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }

        [Required]

        public string ConfirmPassword { get; set; }
        [Required]
        public string email { get; set; }
    }
}