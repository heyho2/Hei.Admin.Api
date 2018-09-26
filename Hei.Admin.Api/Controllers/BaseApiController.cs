using Hei.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hei.Admin.Api.Controllers
{
    public class BaseApiController : Controller
    {
        protected internal ApiActionResult<T> Success<T>(T data, string message = null)
        {
            return new ApiActionResult<T>
            {
                Data = data,
                Message = message ?? "成功"
            };
        }
        protected internal ApiActionResult Success(string data, string message)
        {
            return new ApiActionResult
            {
                Data = data,
                Message = message ?? "成功"
            };
        }
        protected internal ApiActionResult Success(string message = null)
        {
            return new ApiActionResult
            {
                Message = message ?? "成功"
            };
        }
        protected internal ApiActionResult Fail(string message, int code = 1)
        {
            return new ApiActionResult
            {
                Message = message ?? "失败",
                Code = code,
                IsSucceed = false
            };
        }
    }
}
