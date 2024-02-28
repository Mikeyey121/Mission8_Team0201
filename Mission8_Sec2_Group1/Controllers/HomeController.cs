using Microsoft.AspNetCore.Mvc;
using TaskModel.Models;
using System.Diagnostics;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using HabitContext.Models;
using CategoryModel.Models;

namespace Mission8_Sec2_Group1.Controllers
{
    public class HomeController : Controller
    {
        private HabitsContext _context;

        public HomeController(HabitsContext context)
        {
            _context = context;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View(new TaskModel.Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();

                return View(task);
            }

            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var tasks = _context.Tasks
                .Include(x => x.Category)
                .OrderBy(x => x.TaskId).ToList();


            return View(tasks);
        }
    }
}
