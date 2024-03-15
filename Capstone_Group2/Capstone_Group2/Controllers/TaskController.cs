using Capstone_Group2.DataAccess;
using Capstone_Group2.Entities;
using Capstone_Group2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Group2.Controllers
{
    public class TaskController : Controller
    {
        private CapstoneDbContext _taskDbContext;

        public TaskController(CapstoneDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }

        // GET ALL TASKS

        [HttpGet("/tasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskDbContext.Tasks
                .OrderByDescending(t => t.Start_Date)
                .ToList();
            

            return View("Tasks", tasks);
        }

        // GET TASK BY ID

        [HttpGet("/tasks/get-task")]
        public IActionResult GetTaskById(int Id)
        {
            var task = _taskDbContext.Tasks
                .Include(t => t.TaskName)
                .Include(t => t.TaskDescription)
                .Include(t => t.TaskId)
                .Include(t => t.Start_Date)
                .Include(t => t.End_Date)
                .Include(t => t.StatusId)
                .Include(t => t.CategoryId)
                .Where(t => t.TaskId == Id)
                .FirstOrDefault();

            return View("Tasks", task); // return need to be changed later
        }

        // GET TASK BY CATEGORY

        [HttpGet("/tasks/category")]
        public IActionResult GetTaskByCategory(int categoryId)
        {
            var task = _taskDbContext.Tasks
                .Include(t => t.TaskName)
                .Include(t => t.TaskDescription)
                .Include(t => t.TaskId)
                .Include(t => t.Start_Date)
                .Include(t => t.End_Date)
                .Include(t => t.StatusId)
                .Include(t => t.CategoryId)
                .Where(t => t.CategoryId == categoryId);

            return View("Index", task); 
        }

        // CREATE NEW TASK

        [HttpGet("/tasks/add-request")]
        [Authorize]
        public IActionResult GetAddTaskRequest()
        {
            return View("Create", new TaskCreateModel());
        }
       

        [HttpPost("/tasks/add-requests")]
        [Authorize]
        public IActionResult CreateTask(TaskCreateModel taskModel)
        {
            if (ModelState.IsValid)
            {
                var newTask = new TimetableTask()
                {
                    TaskName = taskModel.TaskName,
                    CategoryId = taskModel.TaskType,
                    TaskDescription = taskModel.TaskDescription,
                    Start_Date = taskModel.StartDate,
                    End_Date = taskModel.DueDate,
                };

                _taskDbContext.Tasks.Add(newTask);
                _taskDbContext.SaveChanges();


                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View("Create", taskModel);

            }
        }


        // EDIT TASK BY ID

        [HttpGet("/tasks/{id}/edit-request")]
        [Authorize]
        public IActionResult GetEditRequestById(int id)
        {
            var task = _taskDbContext.Tasks.Find(id);
            return View("EditTask", task);
        }

        [HttpPost("/projects/edit-requests")]
        [Authorize]
        public IActionResult ProcessEditRequest(TimetableTask task)
        {
            if (ModelState.IsValid)
            {
                _taskDbContext.Tasks.Update(task);
                _taskDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("EditTask", task);
            }
        }

        // DELETE TASK BY ID

        [HttpGet("/tasks/{id}/delete-request")]
        [Authorize]
        public IActionResult GetDeleteRequestById(int id)
        {
            var task = _taskDbContext.Tasks.Find(id);
            return View("DeleteTask", task);
        }

        [HttpPost("/tasks/{id}/delete-requests")]
        [Authorize]
        public IActionResult ProcessDeleteRequestById(int id)
        {
            var task = _taskDbContext.Tasks.Find(id);

            _taskDbContext.Tasks.Remove(task);
            _taskDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
