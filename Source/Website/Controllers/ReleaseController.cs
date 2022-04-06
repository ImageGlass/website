#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class ReleaseController : BaseController
{
    private readonly ImageGlassContext _context;

    public ReleaseController(ImageGlassContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Releases listing page
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpGet("releases")]
    public async Task<IActionResult> Index(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.Releases
            .Where(i => i.Visible)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, 10);

        return View(pList);
    }

    /// <summary>
    /// Release details page
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("release/{id}")]
    public async Task<IActionResult> Details(int? id, bool? preview)
    {
        if (id == null)
        {
            return NotFound();
        }

        var isPreview = preview ?? false;
        var model = await _context.Releases.Where(i =>
                i.ReleaseId == id && (isPreview || i.Visible))
            .Include(i => i.ReleaseImages)
            .Include(i => i.Downloads)
            .Select(i => new VReleaseDetails(i, isPreview))
            .FirstOrDefaultAsync();

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }






    // GET: Release/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Release/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReleaseId,Slug,Title,Image,ReleaseType,Version,Requirements,Visible,CreatedDate,UpdatedDate")] ReleaseModel releaseModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(releaseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(releaseModel);
    }

    // GET: Release/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var releaseModel = await _context.Releases.FindAsync(id);
        if (releaseModel == null)
        {
            return NotFound();
        }
        return View(releaseModel);
    }

    // POST: Release/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ReleaseId,Slug,Title,Image,ReleaseType,Version,Requirements,Visible,CreatedDate,UpdatedDate")] ReleaseModel releaseModel)
    {
        if (id != releaseModel.ReleaseId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(releaseModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseModelExists(releaseModel.ReleaseId))
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
        return View(releaseModel);
    }

    // GET: Release/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var releaseModel = await _context.Releases
            .FirstOrDefaultAsync(m => m.ReleaseId == id);
        if (releaseModel == null)
        {
            return NotFound();
        }

        return View(releaseModel);
    }

    // POST: Release/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var releaseModel = await _context.Releases.FindAsync(id);
        _context.Releases.Remove(releaseModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReleaseModelExists(int id)
    {
        return _context.Releases.Any(e => e.ReleaseId == id);
    }
}
