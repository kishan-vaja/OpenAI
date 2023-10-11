using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI.Models;

namespace OpenAI.Controllers
{
    public class GenAIToolsController : Controller
    {
        private readonly GenAIToolsDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GenAIToolsController(GenAIToolsDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return _context.DbSet != null ?
                        View(await _context.DbSet.ToListAsync()) :
                        Problem("Entity set 'GenAIToolsDbContext.DbSet'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbSet == null)
            {
                return NotFound();
            }

            var genAIToolsModel = await _context.DbSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genAIToolsModel == null)
            {
                return NotFound();
            }

            return View(genAIToolsModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenAIName,Summary,ImageFilename,ImageFile,AnchorLink,Like")] GenAIToolsModel genAIToolsModel)
        {
            if (ModelState.IsValid)
            {
                //Save Image to wwwRoot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(genAIToolsModel.ImageFile.FileName);
                string extension = Path.GetExtension(genAIToolsModel.ImageFile.FileName);
                genAIToolsModel.ImageFilename = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", genAIToolsModel.ImageFilename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await genAIToolsModel.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(genAIToolsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genAIToolsModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbSet == null)
            {
                return NotFound();
            }

            var genAIToolsModel = await _context.DbSet.FindAsync(id);
            if (genAIToolsModel == null)
            {
                return NotFound();
            }
            return View(genAIToolsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenAIName,Summary,ImageFilename,AnchorLink,Like")] GenAIToolsModel genAIToolsModel)
        {
            if (id != genAIToolsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genAIToolsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenAIToolsModelExists(genAIToolsModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genAIToolsModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbSet == null)
            {
                return NotFound();
            }

            var genAIToolsModel = await _context.DbSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genAIToolsModel == null)
            {
                return NotFound();
            }

            return View(genAIToolsModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbSet == null)
            {
                return Problem("Entity set 'GenAIToolsDbContext.DbSet'  is null.");
            }

            var genAIToolsModel = await _context.DbSet.FindAsync(id);

            if (genAIToolsModel != null)
            {
                //delete image from wwwRoot/image
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", genAIToolsModel.ImageFilename);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _context.DbSet.Remove(genAIToolsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenAIToolsModelExists(int id)
        {
            return (_context.DbSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}