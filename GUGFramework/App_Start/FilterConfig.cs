using System.Web;
using System.Web.Mvc;
using Model.SystemModel;
using Model.EnumModel;
using Common;
using System;

namespace GUGFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class LogFilter : ActionFilterAttribute
    {
        public LogFilter(string actionName,string menuName,LogActionType logActionType,string description="")
        {
            Log = new LogModel()
            {
                ActionName= actionName,
                MenuName= menuName,
                ActionType=logActionType.ToString(),
                Description= description
            };
        }
        public LogModel Log{get;set;}


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Log.IpAddress = HttpContextHelp.GetClientIp(HttpContext.Current);
            string user = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (string.IsNullOrWhiteSpace(user))
            {
                Log.DoUser = Guid.Empty;
            }
            else
            {
                Log.DoUser = Guid.Parse(user);
            }
            new Business.SystemBusiness.LogBusiness().AddLog(Log);
        }
    }
}
