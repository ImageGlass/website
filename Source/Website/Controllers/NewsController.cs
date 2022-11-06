#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class NewsController : BaseController
{
    private readonly ImageGlassContext _context;

    public NewsController(ImageGlassContext context)
    {
        _context = context;
    }


    /// <summary>
    /// News listing page.
    /// </summary>
    [HttpGet("news")]
    public async Task<IActionResult> Index(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.News
            .Where(i => i.Visible)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VNews(i))
            .AsNoTracking();

        var pList = await PaginatedList<VNews>
            .CreateAsync(source, pageNumber, 10);

        return View(pList);
    }


    /// <summary>
    /// The News details page.
    /// To display the hidden post, use <c>?preview=true</c>.
    /// </summary>
    [HttpGet("news/{id}")]
    public async Task<IActionResult> Details(int? id, bool? preview)
    {
        if (id == null)
        {
            return NotFound();
        }

        var isPreview = preview ?? false;
        var model = await _context.News.Where(i => i.NewsId == id && (isPreview || i.Visible))
            .Select(i => new VNewsDetails(i))
            .FirstOrDefaultAsync();

        if (model == null)
        {
            return NotFound();
        }


        var markdownContent = await GitHub.GetFileContentAsync($"news/{model.NewsId + 99}.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

        model.Content = htmlContent;

        return View(model);
    }





    // GET: News/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: News/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Slug,Title,Image,Description,CustomContentUrl,NewsId,Visible,CreatedDate,UpdatedDate")] NewsModel newsModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(newsModel);
    }

    // GET: News/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var newsModel = await _context.News.FindAsync(id);
        if (newsModel == null)
        {
            return NotFound();
        }
        return View(newsModel);
    }

    // POST: News/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Slug,Title,Image,Description,CustomContentUrl,NewsId,Visible,CreatedDate,UpdatedDate")] NewsModel newsModel)
    {
        if (id != newsModel.NewsId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(newsModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsModelExists(newsModel.NewsId))
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
        return View(newsModel);
    }

    // GET: News/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var newsModel = await _context.News
            .FirstOrDefaultAsync(m => m.NewsId == id);
        if (newsModel == null)
        {
            return NotFound();
        }

        return View(newsModel);
    }

    // POST: News/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var newsModel = await _context.News.FindAsync(id);
        _context.News.Remove(newsModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NewsModelExists(int id)
    {
        return _context.News.Any(e => e.NewsId == id);
    }
}
