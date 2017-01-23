using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunting_and_Fishing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoggedInIndex()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("LogIn","Account");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}