using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.SystemModel;
using Business.SystemBusiness;

namespace GUGFramework.Controllers
{
    public class SystemLogController : Controller
    {
        // GET: SystemLog
        [PageAuthorizeFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLogList(LogFilter filter)
        {
            return View();
        }
    }
}