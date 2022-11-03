#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public enum DownloadType
{
    Installer,
    Portable,
}

public enum DownloadArchitecture
{
    X64,
    X86,
}

public class DownloadModel : BaseModel
{
    [Key]
    public int DownloadId { get; set; }
    [Column(TypeName = "text")]
    public string ReleaseCode { get; set; } = "kobe";
    public DownloadType Type { get; set; } = DownloadType.Installer;
    public DownloadArchitecture Architecture { get; set; } = DownloadArchitecture.X64;
    [Column(TypeName = "text")]
    public string FileType { get; set; } = "msi";
    [Column(TypeName = "text")]
    public string Link { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Checksum { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Size { get; set; } = string.Empty;
    public int Count { get; set; } = 0;

    
    public int ReleaseId { get; set; }
    public ReleaseModel Release { get; set; }
}


public class VDownloadDetails
{
    public int DownloadId { get; set; }
    public string ReleaseCode { get; set; } = "kobe";
    public DownloadType Type { get; set; } = DownloadType.Installer;
    public DownloadArchitecture Architecture { get; set; } = DownloadArchitecture.X64;
    public string FileType { get; set; } = "msi";
    public string Link { get; set; } = string.Empty;
    public string Checksum { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }


    public VDownloadDetails() { }

    public VDownloadDetails(DownloadModel model)
    {
        DownloadId = model.DownloadId;
        ReleaseCode = model.ReleaseCode;
        Type = model.Type;
        Architecture = model.Architecture;
        FileType = model.FileType;
        Link = model.Link;
        Checksum = model.Checksum;
        Size = model.Size;
        Count = model.Count;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}
