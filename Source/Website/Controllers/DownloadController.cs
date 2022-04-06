#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;

namespace ImageGlass.Controllers;

public class DownloadController : BaseController
{
    private readonly ImageGlassContext _context;

    public DownloadController(ImageGlassContext context)
    {
        _context = context;
    }

    // GET: Download
    public async Task<IActionResult> Index()
    {
        var imageGlassContext = _context.Downloads.Include(d => d.Release);
        return View(await imageGlassContext.ToListAsync());
    }

    // GET: Download/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var downloadModel = await _context.Downloads
            .Include(d => d.Release)
            .FirstOrDefaultAsync(m => m.DownloadId == id);
        if (downloadModel == null)
        {
            return NotFound();
        }

        return View(downloadModel);
    }

    // GET: Download/Create
    public IActionResult Create()
    {
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId");
        return View();
    }

    // POST: Download/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DownloadId,ReleaseCode,Type,Architecture,FileType,Link,Checksum,Size,Count,ReleaseId,Visible,CreatedDate,UpdatedDate")] DownloadModel downloadModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(downloadModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", downloadModel.ReleaseId);
        return View(downloadModel);
    }

    // GET: Download/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var downloadModel = await _context.Downloads.FindAsync(id);
        if (downloadModel == null)
        {
            return NotFound();
        }
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", downloadModel.ReleaseId);
        return View(downloadModel);
    }

    // POST: Download/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("DownloadId,ReleaseCode,Type,Architecture,FileType,Link,Checksum,Size,Count,ReleaseId,Visible,CreatedDate,UpdatedDate")] DownloadModel downloadModel)
    {
        if (id != downloadModel.DownloadId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(downloadModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DownloadModelExists(downloadModel.DownloadId))
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
        ViewData["ReleaseId"] = new SelectList(_context.Releases, "ReleaseId", "ReleaseId", downloadModel.ReleaseId);
        return View(downloadModel);
    }

    // GET: Download/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var downloadModel = await _context.Downloads
            .Include(d => d.Release)
            .FirstOrDefaultAsync(m => m.DownloadId == id);
        if (downloadModel == null)
        {
            return NotFound();
        }

        return View(downloadModel);
    }

    // POST: Download/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var downloadModel = await _context.Downloads.FindAsync(id);
        _context.Downloads.Remove(downloadModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DownloadModelExists(int id)
    {
        return _context.Downloads.Any(e => e.DownloadId == id);
    }
}
