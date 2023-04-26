using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MStud.DAL.Data;
using MStud.Models;
using MStud.Models.ViewModels;
using System.Diagnostics;

namespace MStud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = await _db.admins.FirstOrDefaultAsync(i => i.AdminEmail == obj.Email);
                if (data != null)
                {
                    if (obj.Email == data.AdminEmail && obj.Password == data.AdminPassword)
                    {
                        TempData["success"] = "Login Successfully";
                        return RedirectToAction("Index", "Admin");
                    }
                }

            }
            TempData["error"] = "Something Went Wronge";
            return View();
            //var acp = _db.admins.Where(login => login.AdminEmail == obj.Email && login.AdminPassword == obj.Password).FirstOrDefault();
            //if (acp != null)
            //{
            //    TempData["success"] = "Login successfully:)";
            //    return RedirectToAction("Index","Stud");
            //}
            //else
            //{
            //    TempData["error"] = "Invalid Credentials";
            //    return View();
            //}   
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