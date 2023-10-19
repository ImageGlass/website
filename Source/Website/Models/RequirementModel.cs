#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class RequirementModel : BaseModel
{
    [Column(Order = 2, TypeName = "text")]
    public string Content { get; set; } = string.Empty;


    public List<ReleaseModel> Releases { get; set; }

}
