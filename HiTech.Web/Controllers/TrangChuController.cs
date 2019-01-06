using HiTech.Model;
using HiTech.Model.Entites;
using HiTech.Web.Models;
using System.Collections.Generic;
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

        public ActionResult _PartialMenuClient()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.Product = db.Products.ToList();
            viewModel.Category = db.Categories.ToList();
            return PartialView("_PartialMenuClient", viewModel);
        }

        //public ActionResult _PartialCart(int productID)
        //{

        //    var product = db.Products.FirstOrDefault(x => x.ProductID == productID);
        //    if (product != default(Product))
        //    {
        //        if (Session["Cart"] == null)
        //        {
        //            List<ItemCart> cart = new List<ItemCart>();
        //            cart.Add(new ItemCart() { Product = product, Quantity = 1 });
        //            Session["Cart"] = cart;
        //        }
        //        else
        //        {
        //            List<ItemCart> cart = (List<ItemCart>)Session["Cart"];

        //            int index = isExistProduct(productID);
        //            if (index != -1)
        //            {
        //                cart[index].Quantity++;
        //            }
        //            else
        //            {
        //                cart.Add(new ItemCart() { Product = product, Quantity = 1 });
        //            }
        //        }
        //    }

        //    //Order order = new Order()
        //{
        //    OrderDate = DateTime.Now,
        //    OrderDetails = (from product in db.Products
        //                    where product.ProductID == productID
        //                    select  new OrderDetail()
        //                    {
        //                        ProductID = product.ProductID,
        //                        UnitPrice=product.Price

        //                    })

        //};

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            int productID = int.Parse(id);
            var product = db.Products.FirstOrDefault(x => x.ProductID == productID);
            if (product != default(Product))
            {
                if (Session["Cart"] == null)
                {
                    List<ItemCart> cart = new List<ItemCart>();
                    cart.Add(new ItemCart() { Product = product, Quantity = 1 });
                    Session["Cart"] = cart;
                    return PartialView("_PartialCart", cart);
                }
                else
                {
                    List<ItemCart> cart = (List<ItemCart>)Session["Cart"];

                    int index = isExistProduct(productID);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }
                    else
                    {
                        cart.Add(new ItemCart() { Product = product, Quantity = 1 });
                    }
                    return PartialView("_PartialCart");
                }

            }
            return View("Index");
        }


        public ActionResult RemoveProductCart(int id)
        {

            List<ItemCart> cart = (List<ItemCart>)Session["Cart"];
            ItemCart sp = new ItemCart();

            foreach (var product in cart)
            {
                if (product.Product.ProductID == id)
                {
                    sp = product;

                }
            }
            cart.Remove(sp);
            return RedirectToAction("Index");
        }

        private int isExistProduct(int id)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["Cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.Customers.FirstOrDefault(x => x.UserName == username);
                if (user != default(Customer))
                {
                    var userpass = db.Customers.FirstOrDefault(x => x.UserName == username && x.Password == password);
                    if (userpass != default(Customer))
                    {
                        Session["Customer"] = userpass;
                        return PartialView("_PartialLogin");

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

            return PartialView("_PartialLogin");
        }


        public ActionResult Logout()
        {
            Session.Remove("Customer");
            return PartialView("_PartialLogin");
        }


        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}