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


    [HttpGet("kobe")]
    public async Task<IActionResult> KobeReleases(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.Releases
            .Where(i => i.Visible && i.ReleaseType == ReleaseType.Kobe)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, 10);

        // page info
        ViewData[PageInfo.Title] = "ImageGlass Kobe releases";
        ViewData[PageInfo.Keywords] = "imageglass kobe, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = "https://github.com/ImageGlass/config/raw/main/screenshots/v9.0-beta-2/9.0b2_1.jpg";

        return View("ReleaseListing", pList);
    }


    [HttpGet("moon")]
    public async Task<IActionResult> MoonReleases(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.Releases
            .Where(i => i.Visible && i.ReleaseType == ReleaseType.Moon)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, 10);

        // page info
        ViewData[PageInfo.Title] = "ImageGlass Moon releases";
        ViewData[PageInfo.Description] = "ImageGlass Moon is the bleeding-edge (or beta) release of ImageGlass Kobe, is built and shipped to users with the latest state and features of ImageGlass.";
        ViewData[PageInfo.Keywords] = "imageglass moon, imageglass beta, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = "https://github.com/ImageGlass/config/raw/main/screenshots/v9.0-beta-2/9.0b2_1.jpg";

        return View("ReleaseListing", pList);
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
