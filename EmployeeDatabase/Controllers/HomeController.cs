using EmployeeDatabase.Context;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeDatabase.Controllers
{
    public class HomeController : Controller
    {
        DBContextEmployee db = new DBContextEmployee();
        // GET: Home
        public ActionResult Index()
        {
            var studentList = db.Employee.Include(o => o.Address).Include(o => o.Position);
            return View(studentList.ToList());
        }
    }
}