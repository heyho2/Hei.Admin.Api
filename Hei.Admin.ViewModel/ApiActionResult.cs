namespace Hei.Admin.ViewModel
{
    /// <summary>
    /// api响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiActionResult<T> : Core.Models.ApiActionResult
    {
        /// <summary>
        /// 消息
        /// </summary>
        public virtual string Message { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public virtual T Data { get; set; }
        /// <summary>
        /// code 0表示成功
        /// </summary>
        public virtual int Code { get; set; } = 0;
        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool IsSucceed { get; set; } = true;
    }
    /// <summary>
    /// api响应基类
    /// </summary>
    public class ApiActionResult : ApiActionResult<string>
    {

    }
}
