﻿using System;
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
        [DataType(DataType.Password)]

        public string Password { get; set; }

   /*     [Required]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }*/


        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}