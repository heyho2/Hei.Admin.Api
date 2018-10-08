using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Huach.Framework.Extend
{
    public static class EnumExtension
    {

        /// <summary>
        /// 获取当前枚举值的Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            string remark = string.Empty;
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            object[] attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            DescriptionAttribute attr = (DescriptionAttribute)attrs.FirstOrDefault(a => a is DescriptionAttribute);
            if (attr == null)
            {
                remark = fieldInfo.Name;
            }
            else
            {
                remark = attr.Description;
            }
            return remark;
        }

        /// <summary>
        /// 获取当前枚举的全部Remark
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetAllRemarks(this Enum value)
        {
            Type type = value.GetType();
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            //ShowAttribute.
            foreach (var field in type.GetFields())
            {
                if (field.FieldType.IsEnum)
                {
                    object tmp = field.GetValue(value);
                    Enum enumValue = (Enum)tmp;
                    int intValue = (int)tmp;
                    result.Add(new KeyValuePair<string, string>(intValue.ToString(), enumValue.GetDescription()));
                }
            }
            return result;
        }
        public static string GetDescription<T>(int value) where T : struct
        {
            var result = Enum.ToObject(typeof(T), value);
            if (result == null)
            {
                return null;
            }
            else
            {
                return ((Enum)result).GetDescription();
            }
        }
    }
}
