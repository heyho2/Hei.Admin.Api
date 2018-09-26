using System.Collections.Generic;
using Hei.Admin.ViewModel.Base;

namespace Hei.Admin.ViewModel.Base
{
    /// <summary>
    /// 列表查询响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseQueryListResponse<T> : BaseResponse
    {
        /// <summary>
        /// 数据
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}