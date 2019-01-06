using HiTech.Model;
using HiTech.Model.Entites;
using HiTech.Web.Areas.Admin.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HiTech.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private HiTechContext db = new HiTechContext();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Employee).Include(o => o.Shipper).Include(o => o.State);
            return View(orders.ToList());
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            var orderDetail = db.OrderDetails.Where(x => x.OrderID == id);
            var listProduct = new List<Product>();
            
            OrderDetailViewModel viewModel = new OrderDetailViewModel();
            
            viewModel.Order = order;
            viewModel.OrderDetails = orderDetail;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Description");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,EmployeeID,ShipperID,StateID,OrderDate,ShippedDate,ShipAddress,Description,CustomerName,Phone,Email")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", order.EmployeeID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", order.ShipperID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Description", order.StateID);
            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", order.EmployeeID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", order.ShipperID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Description", order.StateID);
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,EmployeeID,ShipperID,StateID,OrderDate,ShippedDate,ShipAddress,Description,CustomerName,Phone,Email")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", order.EmployeeID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", order.ShipperID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Description", order.StateID);
            return View(order);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
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
