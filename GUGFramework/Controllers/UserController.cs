using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.SystemModel;
using Business.SystemBusiness;

namespace GUGFramework.Controllers
{
    public class UserController : BaseController
    {
        UserBusiness business = new UserBusiness();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser(Guid userId)
        {
            return Json(business.GetUserModel(userId));
        }

        public ActionResult AddUser(UserModel user)
        {
            try
            {
                user.CreateUser = CurrentUser.Id;
                bool success = business.AddUser(user);
                return Json(new JsonMessage(success));
            }
            catch
            {
                return Json(new JsonMessage(false));
            }
        }

        public ActionResult EditUser(UserModel user)
        {
            try
            {
                user.UpdateUser = CurrentUser.Id;
                bool success= business.EditUser(user);
               return Json(new JsonMessage(success));
            }
            catch
            {
                return Json(new JsonMessage(false));
            }
        }

        public ActionResult GetUserList(UserFilter filter)
        {
            int total = 0;
            var data= business.GetUserList(filter, out total);
            return Json(new TableDataModel(total,data));
        }

        public ActionResult CheckUserName(string userName,Guid? userId, bool IsUpdate)
        {
            UserModel model = new UserModel() { UserName=userName };
            if (userId.HasValue)
            {
                model.Id = userId.Value;
            }
            return Json(new JsonMessage(business.CheckUserNameExsit(model, IsUpdate)));
        }

        public ActionResult DeleteUser(List<UserModel> model)
        {
            Guid updateUser = CurrentUser.Id;
            if (model != null)
            {
                foreach (var m in model)
                {
                    m.UpdateUser = updateUser;
                }
            }
            return Json(new JsonMessage(business.DeleteUser(model)));
        }
    }
}