using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class BaseModel
{

    [Key]
    [Column(Order = 0)]
    public int Id { get; set; }


    [Column(Order = 1)]
    public bool? IsVisible { get; set; } = true;


    [Column(Order = 99, TypeName = "timestamp")]
    public DateTime CreatedDate { get; set; }


    [Column(Order = 100, TypeName = "timestamp")]
    public DateTime UpdatedDate { get; set; }


    /// <summary>
    /// Checks if the <see cref="CreatedDate"/> is within <c>7 days x 24 hours = 168</c> hours.
    /// </summary>
    public bool IsNewPost => CheckNewPost();

    /// <summary>
    /// Checks if the <see cref="CreatedDate"/> is within the given hours.
    /// Default is <c>7 days x 24 hours = 168</c> hours.
    /// </summary>
    public bool CheckNewPost(float hours = 7 * 24) => (DateTime.Now - CreatedDate).TotalHours <= hours;
}
