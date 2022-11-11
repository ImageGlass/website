using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class BaseModel
{
    [Key]
    public int Id { get; set; }

    public bool IsVisible { get; set; } = true;

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Checks if the <see cref="CreatedDate"/> is within the given hours.
    /// Default is <c>7 days x 24 hours = 168</c> hours.
    /// </summary>
    public bool IsNewPost(float hours = 7*24) => (DateTime.Now - CreatedDate).TotalHours <= hours;

}
