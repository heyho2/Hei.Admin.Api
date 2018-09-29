using System;
using System.Collections.Generic;
using System.Text;

namespace Hei.Admin.Service
{
    public class RedisKey
    {
        public const string Prefix = "Hei:Api:";
        /// <summary>
        /// token
        /// 0:token
        /// </summary>
        public const string LoginTokenKey = Prefix + "Token:{0}";
    }
}
