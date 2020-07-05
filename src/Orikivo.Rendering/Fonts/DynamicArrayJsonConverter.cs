using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Orikivo
{

    public class DynamicArrayJsonConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(char[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            token.Type.Debug("Token Type");
            
            if (token.Type == JTokenType.String)
            {
                return new char[] { token.ToObject<char>() };
            }

            if (token.Type == JTokenType.Array)
                return token.ToObject<char[]>();
            
            return new char[] { token.ToObject<char>() };
        }

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}