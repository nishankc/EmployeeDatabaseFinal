using EmployeeDatabaseFinal.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeDatabaseFinal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private DBContextEmployee db = new DBContextEmployee();



        [Authorize]
        public ActionResult Index()
        {
            ViewBag.displayRole = "no";

            if (User.IsInRole("Manager"))
            {
                ViewBag.displayRole = "yes";
            }
            else
            {
                ViewBag.displayRole = "no";
            }

            return View();

        }

        

        //Login
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

        [HttpPost]
        public ActionResult Login(Employee user)
        {

            var usrManager = db.Employee.Where(u => u.Username == user.Username && u.Password == user.Password && u.Position.PositionName == "Manager").FirstOrDefault();

            var usrEmployee = db.Employee.Where(u => u.Username == user.Username && u.Password == user.Password && u.Position.PositionName == "Employee").FirstOrDefault();

            //MyRoleProvider ddb = new MyRoleProvider();
            //string[] test = ddb.GetRolesForUser(user.Username);
            //string[] test2 = Roles.GetRolesForUser(user.Username);

            //ViewBag.testing = test2[0];

            if (usrManager != null)
            {
                Session["EmployeeId"] = usrManager.EmployeeId.ToString();
                Session["Username"] = usrManager.Username.ToString();
                FormsAuthentication.SetAuthCookie(user.Username, false);

                if (usrManager.Password == "password")
                {
                    return RedirectToAction("ChangePassword");
                }

                return RedirectToAction("Index");

            }
            else if (usrEmployee != null)
            {
                Session["EmployeeId"] = usrEmployee.EmployeeId.ToString();
                Session["Username"] = usrEmployee.Username.ToString();
                FormsAuthentication.SetAuthCookie(user.Username, false);

                if (usrEmployee.Password == "password")
                {
                    return RedirectToAction("ChangePassword");
                }

                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Username or Password is Incorrect");

            }
            return View(user);

            //if (IsValid(user.Username, user.Password))
            //{
            //    FormsAuthentication.SetAuthCookie(user.Username, true);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Login details are wrong.");
            //}
            //return View(user);


        }

        
        [Authorize(Roles = "Manager,Employee")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();  // This may not be needed -- but can't hurt
            Session.Abandon();

            // Clear authentication cookie
            HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rFormsCookie);

            // Clear session cookie 
            HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rSessionCookie);

            // Invalidate the Cache on the Client Side
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // Redirect to the Home Page (that should be intercepted and redirected to the Login Page first)
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "Manager,Employee")]
        public ActionResult ChangePasswordCheck()
        {
            return View();
        }

        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public ActionResult ChangePasswordCheck(Employee account)
        {
            var accountChange = db.Employee.Where(u => u.Username == account.Username && u.Password == account.Password).FirstOrDefault();
            //var accountPassword = db.EmployeeTables.Where(u => u.Password == account.Password);

            if (accountChange != null)
            {
                Session["EmployeeId"] = accountChange.EmployeeId.ToString();
                Session["Username"] = accountChange.Username.ToString();

                return RedirectToAction("ChangePassword");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is Incorrect");
            }

            return View(account);
        }

        [Authorize(Roles = "Manager,Employee")]
        public ActionResult ChangePassword()
        {
            //int currentUserID = User.Identity.GetUserId<int>();
            string currentUserName = User.Identity.Name.ToString();



            Employee currentUser = db.Employee.Where(u => u.Username == currentUserName).FirstOrDefault();

            ViewBag.displayUserName = User.Identity.Name.ToString();

            //ViewBag.employeePositions = new SelectList(GeneratePositions());
            currentUser.Password = "";
            currentUser.ConfirmPassword = "";


            return View(currentUser);
        }

        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public ActionResult ChangePassword(Employee currentUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(currentUser);
            }
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = db.Employee.Where(x => x.Username == UserName).FirstOrDefault();

            return Json(user == null);
        }
    }
}