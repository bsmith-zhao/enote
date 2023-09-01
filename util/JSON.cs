using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using util.ext;

namespace util
{
    public static class Json
    {
        public static JsonSerializerSettings CONF = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            DateFormatString = "yyyy'/'MM'/'dd' 'HH':'mm':'ss'.'fff",
        };

        public static T obj<T>(this string json)
            => JsonConvert.DeserializeObject<T>(json, CONF);

        public static object obj(this string json, Type type)
            => JsonConvert.DeserializeObject(json, type, CONF);

        public static string jsonIndent(this object obj)
            => JsonConvert.SerializeObject(obj, Formatting.Indented, CONF);

        public static string json(this object obj)
            => JsonConvert.SerializeObject(obj, Formatting.None, CONF);

        public static T jcopy<T>(this object obj)
            => obj.json().obj<T>();

        public static object jcopy(this object obj, Type type)
            => obj.json().obj(type);

        public static T jclone<T>(this T obj)
            => obj.json().obj<T>();
    }
}
