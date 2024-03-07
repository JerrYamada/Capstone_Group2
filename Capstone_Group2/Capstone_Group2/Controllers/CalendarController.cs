using Capstone_Group2.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone_Group2.DataAccess;

namespace Capstone_Group2.Controllers
{
    public class CalendarController : Controller
    {
        private readonly CapstoneDbContext _dbContext;

        public CalendarController(CapstoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Calendar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var tasks = _dbContext.Tasks.ToList(); // Fetch tasks from the database

            // Map tasks to CalendarViewModel
            var events = tasks.Select(task => new CalendarViewModel
            {
                TaskName = task.TaskName,
                StartDate = task.Start_Date ?? DateTime.MinValue,
                DueDate = task.End_Date ?? DateTime.MinValue
            });

            return Json(events);
        }
    }
}