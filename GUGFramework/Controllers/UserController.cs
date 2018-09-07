using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.SystemModel;
using Business.SystemBusiness;

namespace GUGFramework.Controllers
{
    public class UserController : Controller
    {
        UserBusiness business = new UserBusiness();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser(UserModel user)
        {
            return Json(new { });
        }

        public ActionResult EditUser(UserModel user)
        {
            return Json(new { });
        }

        public ActionResult GetUserList(UserFilter filter)
        {
            int total = 0;
            var data= business.GetUserList(filter, out total);
            return Json(new TableDataModel(total,data));
        }
    }
}