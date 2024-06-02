using Newtonsoft.Json;

public class NullToDoubleConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(double);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) 
            return null;

        string value = Convert.ToString(reader.Value)!.Replace(".", ",");
        double.TryParse(value, out var result);
        return result;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
        writer.WriteValue(value?.ToString());
    }
}
