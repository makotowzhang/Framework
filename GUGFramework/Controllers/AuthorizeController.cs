using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.SystemModel;
using Business.SystemBusiness;

namespace GUGFramework.Controllers
{
    public class AuthorizeController : BaseController
    {
        AuthorizeBusiness business = new AuthorizeBusiness();
        // GET: Authorize
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthorize(Guid roleId)
        {
            return Json(business.GetRoleAuthorize(roleId));
        }

        public ActionResult SetAuthorize(AuthorizeModel model)
        {
            model.CreateUser = CurrentUser.Id;
            return Json(new JsonMessage(business.SetAuthorize(model)));
        }
    }
}