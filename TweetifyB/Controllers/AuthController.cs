using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tweety_Boss.DAL;
using Tweety_Boss.Models;

namespace Tweety_Boss.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User u)
        {
            using (var context = new TweetifyContext())
            {

                User temp = context.Users.FirstOrDefault(x => x.Username == u.Username);

                if (temp != null)
                {
                    if (temp.Password == u.Password)
                    {
                        HttpContext.Session.SetInt32("UserId", temp.Id);
                        return RedirectToAction("Home", "Index");
                    }
                    else
                    {
                        throw new Exception("Wrong password");
                    }

                }
                else
                {
                    throw new Exception("Wrong user");
                }

            }

        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Login(User u)
        {
            try
            {
                using (var context = new TweetifyContext())
                {
                    var user = context.Users.FirstOrDefault(x => x.Username == u.Username);

                    if (user.Password == (u.Password))
                    {

                        HttpContext.Session.SetString("Logged", "true");
                        HttpContext.Session.SetString("UserName", user.Username);
                        HttpContext.Session.SetInt32("UserID", user.Id);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(u);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }


        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home", "Index");
        }
    }
}