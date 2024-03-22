using Capstone_Group2.DataAccess;
using Capstone_Group2.Entities;
using Capstone_Group2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Capstone_Group2.Controllers
{
    public class TaskController : Controller
    {
        private CapstoneDbContext _taskDbContext;

        public TaskController(CapstoneDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }


        //Go to the Home Page
        public IActionResult HomePage()
        {
            var tasks = _taskDbContext.Tasks
                .OrderBy(t => t.End_Date)
                .Take(3)
                .ToList();

            var categories = _taskDbContext.Categories
                .ToList();

            var statuses = _taskDbContext.Statuses
                .ToList();

            var priorities = _taskDbContext.Priorities
                .ToList();

            var tm = new List<TaskViewModel>();

            //add each task to the List of TaskViewModel
            foreach (var task in tasks)
            {
                TaskViewModel temptm = new TaskViewModel();
                temptm.TaskId = task.TaskId;
                temptm.TaskName = task.TaskName;
                temptm.TaskDescription = task.TaskDescription;
                temptm.Start_Date = task.Start_Date;
                temptm.End_Date = task.End_Date;
                //get the category name
                foreach (var category in categories)
                {
                    if (task.CategoryId == category.CategoryId)
                    {
                        temptm.Category = category;
                    }
                }
                //get the status name
                foreach (var status in statuses)
                {
                    if (task.StatusId == status.StatusId)
                    {
                        temptm.Status = status;
                    }
                }

                //get the priority type
                foreach (var priority in priorities)
                {
                    if (task.PriorityId == priority.PriorityId)
                    {
                        temptm.Priority = priority;
                    }
                }

                //add the TaskViewModel to the list
                tm.Add(temptm);

            }

            return View("HomePage", tm);

        }



        // GET ALL TASKS
        [HttpGet("/tasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskDbContext.Tasks
                .OrderByDescending(t => t.Start_Date)
                .ToList();

            var categories = _taskDbContext.Categories
                .ToList();

            var statuses = _taskDbContext.Statuses
                .ToList();

            var priorities = _taskDbContext.Priorities
                .ToList();

            var tm = new List<TaskViewModel>();
            //add each task to the List of TaskViewModel
            foreach (var task in tasks)
            {
                TaskViewModel temptm = new TaskViewModel();
                temptm.TaskId = task.TaskId;
                temptm.TaskName = task.TaskName;
                temptm.TaskDescription = task.TaskDescription;
                temptm.Start_Date = task.Start_Date;
                temptm.End_Date = task.End_Date;
                //get the category name
                foreach (var category in categories)
                {
                    if (task.CategoryId == category.CategoryId)
                    {
                        temptm.Category = category;
                    }
                }
                //get the status name
                foreach (var status in statuses)
                {
                    if (task.StatusId == status.StatusId)
                    {
                        temptm.Status = status;
                    }
                }

                //get the priority type
                foreach (var priority in priorities)
                {
                    if (task.PriorityId == priority.PriorityId)
                    {
                        temptm.Priority = priority;
                    }
                }

                //add the TaskViewModel to the list
                tm.Add(temptm);

            }


            return View("Tasks", tm);
        }

        // GET TASK BY ID

        [HttpGet("/tasks/{id}/task-details")]
        public IActionResult GetTaskById(int Id)
        {
            var task = _taskDbContext.Tasks
                .Where(t => t.TaskId == Id)
                .FirstOrDefault();

            return View("TaskDetails", task); // return need to be changed later
        }

        // GET TASK BY CATEGORY

        [HttpGet("/tasks/{categoryId}")]
        public IActionResult GetTaskByCategory(int categoryId)
        {
            var tasks = _taskDbContext.Tasks
                .Where(t => t.CategoryId == categoryId)
                .ToList();

            var categories = _taskDbContext.Categories
                .ToList();

            var statuses = _taskDbContext.Statuses
                .ToList();

            var priorities = _taskDbContext.Priorities
               .ToList();

            var tm = new List<TaskViewModel>();
            //add each task to the List of TaskViewModel
            foreach (var task in tasks)
            {
                TaskViewModel temptm = new TaskViewModel();
                temptm.TaskId = task.TaskId;
                temptm.TaskName = task.TaskName;
                temptm.TaskDescription = task.TaskDescription;
                temptm.Start_Date = task.Start_Date;
                temptm.End_Date = task.End_Date;
                //get the category name
                foreach (var category in categories)
                {
                    if (task.CategoryId == category.CategoryId)
                    {
                        temptm.Category = category;
                    }
                }
                //get the status name
                foreach (var status in statuses)
                {
                    if (task.StatusId == status.StatusId)
                    {
                        temptm.Status = status;
                    }
                }

                //get the priority type
                foreach (var priority in priorities)
                {
                    if (task.PriorityId == priority.PriorityId)
                    {
                        temptm.Priority = priority;
                    }
                }

                //add the TaskViewModel to the list
                tm.Add(temptm);

            }


            return View("Tasks", tm);
        }

        // CREATE NEW TASK

        [HttpGet("/tasks/add-request")]
        [Authorize]
        public IActionResult GetAddTaskRequest()
        {
            var priorities = _taskDbContext.Priorities.ToList(); // Retrieve priorities from the database
            ViewBag.Priorities = priorities;
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
                    StatusId = taskModel.StatusType,
                    PriorityId = taskModel.PriorityType // Assign Priority Type from model
                };

                _taskDbContext.Tasks.Add(newTask);
                _taskDbContext.SaveChanges();

                return RedirectToAction("GetAllTasks", "Task");
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
            return View("Edit", task);
        }

        [HttpPost("/projects/edit-requests")]
        [Authorize]
        public IActionResult ProcessEditRequest(TimetableTask task)
        {
            if (ModelState.IsValid)
            {
                //This edit method creates a new row.
                //Not yet fixed, need to work on it.
                _taskDbContext.Tasks.Update(task);
                _taskDbContext.SaveChanges();

                return RedirectToAction("GetAllTasks", "Task");
            }
            else
            {
                return View("Edit", task);
            }
        }

        // DELETE TASK BY ID

        [HttpGet("/tasks/{id}/delete-request")]
        [Authorize]
        public IActionResult GetDeleteRequestById(int id)
        {
            var task = _taskDbContext.Tasks.Find(id);
            return View("DeleteConfirmation", task);
        }

        [HttpPost("/tasks/{id}/delete-requests")]
        [Authorize]
        public IActionResult ProcessDeleteRequestById(int id)
        {
            var task = _taskDbContext.Tasks.Find(id);

            _taskDbContext.Tasks.Remove(task);
            _taskDbContext.SaveChanges();

            return RedirectToAction("GetAllTasks", "Task");
        }
    }
}