using System;
using System.Collections.Generic;
using System.Text;

namespace Hei.Admin.ViewModel.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
    }
}
