using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace caasplusTheNewVersion.Pages
{
    public class SignupProviderModel : Controller
    {
        private readonly ILogger<SignupProviderModel> _logger;

        public SignupProviderModel(ILogger<SignupProviderModel> logger)
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
