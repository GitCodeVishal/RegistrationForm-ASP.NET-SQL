using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationForm.Models;

namespace RegistrationForm.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddorEdit(int id = 0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using (DBModels db = new DBModels ())
            {
                if (db.Users.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exists.";
                    return View("AddOrEdit", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Saved Successfully.";
                return View("AddorEdit", new User());
            }
        }
    }
}