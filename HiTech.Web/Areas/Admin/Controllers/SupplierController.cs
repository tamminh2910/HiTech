using HiTech.Model;
using HiTech.Model.Entites;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace HiTech.Web.Areas.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        private HiTechContext db = new HiTechContext();

        // GET: Admin/Supplier
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var supplier = db.Suppliers.ToList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                supplier = db.Suppliers.Where(x => x.CompanyName.Contains(searchString)
                                              || x.ContactName.Contains(searchString)
                                              || x.Email.Contains(searchString)
                                              || x.Phone.Contains(searchString)
                                              || x.Address.Contains(searchString)
                                              || x.ContacTitle.Contains(searchString)).ToList();
            }
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(supplier.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,CompanyName,ContactName,ContacTitle,Address,Phone,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,CompanyName,ContactName,ContacTitle,Address,Phone,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteAll(FormCollection formCollection)
        {
            string[] ids = formCollection["supplierID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                if (id != "false")
                {
                    var supplier = db.Suppliers.Find(int.Parse(id));
                    var proc = db.Products.FirstOrDefault(x => x.SupplierID == supplier.SupplierID);
                    if (proc != default(Product))
                    {

                    }
                    else
                    {
                        db.Suppliers.Remove(supplier);
                        db.SaveChanges();
                    }

                }
            }
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
