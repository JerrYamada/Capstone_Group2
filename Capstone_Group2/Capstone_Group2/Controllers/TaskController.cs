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
        public IActionResult Register(TaskCreateModel model)
        {
            if (ModelState.IsValid)
            {
                // You can implement your registration logic here
                // For simplicity, we'll just redirect to the home page
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
