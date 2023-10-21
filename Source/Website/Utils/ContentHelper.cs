namespace ImageGlassWeb.Utils;

public static class ContentHelper
{
    /// <summary>
    /// <c>wwwroot\content</c>
    /// </summary>
    public static string ContentDir => "contents";


    /// <summary>
    /// Gets the HTML content from folder wwwroot\<see cref="ContentDir"/>.
    /// </summary>
    /// <param name="wwwroot">
    /// Full path of wwwroot, example: <c>C:\wwwroot</c>
    /// </param>
    /// <param name="relativeFilePath">
    /// Relative file path, example: <c>News\33.html</c>
    /// </param>
    /// <returns><c>null</c> if there is an error</returns>
    public static async Task<string?> GetContentAsync(string wwwroot, string relativeFilePath)
    {
        try
        {
            var path = Path.Combine(wwwroot, ContentDir, relativeFilePath);
            var html = await File.ReadAllTextAsync(path);

            // render ImageGlass Store button
            html = html.Replace("##IMAGEGLASS_STORE##", """
                <ms-store-badge tabindex="0" class="btn btn-accent" productid="9N33VZK3C7TH" cid="ig_website_badge" window-mode="full" theme="auto" title="Get ImageGlass from Microsoft Store">
                </ms-store-badge>
            """);

            return html;
        }
        catch { }

        return null;
    }
}
