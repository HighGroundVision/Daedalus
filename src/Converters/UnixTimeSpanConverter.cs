using Newtonsoft.Json;
using System;

namespace HGV.Daedalus.Converters
{
    public class UnixTimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var seconds = (long)reader.Value;
            return DateTimeOffset.FromUnixTimeSeconds(seconds).TimeOfDay;
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            writer.WriteValue(value.TotalSeconds);
        }
    }
}
