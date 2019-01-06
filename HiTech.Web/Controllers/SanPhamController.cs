using HiTech.Model;
using HiTech.Model.Entites;
using HiTech.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace HiTech.Web.Controllers
{
    public class SanPhamController : Controller
    {
        private HiTechContext db = new HiTechContext();
        // GET: SanPham

        public ActionResult Index(int? cate, string query)
        {
          

            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.Product = db.Products.ToList();
            viewModel.Category = db.Categories.ToList();
            if (cate != null)
            {
                var categories = db.Categories.FirstOrDefault(x => x.CategoryID == cate);
                if (categories != default(Category))
                {

                    viewModel.Product = db.Products.Where(x => x.CategoryID == cate).ToList();

                    ViewBag.Category = cate;
                    ViewBag.CategoryName = categories.CategoryName;
                    return View(viewModel);
                }

            }
            else
            {
                viewModel.Product = db.Products.Where(x => x.Category.CategoryName.Contains(query)
                                                        || x.Name.Contains(query)
                                                        || x.Supplier.CompanyName.Contains(query)).ToList();
                return View(viewModel);
            }

            return View(viewModel);


        }

        public ActionResult SanPham(int? prod)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductID == prod);
            if (product != default(Product))
            {
                return View(product);
            }
            return RedirectToAction("Index", "TrangChu");
        }
        
    }
}