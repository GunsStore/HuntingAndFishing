using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hunting_and_Fishing.Models;

namespace Hunting_and_Fishing.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View("~/Views/Account/_Register.cshtml");
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Register(Users model)

        {

            if (ModelState.IsValid)

            {

                using (StoreDbContext db = new StoreDbContext())

                {
                    
                    db.Users.Add(model);
    
                    db.SaveChanges();

                    ModelState.Clear();

                    model = null;

                    ViewBag.Message = "Successfully Registration Done";

                }

            }

            return View("~/Views/Home/Index.cshtml", model);

        }
    }
}