#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;

namespace ImageGlass.Controllers;

public class ReleaseImageController : BaseController
{
    private readonly ImageGlassContext _context;

    public ReleaseImageController(ImageGlassContext context)
    {
        _context = context;
    }

    // GET: ReleaseImage
    public async Task<IActionResult> Index()
    {
        var imageGlassContext = _context.ReleaseImages.Include(r => r.Release);
        return View(await imageGlassContext.ToListAsync());
    }

    // GET: ReleaseImage/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var releaseImageModel = await _context.ReleaseImages
            .Include(r => r.Release)
            .FirstOrDefaultAsync(m => m.ReleaseImageId == id);
        if (releaseImageModel == null)
        {
            return NotFound();
        }

        return View(releaseImageModel);
    }

    // GET: ReleaseImage/Create
    public IActionResult Create()
    {
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId");
        return View();
    }

    // POST: ReleaseImage/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReleaseImageId,Link,ReleaseId,Visible,CreatedDate,UpdatedDate")] ReleaseImageModel releaseImageModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(releaseImageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", releaseImageModel.ReleaseId);
        return View(releaseImageModel);
    }

    // GET: ReleaseImage/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var releaseImageModel = await _context.ReleaseImages.FindAsync(id);
        if (releaseImageModel == null)
        {
            return NotFound();
        }
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", releaseImageModel.ReleaseId);
        return View(releaseImageModel);
    }

    // POST: ReleaseImage/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ReleaseImageId,Link,ReleaseId,Visible,CreatedDate,UpdatedDate")] ReleaseImageModel releaseImageModel)
    {
        if (id != releaseImageModel.ReleaseImageId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(releaseImageModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseImageModelExists(releaseImageModel.ReleaseImageId))
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
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", releaseImageModel.ReleaseId);
        return View(releaseImageModel);
    }

    // GET: ReleaseImage/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var releaseImageModel = await _context.ReleaseImages
            .Include(r => r.Release)
            .FirstOrDefaultAsync(m => m.ReleaseImageId == id);
        if (releaseImageModel == null)
        {
            return NotFound();
        }

        return View(releaseImageModel);
    }

    // POST: ReleaseImage/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var releaseImageModel = await _context.ReleaseImages.FindAsync(id);
        _context.ReleaseImages.Remove(releaseImageModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReleaseImageModelExists(int id)
    {
        return _context.ReleaseImages.Any(e => e.ReleaseImageId == id);
    }
}
