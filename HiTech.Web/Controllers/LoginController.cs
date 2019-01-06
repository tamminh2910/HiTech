using HiTech.Model;
using HiTech.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HiTech.Web.Controllers
{
    public class LoginController : Controller
    {
        private HiTechContext db = new HiTechContext();
        // GET: Login
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["Customer"] != null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var clientUsername = db.Customers.FirstOrDefault(x => x.UserName == username);
                if (clientUsername != default(Customer))
                {
                    var client = db.Customers.FirstOrDefault(x => x.UserName == username && x.Password == password);
                    if (client != default(Customer))
                    {
                        Session["Customer"] = client;
                        return RedirectToAction("Index", "TrangChu");

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Mật khẩu không đúng!");
                    }
                }
                else
                {
                    ModelState.AddModelError("NotExistUsername", "Tên đăng nhập không tồn tại!");
                }
            }   
            return View("Index");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = Session["Customer"];
            if (session != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "TrangChu", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}