using Hunting_and_Fishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunting_and_Fishing.Controllers
{
    public class RegisterUserInfoController : Controller
    {
        // GET: RegisterUserInfo
        public ActionResult RegisterUserInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUserInfo(int Id, UserInfoModel model)
        {
            if (ModelState.IsValid && Id != 0)
            {
                StoreDbUserInfoModel db = new StoreDbUserInfoModel();

                model.UserId = Id;

                db.UserInfo.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                model = null;

                return View("~/Views/Account/LoggedIn.cshtml");

            }
            return View();
        }
    }
}