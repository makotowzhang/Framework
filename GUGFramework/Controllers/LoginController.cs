using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.SystemBusiness;
using Model.SystemModel;

namespace GUGFramework.Controllers
{
    public class LoginController : Controller
    {
        LoginBusiness business = new LoginBusiness();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(LoginModel model)
        {
            Guid? userId = business.CheckUser(model);
            if (userId!=null)
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                return Json(new JsonMessage(true, ""));
            }
            else
            {
                return Json(new JsonMessage(false, ""));
            }
           
        }

        public ActionResult SignOut()
        { 
            FormsAuthentication.SignOut();
            return Redirect("/Login/Index");
        }

    }
}