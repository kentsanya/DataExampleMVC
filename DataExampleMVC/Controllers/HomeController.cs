using DataExampleMVC.Data.Repository;
using DataExampleMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataExampleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Course> _repo;

        public HomeController(ILogger<HomeController> logger, IRepository<Course> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
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