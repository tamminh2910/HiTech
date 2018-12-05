using HiTech.Model;
using HiTech.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace HiTech.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private HiTechContext db = new HiTechContext();
        public ActionResult Index()
        {
            if (Session["Cart"] != null)
            {
                List<ItemCart> cart = (List<ItemCart>)Session["Cart"];
                if (cart.Count > 0)
                {
                    return View(cart);
                }
                else
                    return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int productID)
        {
            //int id = int.Parse(productID);
            //int soluong = int.Parse(quantity);
            List<ItemCart> cart = (List<ItemCart>)Session["Cart"];
            int soluong = int.Parse(Request.Form["quantity"]);
            foreach (var item in cart)
            {
                if (item.Product.ProductID == productID)
                {
                    if (soluong < 0)
                    {
                        item.Quantity = 0;
                    }
                    else
                    {
                        item.Quantity = soluong;
                    }
                }
            }
            return PartialView("_UpdateQuantity", cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }
    }
}