#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;

namespace ImageGlass.Controllers;

public class ThemeImageController : Controller
{
    private readonly ImageGlassContext _context;

    public ThemeImageController(ImageGlassContext context)
    {
        _context = context;
    }

    // GET: ThemeImage
    public async Task<IActionResult> Index()
    {
        var imageGlassContext = _context.ThemeImages.Include(t => t.Theme);
        return View(await imageGlassContext.ToListAsync());
    }

    // GET: ThemeImage/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeImageModel = await _context.ThemeImages
            .Include(t => t.Theme)
            .FirstOrDefaultAsync(m => m.ThemeImageId == id);
        if (themeImageModel == null)
        {
            return NotFound();
        }

        return View(themeImageModel);
    }

    // GET: ThemeImage/Create
    public IActionResult Create()
    {
        ViewData["ThemeId"] = new SelectList(_context.Themes, "ThemeId", "ThemeId");
        return View();
    }

    // POST: ThemeImage/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ThemeImageId,Link,ThemeId,Visible,CreatedDate,UpdatedDate")] ThemeImageModel themeImageModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(themeImageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ThemeId"] = new SelectList(_context.Themes, "ThemeId", "ThemeId", themeImageModel.ThemeId);
        return View(themeImageModel);
    }

    // GET: ThemeImage/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeImageModel = await _context.ThemeImages.FindAsync(id);
        if (themeImageModel == null)
        {
            return NotFound();
        }
        ViewData["ThemeId"] = new SelectList(_context.Themes, "ThemeId", "ThemeId", themeImageModel.ThemeId);
        return View(themeImageModel);
    }

    // POST: ThemeImage/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ThemeImageId,Link,ThemeId,Visible,CreatedDate,UpdatedDate")] ThemeImageModel themeImageModel)
    {
        if (id != themeImageModel.ThemeImageId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(themeImageModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeImageModelExists(themeImageModel.ThemeImageId))
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
        ViewData["ThemeId"] = new SelectList(_context.Themes, "ThemeId", "ThemeId", themeImageModel.ThemeId);
        return View(themeImageModel);
    }

    // GET: ThemeImage/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeImageModel = await _context.ThemeImages
            .Include(t => t.Theme)
            .FirstOrDefaultAsync(m => m.ThemeImageId == id);
        if (themeImageModel == null)
        {
            return NotFound();
        }

        return View(themeImageModel);
    }

    // POST: ThemeImage/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var themeImageModel = await _context.ThemeImages.FindAsync(id);
        _context.ThemeImages.Remove(themeImageModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ThemeImageModelExists(int id)
    {
        return _context.ThemeImages.Any(e => e.ThemeImageId == id);
    }
}
