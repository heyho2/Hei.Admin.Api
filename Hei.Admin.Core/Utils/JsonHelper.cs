using System;
using System.Collections.Generic;
using System.Text;

namespace Hei.Admin.Core.Utils
{
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化
        /// Newtonsoft 序列化null=>"null"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// json解析（有null判断）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim() == "{}" || value.Trim() == "[]")
            {
                return default(T);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }
        /// <summary>
        /// json解析（有null判断）
        /// 异常处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryDeserialize<T>(string value, out T result)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = default(T);
                return false;
            }
            try
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }
    }
}
