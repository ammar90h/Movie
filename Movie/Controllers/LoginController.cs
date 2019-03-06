using Movie.DAL;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DataContext db = new DataContext())
            {
                var userDetails = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                  
                    return View("Index", user);
                }
                else
                {
                    Session["userID"] = userDetails.UserId;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
