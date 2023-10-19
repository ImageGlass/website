#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class BinaryFileModel : BaseModel
{
    // Foreign key to ReleaseModel
    [Column(Order = 2)]
    public int ReleaseId { get; set; }


    [Column(Order = 3, TypeName = "varchar(50)")]
    public string Type { get; set; } = BinaryType.Installer;


    [Column(Order = 4, TypeName = "varchar(20)")]
    public string Architecture { get; set; } = FileArchitecture.X64;


    [Column(Order = 5, TypeName = "varchar(10)")]
    public string FileType { get; set; } = "msi";


    [Column(Order = 6, TypeName = "varchar(255)")]
    public string Link { get; set; } = string.Empty;


    [Column(Order = 7)]
    public int Count { get; set; } = 0;


    public ReleaseModel Release { get; set; }
}


public static class BinaryType
{
    public static string Installer => "installer";
    public static string Portable => "portable";
}


public static class FileArchitecture
{
    public static string X64 => "x64";
    public static string X86 => "x86";
    public static string ARM64 => "arm64";
    public static string AnyCpu => "any-cpu";
}
