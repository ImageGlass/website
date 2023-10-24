
using System.Text;

namespace IgWebHelper;

public static class Functions
{
    /// <summary>
    /// Convert all markdown files to html files
    /// </summary>
    public static async Task ConvertMarkdownToHtmlFilesAsync(string srcDir, string destDir)
    {
        var mdFiles = Directory.EnumerateFiles(srcDir, "*.md", new EnumerationOptions()
        {
            RecurseSubdirectories = true,
        });
        if (!mdFiles.Any()) return;


        try
        {
            // delete old files
            Directory.Delete(destDir, true);
        }
        catch { }

        // create destination dir
        Directory.CreateDirectory(destDir);


        // start converting markdown to html
        await Parallel.ForEachAsync(mdFiles, async (filePath, token) =>
        {
            var fileContent = await File.ReadAllTextAsync(filePath, Encoding.UTF8, token);

            // separate metadata and markdown content
            var (metaSection, markdownContent) = Helper.ProcessMarkdownContent(fileContent);

            // parse markdown to html then append to the metadata section
            var html = metaSection + Helper.ParseMarkdown(markdownContent);


            // the new file name: 33.html
            var newFileName = $"{Path.GetFileNameWithoutExtension(filePath)}.html";

            // the file dir path: C:\content\News
            var fileDir = Path.GetDirectoryName(filePath) ?? srcDir;

            // get the output dir: \News
            var outDir = fileDir.Replace(srcDir, "", StringComparison.InvariantCultureIgnoreCase);
            var destOutDir = destDir;

            if (!string.IsNullOrWhiteSpace(outDir))
            {
                // remove \: News
                if (outDir.StartsWith("\\")) outDir = outDir[1..];

                // final dest dir: D:\content\News
                destOutDir = Path.Combine(destDir, outDir);
            }

            // final file path: D:\content\News\33.html
            var newFilePath = Path.Combine(destOutDir, newFileName);
            Directory.CreateDirectory(destOutDir);

            await File.WriteAllTextAsync(newFilePath, (string)html, Encoding.UTF8, token);
        });
    }
}

