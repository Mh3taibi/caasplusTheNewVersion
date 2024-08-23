using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace caasplusTheNewVersion.Pages
{
    public class RequestsModel : Controller
    {
        private readonly ILogger<RequestsModel> _logger;

        public RequestsModel(ILogger<RequestsModel> logger)
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
