using EmpDBFinal.Context;
using EmpDBFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmpDBFinal.Controllers
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

            var employees = db.Employee.Include(x => x.Address).Include(x => x.Position);

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Position, "PositionID", "PositionName", employee.PositionId);
           

            return View(employee);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {


            if (ModelState.IsValid)
            {
                var original = db.Employee.Find(employee.EmployeeId);

                if (original != null)
                {
                    original.EmployeeId = employee.EmployeeId;
                    original.FirstName = employee.FirstName;
                    original.Surname = employee.Surname;
                    original.DateOfBirth = employee.DateOfBirth;
                    original.StartDate = employee.StartDate;
                    original.Username = employee.Username;
                    original.Password = employee.Password;
                    original.ConfirmPassword = employee.ConfirmPassword;
                    original.PositionId = employee.PositionId;
                    original.Address.AddressId = original.Address.AddressId;
                    original.Address.Address1 = employee.Address.Address1;
                    original.Address.Address2 = employee.Address.Address2;
                    original.Address.Town = employee.Address.Town;
                    original.Address.County = employee.Address.County;
                    original.Address.Postcode = employee.Address.Postcode;
                    original.Address.PhoneNumber = employee.Address.PhoneNumber;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Account");
                }
            }

            
                return View(employee);
            
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

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {



            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index", "Account");



        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Position, "PositionID", "PositionName");
            //var employee = new Employee();
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                

                
                //employee.Username = CreateUserName(employee.FirstName, employee.Surname);
                //employee.Password = "password";
                //employee.ConfirmPassword = "password";
               
                db.Employee.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index", "Account");

            }
            else
            {
                ViewBag.PositionId = new SelectList(db.Position, "PositionID", "PositionName");
                return View(employee);
            }
            
        }

        public string CreateUserName(string firstname, string surname)
        {
            string surnameLastLetter = surname[0].ToString();

            string username = (firstname + surnameLastLetter).ToLower();

            var user = db.Employee.Where(x => x.Username == username).FirstOrDefault();

            
        

            int i = 1;
            char[] surnamechar = surname.ToCharArray();

            while (user.Username == username)
            {
                surnameLastLetter = surnamechar[i].ToString();
                username = (firstname + surnameLastLetter).ToLower();
                i++;
            }

            return username;
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