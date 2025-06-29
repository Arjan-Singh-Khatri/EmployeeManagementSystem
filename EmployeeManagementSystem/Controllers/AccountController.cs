using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserServices _userService;

        public AccountController(UserServices userService)
        {
            _userService = userService;
        }

        public IActionResult Register() => View();
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            user.PasswordHash = HashPassword(user.Password);
            await _userService.RegisterUser(user.Username, user.PasswordHash);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            var dbUser = await _userService.GetUserByUsername(user.Username);
            if (dbUser != null)
            {
                var result = HashPassword(user.Password);

                
                if (dbUser.PasswordHash?.Trim() == result.Trim())
                {
                    return RedirectToAction("Index", "Employee");
                }
                

            }
            ViewBag.Error = "Invalid credentials ";
            return View();
        }


        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
