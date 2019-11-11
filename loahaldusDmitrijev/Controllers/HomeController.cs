using shumilo_asp_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shumilo_asp_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users.Where(x => x.login == "admin").FirstOrDefault();
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }
        public ActionResult LogOut()
        {
            Session["email"] = "";

            return View("index");
        }
    }
}
