using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class BaseModel
{
    public bool Visible { get; set; } = true;

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime UpdatedDate { get; set; }
}
