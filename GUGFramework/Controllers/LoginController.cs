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
            UserModel user = business.CheckUser(model);
            if (user != null)
            {
                if (user.IsEnabled == true)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    return Json(new JsonMessage(true, "登录成功！"));
                }
                else
                {
                    return Json(new JsonMessage(false, "账号被禁用，请联系管理员！"));
                }
            }
            else
            {
                return Json(new JsonMessage(false, "用户名或密码错误！"));
            }
           
        }

        public ActionResult SignOut()
        { 
            FormsAuthentication.SignOut();
            return Redirect("/Login/Index");
        }

    }
}