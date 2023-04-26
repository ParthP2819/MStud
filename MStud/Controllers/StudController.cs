using Microsoft.AspNetCore.Mvc;
using MStud.DAL.Data;

namespace MStud.Controllers
{
    public class StudController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
