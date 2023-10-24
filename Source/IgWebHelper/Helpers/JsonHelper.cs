using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IgWebHelper;

public class JsonHelper
{
    public static JsonSerializerOptions JsonOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,

        Converters =
        {
            // Write enum value as string
            new JsonStringEnumConverter(),

            new CustomDateTimeConverter(Constants.DATETIME_FORMAT),
        },

        // ignoring policy
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyProperties = true,
        IgnoreReadOnlyFields = true,
    };


    /// <summary>
    /// Parse JSON string to object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    public static T? ParseJson<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, JsonOptions);
    }


    /// <summary>
    /// Parse object to JSON string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    public static string ToJson<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, typeof(T), JsonOptions);
    }


    /// <summary>
    /// Parse JSON from a stream
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stream"></param>
    public static async Task<T?> ParseJsonAsync<T>(Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, JsonOptions);
    }


    /// <summary>
    /// Reads JSON file and parses to object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsonFilePath"></param>
    public static T? ReadJson<T>(string jsonFilePath)
    {
        using var stream = File.OpenRead(jsonFilePath);

        return JsonSerializer.Deserialize<T>(stream, JsonOptions);
    }


    /// <summary>
    /// Writes an object value to JSON file
    /// </summary>
    /// <param name="jsonFilePath"></param>
    /// <param name="value"></param>
    public static async Task WriteJsonAsync(string jsonFilePath, object? value, CancellationToken token = default)
    {
        var json = JsonSerializer.Serialize(value, JsonOptions);

        await File.WriteAllTextAsync(jsonFilePath, json, Encoding.UTF8, token);
    }
}


public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string Format;
    public CustomDateTimeConverter(string format)
    {
        Format = format;
    }

    public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
    {
        writer.WriteStringValue(date.ToString(Format));
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString() ?? "";

        return DateTime.ParseExact(str, Format, null);
    }
}

