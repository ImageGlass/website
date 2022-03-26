#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;

namespace ImageGlass.Controllers;

public class NewsController : Controller
{
    private readonly ImageGlassContext _context;

    public NewsController(ImageGlassContext context)
    {
        _context = context;
    }

    // GET: News
    [HttpGet("news")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.News.ToListAsync());
    }

    // GET: News/Details/5
    [HttpGet("news/{id}")]
    public async Task<IActionResult> Details(int? id)
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
    public async Task<IActionResult> Create([Bind("Slug,Title,Image,Description,Content,ID,Visible,CreatedDate,UpdatedDate")] NewsModel newsModel)
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
    public async Task<IActionResult> Edit(int id, [Bind("Slug,Title,Image,Description,Content,ID,Visible,CreatedDate,UpdatedDate")] NewsModel newsModel)
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
