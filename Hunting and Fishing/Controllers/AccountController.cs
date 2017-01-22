using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hunting_and_Fishing.Models;
using Microsoft.AspNet.Identity;

namespace Hunting_and_Fishing.Controllers
{
    public class AccountController : Controller
    {
        // REGISTER------------------------------------------------------------------------------------------------

        public ActionResult Register()
        {
            return View("~/Views/Account/_Register.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)

        {
            
                if (ModelState.IsValid)

                {

                    using (StoreDbContext db = new StoreDbContext())

                    {
                        //Password hash
                        var password = model.Password;
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
                        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                        String hash = System.Text.Encoding.ASCII.GetString(data);

                        var confPass = model.ConfirmPassword;
                        byte[] cdata = System.Text.Encoding.ASCII.GetBytes(confPass);
                        cdata = new System.Security.Cryptography.SHA256Managed().ComputeHash(cdata);
                        String chash = System.Text.Encoding.ASCII.GetString(cdata);

                        model.Password = hash;
                        model.ConfirmPassword = chash;


                        db.Users.Add(model);

                        db.SaveChanges();

                        ModelState.Clear();

                        model = null;

                        ViewBag.Message = "Successfully Registration Done";

                    }
                }           
            return View("~/Views/Home/Index.cshtml");
        }

        //LOGIN------------------------------------------------------------------------------------------------

        public ActionResult Login()
        {
            return View("~/Views/Account/_Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogIn model)
        {
            if (ModelState.IsValid)
            {
                using (StoreDbContext db = new StoreDbContext())
                {

                    var password = model.Password;
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
                    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                    String hash = System.Text.Encoding.ASCII.GetString(data);

                    model.Password = hash;
                    try
                    {
                        LogIn user = new Models.LogIn();

                        foreach (var us in db.Users)
                        {
                            if (us.Username == model.Username && us.Password == model.Password)
                            {
                                user.Id = us.Id;
                                user.Username = us.Username;
                                user.Password = us.Password;
                                break;
                            }
                        }
                        if (user != null)
                        {
                            return RedirectToAction("LoggedIn",user); //after login
                        }
                    }
                    catch (Exception)
                    {

                        return View("~/Views/Home/Index.cshtml");
                    }
                }

            }
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult LoggedIn(LogIn model)
        {
            return View("~/Views/Account/LoggedIn.cshtml", model);
        }
        
    }
}