using Capstone_Group2.DataAccess;
using Capstone_Group2.Entities;
using Capstone_Group2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Group2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private CapstoneDbContext _taskDbContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, CapstoneDbContext taskDbContext) 
        {
            _userManager= userManager;
            _signInManager= signInManager;
            _taskDbContext = taskDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var user = new User { UserName = registerViewModel.Username };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    // Create a new timetable for the user
                    var timetable = new Timetable
                    {
                        UserId = user.Id,
                        TimetableId = user.Id
                    };

                    _taskDbContext.timetables.Add(timetable);
                    await _taskDbContext.SaveChangesAsync();

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(registerViewModel);
        
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,  isPersistent: model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded) 
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                
            }
            ModelState.AddModelError("", "Username or Password is invalid");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
