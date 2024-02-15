using Capstone_Group2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Group2.Controllers
{
    public class RegistrationLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Save user to database or perform other actions
                // Redirect to a success page, login page, or wherever appropriate
                return RedirectToAction("Index");
            }

            // If registration fails, return to registration page with errors
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Authenticate user, typically check against database
            // If authentication succeeds, set authentication cookie and redirect
            // Otherwise, return to login page with error message

            // For simplicity, no authentication is implemented in this example

            return RedirectToAction("Index");
        }
    }
}
