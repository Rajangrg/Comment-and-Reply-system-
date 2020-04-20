using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CommentAndReplySystem.Models;
using CommentAndReplySystem.ViewModel;

namespace CommentAndReplySystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController()
        {
            _db = new ApplicationDbContext();
        }


        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM registerUser)
        {
            //Validation
            bool userNameExists = _db.Users.Any(x => x.UserName == registerUser.UserName);
            bool emailExists = _db.Users.Any(x => x.email == registerUser.email);

            if (userNameExists)
            {
                ViewBag.UsernameMessage = "User name already taken";
                return View();
            }
            else if (emailExists)
            {
                ViewBag.EmailMessage = "Email already taken";
                return View();
            }

            //add a new record to User table 
            User userRegister = new User()
            {
                UserName = registerUser.UserName,
                Password = registerUser.Password,
                email = registerUser.email,
                ImageUrl = "",
                CreatedOn = DateTime.Now 

            };
             _db.Users.Add(userRegister);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "CommentRoom");

        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginVM userLogin)
        {
            //validation 
            bool userExists = _db.Users.Any(u => u.UserName == userLogin.UserName && u.Password == userLogin.Password);
            if (!userExists)
            {
                ViewBag.AlertMessage = "Invalid Username or Password";
                return View();
            }
            Session["UserId"] = _db.Users.SingleOrDefault(x=>x.UserName == userLogin.UserName).Id;
            return RedirectToAction("Index", "CommentRoom");

        }
    }
}