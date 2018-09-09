using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.SystemBusiness;
using Model.SystemModel;

namespace GUGFramework.Controllers
{
    public class RoleController : BaseController
    {
        private RoleBusiness business = new RoleBusiness();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllRole()
        {
            return Json(business.GetAllRole(new RoleFilter()));
        }
    }
}