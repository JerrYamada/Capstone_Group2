using Capstone_Group2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Group2.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // You can implement your registration logic here
                // For simplicity, we'll just redirect to the home page
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // You can implement your login logic here
                // For simplicity, we'll just redirect to the home page
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
