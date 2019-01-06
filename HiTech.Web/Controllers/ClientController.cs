using HiTech.Model;
using HiTech.Model.Entites;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace HiTech.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: Customer
        private HiTechContext db = new HiTechContext();
        public ActionResult Index()
        {
            if (Session["Customer"] != null)
            {
                var client = (Customer)Session["Customer"];
                var customer = db.Customers.Find(client.CustomerID);
                return View(customer);
            }
            return RedirectToAction("Index", "TrangChu");
        }

        public ActionResult Register()
        {
            if (Session["Customer"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "TrangChu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerID,CustomerName,Birthday,Address,Phone,UserName,Password")] Customer customer, string PasswordAgain)
        {
            if (ModelState.IsValid)
            {
                var cus = db.Customers.FirstOrDefault(x => x.UserName == customer.UserName);
                if (cus == default(Customer))
                {
                    if (customer.Password == PasswordAgain)
                    {
                        db.Customers.Add(customer);
                        db.SaveChanges();
                        Session["Customer"] = customer;
                        return RedirectToAction("Index", "TrangChu");
                    }
                    else
                    {
                        ModelState.Remove("password");
                        ModelState.AddModelError("password", "Mật khẩu không khớp");
                        return View(customer);
                    }
                }
                else
                {
                    ModelState.Remove("username");
                    ModelState.AddModelError("username", "Tên đăng nhập đã tồn tại!");
                    return View(customer);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
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

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,Birthday,Address,Phone,UserName,Email,Password")] Customer customer, string PasswordAgain)
        {
            if (Session["Customer"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (customer.Password == PasswordAgain)
                    {
                        db.Entry(customer).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["Customer"] = customer;
                    }
                    else
                    {
                        ModelState.Remove("password");
                        ModelState.AddModelError("password", "Mật khẩu không khớp");
                        return View("Index", customer);
                    }

                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
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
                return View("Index", customer);
            }
            else
            {
                return RedirectToAction("Index", "TrangChu");
            }
        }

     
    }
}