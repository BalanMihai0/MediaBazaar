using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

public class DateOnlyNewtonsoftJsonConverter : DateTimeConverterBase
{
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;

        if (reader.TokenType == JsonToken.Date)
        {
            DateTime dateTimeValue = (DateTime)reader.Value;
            return DateOnly.FromDateTime(dateTimeValue);
        }

        var s = (string)reader.Value;
        return DateOnly.TryParse(s, out var date) ? date : DateOnly.MinValue;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is DateOnly dateOnly)
        {
            writer.WriteValue(dateOnly.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
        else
        {
            throw new JsonSerializationException($"Unexpected value when converting date. Value: {value}");
        }
    }
}