using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dependency_injection_demo.Models;
using Microsoft.Extensions.Configuration;
using dependency_injection_demo.Middleware.Config;
using Microsoft.Extensions.Options;

namespace dependency_injection_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly ApplicationSettings _applicationSettings;


        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration, IOptions<ApplicationSettings> applicationSettings)
        {
            _logger = logger;
            _config = Configuration;
            _applicationSettings = applicationSettings.Value;
        }

        public IActionResult Index()
        {
            var model = new HomepageViewModel();
            model.applicationSettings = _applicationSettings;
            model.config = _config;
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InjectServiceInView()
        {
            return View("InjectServiceInView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
