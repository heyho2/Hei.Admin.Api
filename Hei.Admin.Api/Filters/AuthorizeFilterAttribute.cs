using Hei.Admin.ViewModel;
using Hei.Admin.ViewModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Hei.Admin.Service.Basic;
using Hei.Admin.Core.Redis;
using Hei.Admin.Service;

namespace Hei.Admin.Api.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private const string TokenKeyName = "Authorization";
        public RedisStringService _redisString;
        public AuthorizeFilterAttribute(RedisStringService redisString)
        {
            _redisString = redisString;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var methodInfo = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo;
            if (!methodInfo.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                string token = GetToken(context.HttpContext);
                if (!IsAuthenticated(token, context.HttpContext))
                {
                    HandleUnauthenticatedRequest(context);
                    return;
                }
            }
            base.OnActionExecuting(context);
        }
        private string GetToken(HttpContext context)
        {
            context.Request.Headers.TryGetValue(TokenKeyName, out StringValues vs);
            return vs.FirstOrDefault();
        }
        protected void HandleUnauthenticatedRequest(ActionExecutingContext context)
        {
            var response = context.HttpContext.Response;
            context.Result = new ApiActionResult
            {
                Message = "会话过期，请重新登录！",
                Code = 1,
                IsSucceed = false,
                HttpStatusCode = HttpStatusCode.Unauthorized
            };
        }
        protected bool IsAuthenticated(string token, HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var user = _redisString.Get<UserInfo>(string.Format(RedisKey.LoginTokenKey, token));
                if (user == null)
                {
                    return false;
                }
                else
                {
                    context.Items[nameof(UserInfo)] = user;
                    return true;
                }
            }
            return false;
        }
    }
}
