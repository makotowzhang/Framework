using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace GUGFramework.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {

            return Json(CurrentUser,JsonRequestBehavior.AllowGet);
        }
    }
}