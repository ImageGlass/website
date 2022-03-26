#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;

namespace ImageGlass.Controllers;

public class ThemeController : Controller
{
    private readonly ImageGlassContext _context;

    public ThemeController(ImageGlassContext context)
    {
        _context = context;
    }

    // GET: Theme
    public async Task<IActionResult> Index()
    {
        return View(await _context.Themes.ToListAsync());
    }

    // GET: Theme/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeModel = await _context.Themes
            .FirstOrDefaultAsync(m => m.ThemeId == id);
        if (themeModel == null)
        {
            return NotFound();
        }

        return View(themeModel);
    }

    // GET: Theme/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Theme/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ThemeId,Slug,Title,Image,Description,Link,Version,Compatibility,Author,Email,Website,Count,Visible,CreatedDate,UpdatedDate")] ThemeModel themeModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(themeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(themeModel);
    }

    // GET: Theme/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeModel = await _context.Themes.FindAsync(id);
        if (themeModel == null)
        {
            return NotFound();
        }
        return View(themeModel);
    }

    // POST: Theme/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ThemeId,Slug,Title,Image,Description,Link,Version,Compatibility,Author,Email,Website,Count,Visible,CreatedDate,UpdatedDate")] ThemeModel themeModel)
    {
        if (id != themeModel.ThemeId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(themeModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeModelExists(themeModel.ThemeId))
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
        return View(themeModel);
    }

    // GET: Theme/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var themeModel = await _context.Themes
            .FirstOrDefaultAsync(m => m.ThemeId == id);
        if (themeModel == null)
        {
            return NotFound();
        }

        return View(themeModel);
    }

    // POST: Theme/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var themeModel = await _context.Themes.FindAsync(id);
        _context.Themes.Remove(themeModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ThemeModelExists(int id)
    {
        return _context.Themes.Any(e => e.ThemeId == id);
    }
}
