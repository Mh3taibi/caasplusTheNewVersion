using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace caasplusTheNewVersion.Pages
{
    public class clientDashboardModel : Controller
    {
        private readonly ILogger<clientDashboardModel> _logger;

        public clientDashboardModel(ILogger<clientDashboardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ToggleView(string view)
        {
            // Logic to handle view toggle
            ViewBag.CurrentView = view;
            return View("Index");
        }
    }
}
