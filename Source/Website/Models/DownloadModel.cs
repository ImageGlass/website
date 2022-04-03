#nullable disable
using System.ComponentModel.DataAnnotations;

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
    public string ReleaseCode { get; set; } = "kobe";
    public DownloadType Type { get; set; } = DownloadType.Installer;
    public DownloadArchitecture Architecture { get; set; } = DownloadArchitecture.X64;
    public string FileType { get; set; } = "msi";
    public string Link { get; set; } = string.Empty;
    public string Checksum { get; set; } = string.Empty;
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
