using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OpenAI.Models;

namespace OpenAI.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly GenAIToolsDbContext _context;
        public RegistrationController(GenAIToolsDbContext context)
        {
            _context = context;
        }

        // GET: RegistrationController
        public async Task<ActionResult> Index()
        {
            return _context.RegitrationSet != null ?
                        View(await _context.RegitrationSet.ToListAsync()) :
                        Problem("Entity set 'GenAIToolsDbContext.RegitrationSet'  is null.");
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,IsAdmin,Email,Mobile")] RegitrationModel regitrationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regitrationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regitrationModel);
        }
    }
}
