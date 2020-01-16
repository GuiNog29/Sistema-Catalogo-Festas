using System;
using System.Web.Mvc;

namespace SistemaFesta.Controllers
{
    public class HomeController : Controller
    {
        //###########################################################################################

        // REDIRECIONAMENTO PARA HOME
        public ActionResult Index()
        {
            return View();
        }

        //###########################################################################################
        /*                                   <-- ERROR -->                                         */

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var Result = this.View("Error", new HandleErrorInfo(exception,
        //        filterContext.RouteData.Values["controller"].ToString(),
        //        filterContext.RouteData.Values["action"].ToString()));

        //    filterContext.Result = Result;

        //}

        //###########################################################################################
    }
}