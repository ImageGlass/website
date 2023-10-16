#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class LanguageModel
{
    [Column(TypeName = "text")]
    public string LanguageId { get; set; }

    [Column(TypeName = "text")]
    public string Name { get; set; }

    public int TranslationProgress { get; set; }
}
