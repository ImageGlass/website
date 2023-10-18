using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImageGlassWeb.Controllers;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        // Work only for GET request
        if (context.HttpContext.Request.Method != "GET")
            return;

        // Do not work with AjaxRequests
        if (IsAjaxRequest(context.HttpContext.Request))
            return;

        var con = (Controller)context.Controller;

        // set basic meta data
        con.ViewData[PageInfo.Name] = "ImageGlass";
        con.ViewData[PageInfo.SiteName] = "ImageGlass - A lightweight, versatile image viewer";

        con.ViewData[PageInfo.Title] = "ImageGlass - A lightweight, versatile image viewer";
        con.ViewData[PageInfo.Description] = "ImageGlass is a simple-to-use photo viewer that comes packed with ultimate functions in a nice minimal modern user interface, works with all image formats.";
        con.ViewData[PageInfo.Keywords] = "free photo viewer, best photo viewer, simple fast image viewer, windows 11 photo viewer, lightweight image viewer, best photo viewer for windows 11, open source image viewer, fast switch between images, photo viewer, minimalist image viewer, quick photo viewer, image converter, extract gif file, alternative windows 10, Irfanview alternatives, animated GIF files, imageglass, duong dieu phap, raw photo viewer, heic viewer, svg viewer, color picker, rapid viewing of pictures";

        con.ViewData[PageInfo.H1] = "ImageGlass is a simple-to-use photo viewer that comes packed with ultimate functions in a nice minimal modern user interface, works with all image formats, includes GIF, SVG, HEIC, WEBP, AVIF,... It is designed to take the place of the photo viewer in Windows 11, 10, especially those installations that may have trouble displaying PNG and GIF files.";

        con.ViewData[PageInfo.Author] = "Duong Dieu Phap";
        con.ViewData[PageInfo.Thumbnail] = "https://github.com/ImageGlass/config/raw/main/screenshots/v9.0-beta-2/9.0b2_1.jpg";
    }


    /// <summary>
    /// Determines whether the specified HTTP request is an AJAX request.
    /// </summary>
    /// <returns>
    /// true if the specified HTTP request is an AJAX request; otherwise, false.
    /// </returns>
    /// <param name="request">The HTTP request.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="request"/> parameter is null.
    /// </exception>
    public static bool IsAjaxRequest(HttpRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (request.Headers != null)
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";

        return false;
    }


    /// <summary>
    /// Gets id from the slug-id url.
    /// Example url: "https://imageglass.org/news/hello-world-38" return <c>38</c>.
    /// </summary>
    public static int? GetIdFromSlugId(string? slugId)
    {
        var strArr = slugId?.Split("-", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var idStr = strArr?.LastOrDefault();

        if (int.TryParse(idStr, out var id))
        {
            return id;
        }

        return null;
    }
}
