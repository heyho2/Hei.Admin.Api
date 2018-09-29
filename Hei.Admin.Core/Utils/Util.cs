using System;
using System.Collections.Generic;
using System.Text;

namespace Hei.Admin.Core.Utils
{
    public static class Util
    {
        /// <summary>
        /// 获取指定时间到格林威治时间的秒数 (对应php中的time()方法)
        /// UTC：格林威治时间1970年01月01日00时00分00秒（UTC+8北京时间1970年01月01日08时00分00秒）
        /// </summary>
        /// <returns></returns>
        public static long Time(DateTime? dateTime = null)
        {
            DateTimeOffset dto = new DateTimeOffset(dateTime ?? DateTime.Now);
            return dto.ToUnixTimeSeconds();
        }
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime Time(long timeStamp)
        {
            var dto = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
            return dto.ToLocalTime().DateTime;
        }
        /// <summary>
        ///   时间戳转本地时间
        /// </summary> 
        public static DateTime ToDateTime(this long unix, bool allowZero = false)
        {
            if (!allowZero && unix <= 0)
                throw new ArgumentException("时间戳值为 0 。", nameof(unix));

            var dto = DateTimeOffset.FromUnixTimeSeconds(unix);
            return dto.ToLocalTime().DateTime;
        }
    }
}
