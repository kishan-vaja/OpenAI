using Microsoft.AspNetCore.Mvc;

namespace OpenAI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
