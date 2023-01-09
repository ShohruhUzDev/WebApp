using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.IServices;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _userService.GetAllUsersAsync());
        }
        public IActionResult CreateUser()
        {
            return RedirectToAction();
        }
        public IActionResult Create()
        {
            return View();
        }
        public  IActionResult AllUsers()
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}