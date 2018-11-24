using HiTech.Model;
using HiTech.Model.Entites;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
namespace HiTech.Web.Areas.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        private HiTechContext db = new HiTechContext();

        // GET: Admin/Employee
        

        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var employees = db.Employees.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = db.Employees.Where(x => x.EmployeeName.Contains(searchString)
                                                 || x.Address.Contains(searchString)
                                                 || x.Email.Contains(searchString)
                                                 || x.Phone.Contains(searchString)
                                                 || x.UserName.Contains(searchString)).ToList();
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(employees.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            ViewBag.RoleName = new SelectList(db.Roles, "RoleName", "Description");
            return View();
        }

        // POST: Admin/Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Birthday,Address,Phone,Email,Image,UserName,Password,RoleName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleName = new SelectList(db.Roles, "RoleName", "Description", employee.RoleName);
            return View(employee);
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleName = new SelectList(db.Roles, "RoleName", "Description", employee.RoleName);
            return View(employee);
        }

        // POST: Admin/Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,Birthday,Address,Phone,Email,Image,UserName,Password,RoleName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleName = new SelectList(db.Roles, "RoleName", "Description", employee.RoleName);
            return View(employee);
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
