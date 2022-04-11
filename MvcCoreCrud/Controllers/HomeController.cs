using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCoreCrud.DB_Context;
using MvcCoreCrud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrud.Controllers
{
    public class HomeController : Controller
    {
        mydataContext db = new mydataContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<EmpModel> modobj = new List<EmpModel>();
            var res = db.Employees.ToList();
            foreach (var item in res)
            {
                modobj.Add(new EmpModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    City=item.City
                });
            }

            return View(modobj);
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(EmpModel modobj)
        {
            Employee tbl = new Employee();
            tbl.Id = modobj.Id;
            tbl.Name = modobj.Name;
            tbl.Email = modobj.Email;
            tbl.City = modobj.City;

            db.Employees.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Delete(int Id)
        {
            var delitem = db.Employees.Where(a => a.Id == Id).First();
            db.Employees.Remove(delitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
