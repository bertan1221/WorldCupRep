using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WorldCup.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        
        [HttpGet]
        public ViewResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult LogIn(string username, string password)
        {

            if (username == "admin@mail.com"
                && password == "password")
            {

                FormsAuthentication.SetAuthCookie(username, false);
                return new RedirectResult("~/Home/Index");
            }
            else
            {

                return new RedirectResult("~/Home/LogIn");

            }
        }


        [HttpGet]
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return new RedirectResult("~/Home/Index");
        }
    }
}