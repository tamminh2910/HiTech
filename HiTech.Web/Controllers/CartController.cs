using HiTech.Model;
using HiTech.Model.Entites;
using HiTech.Web.Models;
using System;
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
        [HttpPost]
        public ActionResult RemoveProduct(int productID)
        {
            //int productID = int.Parse(id);
            List<ItemCart> cart = (List<ItemCart>)Session["Cart"];
            ItemCart temp = new ItemCart();
            if (cart.Count > 0 && cart != null)
            {
                foreach (var prod in cart)
                {
                    if (prod.Product.ProductID == productID)
                    {
                        temp = prod;
                    }
                }
                cart.Remove(temp);
            }
            return PartialView("_UpdateQuantity");
        }

        [HttpPost]
        public ActionResult Pay(string customerName, string address, string phone, string email, string description)
        {
            //Tao hoa don moi
            List<ItemCart> listCarts = (List<ItemCart>)Session["Cart"];
            Order order = new Order();
            order.CustomerName = customerName;
            order.ShipAddress = address;
            order.Phone = phone;
            order.Email = email;
            order.StateID = 1;
            order.Description = description;
            order.OrderDate = DateTime.Now;

            db.Orders.Add(order);
            //Tao chi tiet hoa don
            foreach (var cart in listCarts)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID = order.OrderID,
                    ProductID = cart.Product.ProductID,
                    Quantity = cart.Quantity,
                    UnitPrice = cart.Product.Price
                    
                    
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }

            //Xoa session["cart"]
            Session.Remove("Cart");
            TempData["ThanhToan"] = "<script>alert('Bạn đã đặt hàng thành công!!!');</script>";
            return RedirectToAction("Index","TrangChu");
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