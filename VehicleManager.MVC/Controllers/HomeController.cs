using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.MVC.Models;

namespace VehicleManager.MVC.Controllers
{
    public class HomeController(IUserService userService, IHttpContextAccessor httpContextAccessor) : Controller
    {
        private readonly IUserService _userService = userService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public IActionResult Index()
        {
            var user = ObterUsuarioDaSessao();
            return View(user);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult LoginAction(string login, string password)
        {
            User user = userService.GetUser(login, password);

            if (user != null)
            {
                ArmazenarUsuarioNaSessao(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private void ArmazenarUsuarioNaSessao(User user)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var userJson = JsonConvert.SerializeObject(user);
            session.SetString("UserData", userJson);
        }

        private User ObterUsuarioDaSessao()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (session.TryGetValue("UserData", out byte[] userData))
            {
                var userJson = Encoding.UTF8.GetString(userData);
                var user = JsonConvert.DeserializeObject<User>(userJson);
                return user;
            }

            return null;
        }
    }
}