using HGV.Daedalus.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Daedalus.Converters
{
    public class  LeaverStatusConverter : JsonConverter<LeaverStatus>
    {
        public override LeaverStatus ReadJson(JsonReader reader, Type objectType, LeaverStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var status = (long)reader.Value;
            return (LeaverStatus)status;
        }

        public override void WriteJson(JsonWriter writer, LeaverStatus value, JsonSerializer serializer)
        {
            writer.WriteValue((long)value);
        }
    }
}
