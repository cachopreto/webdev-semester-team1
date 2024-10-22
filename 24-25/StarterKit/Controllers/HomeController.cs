using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StarterKit.Models;

namespace StarterKit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Updated to ILogger<HomeController>

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{**slug}")]
        public IActionResult Index()
        {
            // Log when the Index action is invoked
            _logger.LogInformation("Received request for Index action.");

            // You could also log the 'slug' if necessary
            var slug = HttpContext.Request.Path.Value; // Get the requested path
            _logger.LogInformation("Requested slug: {Slug}", slug);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Log when an error occurs
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("An error occurred while processing the request. Request ID: {RequestId}", requestId);

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
