using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.SystemBusiness;
using Model.SystemModel;


namespace GUGFramework.Controllers
{
    public class MenuController : BaseController
    {
        MenuBusiness business = new MenuBusiness();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllMenu()
        {
            return Json(business.GetAllMenu());
        }

        public ActionResult AddMenu(MenuModel model)
        {
            model.CreateUser = CurrentUser.Id;
            Guid menuId = Guid.Empty;
            return Json(new JsonMessage(business.AddMenu(model,out menuId),menuId.ToString()));
        }

        public ActionResult EditMenu(MenuModel model)
        {
            model.UpdateUser = CurrentUser.Id;
            return Json(new JsonMessage(business.EditMenu(model)));
        }

        public ActionResult GetMenu(Guid menuId)
        {
            return Json(business.GetMenuById(menuId));
        }

    }
}