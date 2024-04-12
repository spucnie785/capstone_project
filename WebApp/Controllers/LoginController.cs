using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }

        public string Login(LoginModel login)
        {//TODO: make this log into the database
            return "Username:" + login.Username + "\nPassword:" + login.Password;
        }
    }
}
