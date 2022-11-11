#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class BinaryFileModel : BaseModel
{
    [Column(TypeName = "text")]
    public string ReleaseCode { get; set; } = "kobe";
    public BinaryType Type { get; set; } = BinaryType.Installer;
    public FileArchitecture Architecture { get; set; } = FileArchitecture.X64;
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

public enum BinaryType
{
    Installer,
    Portable,
}

public enum FileArchitecture
{
    X64,
    X86,
    ARM64,
}
