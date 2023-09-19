using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Guid = System.Guid;

namespace GCS.Core.Common.NetCore.Api
{
    public class StringGuidLowerCaseConverter : JsonConverter<string>
	{
        public override string Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var sValue = reader.GetString();
            var g = Guid.Empty;
            if( Guid.TryParse(sValue, out g))
                sValue.ToLower();
            else
            {
                sValue;
            }
		}
            

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options)
        {
            var g = Guid.Empty;
            if( Guid.TryParse(value, out g))
                writer.WriteStringValue(value.ToLower());
            else
            {
                writer.WriteStringValue(value);
            }
		}
            
    }
}
