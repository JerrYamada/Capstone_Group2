using Capstone_Group2.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
                .Include(t => t.Priority)
                .Include(t => t.Category)
                .Include(t => t.Status)
                .ToList();

            var events = tasks.Select(task => new
            {
                id = task.TaskId,
                title = task.TaskName,
                start = task.Start_Date.HasValue ? task.Start_Date.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                end = task.End_Date.HasValue ? task.End_Date.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                category = task.Category?.CategoryName,
                status = task.Status?.StatusName,
                priorityId = task.Priority?.PriorityId
            });

            return Json(events);
        }

    }
}