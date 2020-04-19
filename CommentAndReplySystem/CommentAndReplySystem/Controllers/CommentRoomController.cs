using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentAndReplySystem.Controllers
{
    public class CommentRoomController : Controller
    {
        // GET: CommentRoom
        public ActionResult Index()
        {
            return View();
        }
    }
}