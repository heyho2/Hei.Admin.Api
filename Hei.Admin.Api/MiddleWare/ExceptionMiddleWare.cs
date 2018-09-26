using Hei.Admin.Api.MiddleWare;
using Hei.Admin.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hei.Admin.Api.MiddleWare
{
    public class ExceptionMiddleWare : MiddleWare
    {
        public ExceptionMiddleWare(RequestDelegate next) : base(next)
        {
        }
        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            //记录日志
            LogHelper.LogInformation(exception.GetBaseException().ToString());

            var response = context.Response;
            //状态码
            if (exception is UnauthorizedAccessException)
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception is Exception)
                response.StatusCode = (int)HttpStatusCode.BadRequest;

            response.ContentType = "application/json";
            await response.WriteAsync(
                JsonConvert.SerializeObject(new ApiActionResult
                {
                    Message = "服务器异常",
                    Code = 1,
                    IsSucceed = false,
                    HttpStatusCode = HttpStatusCode.InternalServerError
                })).ConfigureAwait(false);

        }


    }
}
