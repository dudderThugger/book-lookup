using BookLookUp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLookUp.Services
{
    /// <summary>
    /// A custom Newtonsoft.Json.JsonConverter to resolve non consistent fields in the respond objects
    /// for instance when a field can either have a JsonObject or string as a value, the Converter resolves
    /// the objects to an ObjectJSON object
    /// </summary>
    public class ObjectJSONConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// Decides if the value to convert to is the expected ObjectJSON type
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectJSON);
        }
        /// <summary>
        /// Reads a JSON resource and tries to convert it to an ObjectJSON typed object
        /// </summary>
        /// <param name="reader">The reader that contains the JSON resource</param>
        /// <param name="objectType">Type of the object</param>
        /// <param name="existingValue">The existing value of object being read</param>
        /// <param name="serializer">The calling serializer</param>
        /// <returns>The ObjectJSON value</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            ObjectJSON obj = new ObjectJSON();

            if(reader.TokenType == JsonToken.StartObject)
            {
                var token = JToken.Load(reader);
                foreach (var value in token.Values())
                {
                    obj = value.ToObject<ObjectJSON>();
                }
            } else if (reader.TokenType == JsonToken.String)
            {
                obj.Value = (string)reader.Value;
            }

            return obj;
        }
        /// <summary>
        /// Unimplementhed method of the abstract parent class
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            // Don't use this
            throw new NotImplementedException();
        }
    }
}
