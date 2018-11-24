using HiTech.Model;
using System.Linq;
using System.Web.Mvc;
namespace HiTech.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private HiTechContext db = new HiTechContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            ViewBag.XinChao = "Chào mừng bạn đến với trang Admin!!";
            return View(category);
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}