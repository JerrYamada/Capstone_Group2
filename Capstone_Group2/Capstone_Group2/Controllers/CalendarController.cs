using Capstone_Group2.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone_Group2.DataAccess;
using Microsoft.EntityFrameworkCore;

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
            var tasks = _dbContext.Tasks
                .Include(t => t.PriorityId) // Include Priority navigation property
                .ToList(); // Fetch tasks from the database

            // Map tasks to FullCalendar event objects
            var events = tasks.Select(task => new
            {
                title = task.TaskName,
                start = task.Start_Date,
                end = task.End_Date,
                color = GetPriorityColor(task.PriorityId) // Get color based on priority ID
            });

            return Json(events);
        }

        // Helper method to get color based on priority ID
        private string GetPriorityColor(int priorityId)
        {
            switch (priorityId)
            {
                case 1:
                    return "#87CEEB"; // Light blue for priority ID 1
                case 2:
                    return "#FFFF00"; // Yellow for priority ID 2
                case 3:
                    return "#FF0000"; // Red for priority ID 3
                default:
                    return ""; // Default color
            }
        }
    }
}