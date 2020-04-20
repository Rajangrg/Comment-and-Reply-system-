using CommentAndReplySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace CommentAndReplySystem.Controllers
{
    public class CommentRoomController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CommentRoomController()
        {
            _db = new ApplicationDbContext();
        }

        // GET: CommentRoom
        public ActionResult Index()
        {
            //var commentDetails = _db.Comments.ToList(); //only comment without replies included
            var commentDetails = _db.Comments.Include(x => x.Replies).ToList(); //including reply
            return View(commentDetails);
        }
    }
}