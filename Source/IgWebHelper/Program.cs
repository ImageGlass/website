

namespace IgWebHelper;

internal static class Program
{
    public static string[] CmdArgs
    {
        get
        {
            var args = Environment.GetCommandLineArgs()
                .Skip(1) // skip the exe itself path
                .ToArray() ?? Array.Empty<string>();

            return args;
        }
    }


    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static int Main(string[] args)
    {
        var topCmd = string.Empty;
        if (CmdArgs.Length > 0) topCmd = CmdArgs[0].ToLowerInvariant().Trim();


        // md-to-html <srcDir> <destDir>
        if (topCmd == "md-to-html")
        {
            if (CmdArgs.Length < 3) return 1;

            var srcDir = CmdArgs[1];
            var destDir = CmdArgs[2];

            Functions.ConvertMarkdownToHtmlFilesAsync(srcDir, destDir).Wait();
        }


        return 0;
    }
}




