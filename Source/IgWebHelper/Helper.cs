

using Markdig.Syntax.Inlines;
using Markdig;
using System.Text.RegularExpressions;
using Markdig.Syntax;
using Markdig.Renderers.Html;

namespace IgWebHelper;

public static class Helper
{
    public static string MetaOpenTag => "```json(\\s|\\n)+#metadata";
    public static string MetaCloseTag => "#metadata(\\s|\\n)+```";
    public static string IgHost => "imageglass.org";




    /// <summary>
    /// Gets page content data from markdown string.
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

                if (str.Contains("#metadata"))
                {
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
    /// Parses markdown to HTML.
    /// </summary>
    public static string ParseMarkdown(string? mdContent)
    {
        if (string.IsNullOrEmpty(mdContent)) return string.Empty;

        // Configure the pipeline with all advanced extensions active
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();

        var mdDoc = Markdown.Parse(mdContent, pipeline);


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
