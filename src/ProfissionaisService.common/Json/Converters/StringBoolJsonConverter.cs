using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProfissionaisService.common.Json.Converters;

public class StringBoolJsonConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => bool.TryParse(
                reader.GetString() is "1" or "0" ? ReadNumberStringBoolean(reader.GetString()) : reader.GetString(),
                out var boolean)
                ? boolean
                : throw new JsonException(),
            _ => throw new JsonException()
        };
    }

    private string ReadNumberStringBoolean(string? value)
    {
        return value is "1" ? bool.TrueString : bool.FalseString;
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value ? "1" : "0");
    }
}