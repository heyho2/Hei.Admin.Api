﻿using Hei.Admin.ViewModel;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hei.Admin.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILog log = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));
        public override void OnException(ExceptionContext context)
        {
            Log(context.Exception);
            var response = context.HttpContext.Response;
            //状态码
            if (context.Exception is UnauthorizedAccessException)
            {
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is Exception)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            context.Result = new ApiActionResult
            {
                Message = context.Exception.ToString(),
                Code = 1,
                IsSucceed = false,
                HttpStatusCode = HttpStatusCode.InternalServerError
            };
        }
        public void Log(Exception exception)
        {
            log.Error(exception);
            //记录日志
            //LogHelper.LogInformation(exception.Message.ToString());
        }
    }
}
