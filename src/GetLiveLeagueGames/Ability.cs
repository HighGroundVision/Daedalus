using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace HGV.Daedalus.GetLiveLeagueGames
{
    using ConverterType = List<Ability>;

    public class Ability
    {
        public int ability_id { get; set; }
        public int ability_level { get; set; }
    }

    public class AbilityDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ConverterType));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(existingValue == null)
            {
                var items = new Dictionary<int, ConverterType>();

                JToken token = JToken.Load(reader);
                items.Add(0, token.ToObject<ConverterType>());

                return items;
            }
            else if (existingValue is Dictionary<int, ConverterType>)
            {
                var items = existingValue as Dictionary<int, ConverterType>;

                JToken token = JToken.Load(reader);
                items.Add(items.Count, token.ToObject<ConverterType>());

                return items;
            }
            else
            {
                throw new Exception("AbilityDataConverter: Can not read json of a unknown type.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
