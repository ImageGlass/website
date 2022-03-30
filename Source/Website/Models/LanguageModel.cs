#nullable disable
namespace ImageGlass.Models;

public class LanguageModel
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Phrases { get; set; }
    public string Translated { get; set; }
    public string Approved { get; set; }
    public string Words { get; set; }
    public string Words_translated { get; set; }
    public string Words_approved { get; set; }
    public int Translated_progress { get; set; }
    public int Approved_progress { get; set; }
    public int Qa_issues { get; set; }
}
