using Hei.Admin.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hei.Admin.ViewModel.User
{
    /// <summary>
    /// 登陆请求
    /// </summary>
    public class LoginRequest : BaseRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
    }
    /// <summary>
    /// 登陆响应
    /// </summary>
    public class LoginResponse : BaseResponse
    {
        /// <summary>
        /// 权限吗
        /// </summary>
        public string Authorization { get; set; }
    }
}
