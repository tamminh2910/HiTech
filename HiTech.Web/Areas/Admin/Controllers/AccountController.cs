using HiTech.Model;
using HiTech.Model.Entites;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace HiTech.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private HiTechContext db = new HiTechContext();
        // GET: Admin/Account
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                var account = db.Employees.FirstOrDefault(x => x.UserName == username);
                if (account != default(Employee))
                {
                    var acc = db.Employees.FirstOrDefault(x => x.UserName == username && x.Password == password);
                    if (acc != default(Employee))
                    {
                        
                        Session.Add("Admin", username);
                        
                        return RedirectToAction("Index","Home");
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

            var session = Session["Admin"];
            if (session != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}