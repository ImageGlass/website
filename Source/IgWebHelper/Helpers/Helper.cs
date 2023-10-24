using Markdig;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System.Text.RegularExpressions;

namespace IgWebHelper;

public static class Helper
{
    public static string MetaOpenTag => "```json(\\s|\\n)+#metadata";
    public static string MetaCloseTag => "#metadata(\\s|\\n)+```";
    public static string IgHost => "imageglass.org";


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


    /// <summary>
    /// Separate the <c>MetaSection</c> from the markdown content.
    /// </summary>
    public static (string MetaSection, string MarkdownContent) ProcessMarkdownContent(string? rawMdContent)
    {
        var metaSection = string.Empty;
        var mdContent = string.Empty;

        if (string.IsNullOrWhiteSpace(rawMdContent)) return (metaSection, mdContent);


        var metaJsonRegex = $"{MetaOpenTag}((.|\n)*?){MetaCloseTag}";
        var regxMatch = Regex.Match(rawMdContent, metaJsonRegex);

        if (regxMatch.Success && regxMatch.Groups.Count > 1)
        {
            foreach (var group in regxMatch.Groups)
            {
                var str = group.ToString() ?? string.Empty;

                if (str.Contains("#metadata"))
                {
                    metaSection = str;
                    break;
                }
            }

            // get markdown content without metadata
            mdContent = rawMdContent.Replace(metaSection, "", StringComparison.InvariantCultureIgnoreCase);
        }
        else
        {
            mdContent = rawMdContent;
        }

        return (metaSection, mdContent);
    }


    /// <summary>
    /// Separates <see cref="PageMetadata"/> from the HTML content.
    /// </summary>
    public static (PageMetadata? Metadata, string HtmlContent) ProcessHtmlContent(string? rawHtmlContent)
    {
        PageMetadata? metadata = null;
        var htmlContent = string.Empty;

        if (string.IsNullOrWhiteSpace(rawHtmlContent)) return (metadata, htmlContent);


        var metaJsonRegex = $"{MetaOpenTag}((.|\n)*?){MetaCloseTag}";
        var regxMatch = Regex.Match(rawHtmlContent, metaJsonRegex);

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

            // get markdown content without metadata
            htmlContent = rawHtmlContent.Replace(metaSection, "", StringComparison.InvariantCultureIgnoreCase);

            // parse page data
            metadata = JsonHelper.ParseJson<PageMetadata>(metaJson);
        }
        else
        {
            htmlContent = rawHtmlContent;
        }

        return (metadata, htmlContent);
    }

}
