using Hei.Admin.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Core.Models
{
    public abstract class ApiActionResult : IActionResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public virtual HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
        /// <summary>
        /// 执行响应结果
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode;
            await response.WriteAsync(JsonHelper.Serialize(this));
        }
    }
}
