using IgWebHelper;
using ImageGlassWeb.Models;
using System.Net;
using System.Net.Http.Headers;

namespace ImageGlassWeb.Utils;

public class GitHub
{
    public static string MetaOpenTag => "```json(\\s|\\n)+#metadata";
    public static string MetaCloseTag => "#metadata(\\s|\\n)+```";
    public static string IgHost => "imageglass.org";


    public static string IgReleaseRepo => "ImageGlass/releases";
    public static string RepoBranch => "main";
    public static string RawFileContentUrlPrefix => @$"https://raw.githubusercontent.com/{IgReleaseRepo}/{RepoBranch}/";
    public static string ContentUrlPrefix => @$"https://api.github.com/repos/{IgReleaseRepo}/contents/";


    /// <summary>
    /// Gets files from GitHub folder: <c>/{user}/{repo}/Contents/{gitHubPaths}</c>
    /// </summary>
    /// <param name="gitHubPaths"></param>
    /// <exception cref="HttpRequestException"></exception>
    public static async Task<List<GitHubFileModel>> GetFilesAsync(params string[] gitHubPaths)
    {
        var path = string.Join("/", gitHubPaths) ?? "";
        var url = new Uri($"{ContentUrlPrefix}{path}?ref={RepoBranch}");

        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            var list = await client.GetFromJsonAsync<List<GitHubFileModel>>(url, JsonHelper.JsonOptions);


            return list ?? new();
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound
                || ex.StatusCode == HttpStatusCode.Forbidden)
            {
                return new();
            }

            throw new HttpRequestException(ex.Message, ex.InnerException, ex.StatusCode);
        }
    }

}

