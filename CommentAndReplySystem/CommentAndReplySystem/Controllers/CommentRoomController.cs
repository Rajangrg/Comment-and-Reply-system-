using CommentAndReplySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using CommentAndReplySystem.ViewModel;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CommentReply(ReplyVM commentreply)
        {
            int sessionUserId = Convert.ToInt32(Session["UserId"]);

            //validation
            if(sessionUserId == 0)
            {
                return RedirectToAction("Login", "Account"); //if not login
            }

            if (ModelState.IsValid) //validation
            {
                Reply reply = new Reply()
                {
                    userInput = commentreply.Reply,
                    CommentId = commentreply.CommentId, // must be hidden field
                    UserId = sessionUserId,
                    CreatedOn = DateTime.Now
                };
                _db.Replies.Add(reply);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Index"); //optional 
        }


    }
}