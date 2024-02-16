using Capstone_Group2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Group2.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult GetAllTasks()
        {
            return View("Tasks");
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult CreateTask(TaskCreateModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
