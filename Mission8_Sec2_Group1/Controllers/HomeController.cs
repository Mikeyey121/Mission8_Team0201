using Microsoft.AspNetCore.Mvc;
using TaskModel.Models;
using System.Diagnostics;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using HabitContext.Models;

namespace Mission8_Sec2_Group1.Controllers
{
    public class HomeController : Controller
    {
        private HabitsContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Tasks = _context.Tasks
                .OrderBy(x => x.TaskId).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddTask(AddTask task)
        {
            if (ModelState.IsValid)
            {
                _context.AddTask.Add(task);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Categories = _context.Tasks
                    .OrderBy(x => x.TaskId).ToList();

                return View(task);
            }

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Quadrants() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quadrants()
        {
            var tasks = _context.Tasks
                .Include(x => x.Category)
                .OrderBy(x => x.TaskId).ToList();


            return View(tasks);
        }
    }
}
