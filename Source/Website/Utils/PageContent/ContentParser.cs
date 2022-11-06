using System;
using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using Markdig.Extensions.AutoLinks;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace ImageGlass.Utils;

public class ContentParser
{
    public static string MetaOpenTag = "```json(\\s|\\n)+#metadata";
    public static string MetaCloseTag = "#metadata(\\s|\\n)+```";
    public static string IgHost = "imageglass.org";


    public static string WebsiteContentRepo = "ImageGlass/website-content";
    public static string RepoBranch = "main";
    public static string RawFileContentUrlPrefix => @$"https://raw.githubusercontent.com/{WebsiteContentRepo}/{RepoBranch}/";
    public static string ContentUrlPrefix = @$"https://api.github.com/repos/{WebsiteContentRepo}/contents/";



    /// <summary>
    /// Gets raw content from GitHub folder: /user/repo/Contents/paths...
    /// </summary>
    /// <param name="paths"></param>
    /// <returns><c>null</c> if status code is 404.</returns>
    /// <exception cref="HttpRequestException"></exception>
    public static async Task<string?> GetGitHubFileContentAsync(params string[] paths)
    {
        var path = string.Join("/", paths) ?? "";
        var url = new Uri($"{RawFileContentUrlPrefix}{path}");

        try
        {
            using var client = new HttpClient();
            var rawContent = await client.GetStringAsync(url);

            return rawContent;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            throw new HttpRequestException(ex.Message, ex.InnerException, ex.StatusCode);
        }
    }


    /// <summary>
    /// Gets page content data from markdown string
    /// </summary>
    /// <param name="rawContent">Markdown string</param>
    public static (string MetaJson, string Content) GetPageContentData(string? rawContent)
    {
        if (string.IsNullOrEmpty(rawContent)) return (string.Empty, string.Empty);

        var metaJsonRegex = $"{MetaOpenTag}((.|\n)*?){MetaCloseTag}";
        var regxMatch = Regex.Match(rawContent, metaJsonRegex);

        if (regxMatch.Success && regxMatch.Groups.Count > 1)
        {
            var metaSection = "";
            var metaJson = "";

            foreach (var group in regxMatch.Groups)
            {
                var str = group.ToString() ?? string.Empty;

                if (str.Contains("#metadata")) {
                    metaSection = str;
                }
                else if (str.Contains('{') && str.Contains('}'))
                {
                    metaJson = str;
                    break;
                }
            }

            var content = rawContent.Replace(metaSection, "", StringComparison.InvariantCultureIgnoreCase);

            return (metaJson, content);
        }

        return (string.Empty, string.Empty);
    }


    /// <summary>
    /// Parses JSON string to <see cref="PageMetadata"/>.
    /// </summary>
    public static PageMetadata? ParsePageMeta(string? jsonMeta)
    {
        if (string.IsNullOrEmpty(jsonMeta)) return null;

        var metadata = JsonHelper.ParseJson<PageMetadata>(jsonMeta);

        return metadata;
    }


    /// <summary>
    /// Parses markdown to HTML.
    /// </summary>
    public static string ParseMarkdown(string? content)
    {
        if (string.IsNullOrEmpty(content)) return string.Empty;

        // Configure the pipeline with all advanced extensions active
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();

        var mdDoc = Markdown.Parse(content, pipeline);


        // process inline-link:
        // example: [download](https://imageglass.org/dowload)
        foreach (var link in mdDoc.Descendants<LinkInline>())
        {
            if (!link.IsImage && link.Url is not null && !link.Url.Contains(IgHost))
            {
                var attrs = link.GetAttributes();

                attrs.AddPropertyIfNotExist("target", "_blank");
                attrs.AddPropertyIfNotExist("ref", "noopener nofollow");
            }
        }

        // process auto-link:
        // example: https://imageglass.org/dowload
        foreach (var link in mdDoc.Descendants<AutolinkInline>())
        {
            if (link.Url is not null && !link.Url.Contains(IgHost))
            {
                var attrs = link.GetAttributes();

                attrs.AddPropertyIfNotExist("target", "_blank");
                attrs.AddPropertyIfNotExist("ref", "noopener nofollow");
            }
        }

        var html = mdDoc.ToHtml(pipeline);

        return html;
    }
}

