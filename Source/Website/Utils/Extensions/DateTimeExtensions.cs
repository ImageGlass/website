
namespace ImageGlassWeb.Utils;

public static class DateTimeExtensions
{
    /// <summary>
    /// Formats the <see cref="DateTime"/> to string using <see cref="Constants.DATETIME_FORMAT"/>.
    /// </summary>
    public static string ToDateTimeString(this DateTime dt)
    {
        return dt.ToString(Constants.DATETIME_FORMAT);
    }


    /// <summary>
    /// Formats the <see cref="DateTime"/> to string using <see cref="Constants.DATE_FORMAT"/>.
    /// </summary>
    public static string ToDateString(this DateTime dt)
    {
        return dt.ToString(Constants.DATETIME_FORMAT);
    }
}

