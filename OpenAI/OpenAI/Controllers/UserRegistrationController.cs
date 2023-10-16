using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI.Models;

namespace OpenAI.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly GenAIToolsDbContext _context;
        public UserRegistrationController(GenAIToolsDbContext context)
        {
            _context = context;
        }

        // GET: UserRegistrationController
        public async Task<ActionResult> Index()
        {
            return _context.UserRegitrationSet != null ?
                        View(await _context.UserRegitrationSet.ToListAsync()) :
                        Problem("Entity set 'GenAIToolsDbContext.UserRegitrationSet'  is null.");
        }

        // GET: UserRegistrationController/Create
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: UserRegistrationController/Create
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([Bind("Username,Password")] UserRegistrationModel userRegitrationModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "HomeController");
            }
            return View(userRegitrationModel);
        }

        // GET: UserRegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,IsAdmin")] UserRegistrationModel userRegitrationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRegitrationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userRegitrationModel);
        }
    }
}
