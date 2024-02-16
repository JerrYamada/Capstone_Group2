using Microsoft.AspNetCore.Mvc;

namespace Capstone_Group2.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult GetAllTasks()
        {
            return View("Tasks");
        }
    }
}
