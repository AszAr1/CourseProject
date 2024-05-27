using Newtonsoft.Json;

public class NullToDoubleConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(double);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        double result;
        string value = ((string)reader.Value!).Replace(".", ",");
        if (double.TryParse(value, out result)){
            return result;
        }
        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}
