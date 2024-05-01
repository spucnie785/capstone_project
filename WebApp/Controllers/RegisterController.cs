using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string name, string username, string password)
        {
	        var voter = new VoterModel(username, password, name, "None", false);
            return View(voter);
        }
    }
}
