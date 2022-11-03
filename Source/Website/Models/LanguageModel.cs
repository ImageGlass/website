#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class LanguageModel
{
    [Column(TypeName = "text")]
    public string Name { get; set; }
    [Column(TypeName = "text")]
    public string Code { get; set; }
    [Column(TypeName = "text")]
    public string Phrases { get; set; }
    [Column(TypeName = "text")]
    public string Translated { get; set; }
    [Column(TypeName = "text")]
    public string Approved { get; set; }
    [Column(TypeName = "text")]
    public string Words { get; set; }
    [Column(TypeName = "text")]
    public string Words_translated { get; set; }
    [Column(TypeName = "text")]
    public string Words_approved { get; set; }
    [Column(TypeName = "text")]
    public int Translated_progress { get; set; }
    public int Approved_progress { get; set; }
    public int Qa_issues { get; set; }
}
