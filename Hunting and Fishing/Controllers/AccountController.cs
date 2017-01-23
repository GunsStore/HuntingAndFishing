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
        //public ActionResult Index()
        //{
        //    using (StoreProjectDBContext db =new StoreProjectDBContext())
        //    {
        //        return View(db.UserAccount.ToList());
        //    }
        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (StoreProjectDBContext db = new StoreProjectDBContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }

                ModelState.Clear();
                return RedirectToAction("LogIn");
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserAccount user)
        {
            using (StoreProjectDBContext db = new StoreProjectDBContext())
            {
                try
                {
                    var usr = db.UserAccount.Single(u => u.Username == user.Username &&
                                                         u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserId"] = Convert.ToInt32(usr.UserId);
                        Session["Username"] = usr.Username;
                        return RedirectToAction("LoggedInIndex", "Home");

                    }
                    ModelState.Clear();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }


        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        //public ActionResult UserInfo(UserInfo userInfo)
        //{
        //    //For security check this if statement
        //    if (Session["UserId"] != null)
        //    {
        //        var remUserInfo = new List<UserInfo>();
        //        using (StoreProjectDBContext db = new StoreProjectDBContext())
        //        {
        //            var infoUser = db.UserInfo.ToList();
                    
        //            foreach (var index in infoUser)
        //            {
        //                if (Session["UserId"].Equals(index.UserId))
        //                {
        //                    remUserInfo.Add(index);
        //                }
        //            }
        //        }
        //        return View(remUserInfo);
        //    }
        //    return RedirectToAction("LogIn");
        //}

    
        public ActionResult EditUserInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserInfo(UserInfo userInfo)
        {
            if (Session["UserId"] != null)
            {
                var userId = Convert.ToInt32(Session["UserId"]);
                userInfo.UserId = userId;
                if (ModelState.IsValid)
                {
                    using (StoreProjectDBContext db = new StoreProjectDBContext())
                    {
                        db.UserInfo.Add(userInfo);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                }
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
    }



}















