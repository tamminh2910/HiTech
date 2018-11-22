using HiTech.Model;
using HiTech.Model.Entites;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
namespace HiTech.Web.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        private HiTechContext db = new HiTechContext();

        // GET: Admin/Customer
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var customer = db.Customers.ToList();
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
                customer = db.Customers.Where(x => x.CustomerName.Contains(searchString)
                                                || x.Address.Contains(searchString)
                                                || x.Email.Contains(searchString)
                                                || x.Phone.Contains(searchString)
                                                || x.UserName.Contains(searchString)).ToList();
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(customer.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,Birthday,Address,Phone,Email,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState birthday = null;
                if (ModelState.TryGetValue("birthday", out birthday))
                {
                    if (birthday != null && birthday.Errors.Count > 0)
                    {
                        ModelState.Remove("birthday");
                        ModelState.AddModelError("birthday", "Ngày sinh không hợp lệ");
                    }
                }
            }

            return View(customer);
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,Birthday,Address,Phone,Email,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState birthday = null;
                if (ModelState.TryGetValue("birthday", out birthday))
                {
                    if (birthday != null && birthday.Errors.Count > 0)
                    {
                        ModelState.Remove("birthday");
                        ModelState.AddModelError("birthday", "Ngày sinh không hợp lệ");
                    }
                }
            }
            return View(customer);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteAll(FormCollection formCollection)
        {
            string[] ids = formCollection["CustomerID"].Split(new char[] { ',' });
            foreach (var id in ids)
            {
                if (id != "false")
                {
                    var customer = db.Customers.Find(int.Parse(id));
                    db.Customers.Remove(customer);
                    db.SaveChanges();
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
