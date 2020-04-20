using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentAndReplySystem.ViewModel
{
    public class ReplyVM
    {
        public string Reply { get; set; }  //always the name must be same to the view field
        public int CommentId { get; set; } //always the name must be same to the view field
    }
}