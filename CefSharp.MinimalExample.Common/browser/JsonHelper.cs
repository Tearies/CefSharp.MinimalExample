using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CefSharp.MinimalExample.Common.browser
{
    public class JsonHelper 
    {
        public static Newtonsoft.Json.JsonSerializerSettings DefaultSetting { get; private set; }
        static JsonHelper()
        {
            DefaultSetting = new JsonSerializerSettings()
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
            };
            DefaultSetting.Converters.Add(new StringEnumConverter());
          
            //全局序列化设置
            Newtonsoft.Json.JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                var setting = JsonHelper.DefaultSetting;
                return setting;
            });
        }
        public static string SerializeObject(object obj, Newtonsoft.Json.JsonSerializerSettings setting = null)
        {
            if (setting == null) setting = JsonHelper.DefaultSetting;
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, setting);
        }
    }
}