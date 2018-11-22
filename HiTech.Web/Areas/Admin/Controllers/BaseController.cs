using System.Web.Mvc;
using System.Web.Routing;
using HiTech.Model;
namespace HiTech.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = Session["Admin"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Index", Area = "Admin" }));
            }
           
            base.OnActionExecuting(filterContext);
        }

    }
}