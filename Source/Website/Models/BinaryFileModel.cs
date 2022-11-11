#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class BinaryFileModel : BaseModel
{
    [Column(TypeName = "text")]
    public string ReleaseCode { get; set; } = "kobe";
    [Column(TypeName = "text")]
    public string Type { get; set; } = BinaryType.Installer;
    [Column(TypeName = "text")]
    public string Architecture { get; set; } = FileArchitecture.X64;
    [Column(TypeName = "text")]
    public string FileType { get; set; } = "msi";
    [Column(TypeName = "text")]
    public string Link { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Checksum { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string HashAlgorithm { get; set; } = "sha-1";
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
}
