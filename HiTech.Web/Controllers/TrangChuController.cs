using HiTech.Model;
using HiTech.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace HiTech.Web.Controllers
{
    public class TrangChuController : Controller
    {
        private HiTechContext db = new HiTechContext();
        // GET: TrangChu
        public ActionResult Index()
        {

            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.Product = db.Products.ToList();
            viewModel.Category = db.Categories.ToList();
            //var viewModel = from p in db.Products
            //             join c in db.Categories
            //             on p.CategoryID equals c.CategoryID
            //             select new ProductCategoryViewModel
            //             {
            //                 Product = p,
            //                 Category = c
            //             };
            return View(viewModel);
        }
    }
}