using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImageGlass.Controllers;

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
		con.ViewData[PageInfo.Description] = "ImageGlass is a lightweight, open source photo viewer that designed to take place Windows Photo Viewer, work with all image formats, includes GIF, SVG, HEIC.";
        con.ViewData[PageInfo.Keywords] = "free photo viewer, best photo viewer, simple fast image viewer, windows 10 photo viewer, lightweight image viewer, best photo viewer for windows 10, open source image viewer, fast switch between images, photo viewer, minimalist image viewer, quick photo viewer, image converter, extract gif file, alternative windows 10, Irfanview alternatives, animated GIF files, imageglass, duong dieu phap, raw photo viewer, heic viewer, svg viewer, color picker, rapid viewing of pictures";
        
        con.ViewData[PageInfo.H1] = "ImageGlass is a lightweight, versatile image viewing application that is designed to take the place of Photo Viewer in Windows 10, 8, 7 and Vista, especially those installations that may have trouble displaying PNG and GIF files in Photo Viewer.";
        
		con.ViewData[PageInfo.Author] = "Duong Dieu Phap";
        con.ViewData[PageInfo.Thumbnail] = "";
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
