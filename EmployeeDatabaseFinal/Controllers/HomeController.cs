using EmployeeDatabaseFinal.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDatabaseFinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DBContextEmployee db = new DBContextEmployee();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewEmployees(string searchSurname, string searchFirstName)
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

            var employees = from e in db.Employee
                            select e;

            if (!string.IsNullOrEmpty(searchSurname))
            {
                employees = employees.Where(x => x.Surname.Contains(searchSurname));
            }

            if (!string.IsNullOrEmpty(searchFirstName))
            {
                employees = employees.Where(x => x.FirstName.Contains(searchFirstName));
            }

            return View(employees);
        }

        [Authorize]
        public ActionResult Details(int? id)
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
            Employee employeeTable = db.Employee.Find(id);


            ViewBag.displayYears = CalculateAge(employeeTable);




            return View(employeeTable);
        }


        public int CalculateAge(Employee employeeTable)
        {
            int YearsPassed = DateTime.Now.Year - employeeTable.StartDate.Year;
            // Are we before the birth date this year? If so subtract one year from the mix
            if (DateTime.Now.Month < employeeTable.StartDate.Month || (DateTime.Now.Month == employeeTable.StartDate.Month && DateTime.Now.Day < employeeTable.StartDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            Employee employee = db.Employee.Find(id);

            //ViewBag.employeePositions = new SelectList(GeneratePositions());


            return View(employee);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {


            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View(employee);
            }
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {



            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index", "Action");



        }

        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index", "Account");

            }
            else
            {
                return View(employee);
            }

        }

        public static List<string> GeneratePositions()
        {
            List<String> position = new List<string>();

            position.Add("Manager");
            position.Add("Employee");

            return position;
        }
    }
}