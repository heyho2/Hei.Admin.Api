using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hei.Admin.ViewModel;
using Hei.Admin.ViewModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Hei.Admin.Api.MiddleWare
{
    public class AuthorizeMiddleWare : MiddleWare
    {
        private const string TokenKeyName = "Authorization";
        public AuthorizeMiddleWare(RequestDelegate next) : base(next)
        {
        }
        public override async Task Invoke(HttpContext context)
        {
            //var authorized = methodInfo.GetCustomAttribute<AllowAnonymousAttribute>();

            string token = GetToken(context);
            if (!IsAuthenticated(token, context))
            {
                await HandleUnauthenticatedRequest(context);
            }
            await Next(context);
        }

        private string GetToken(HttpContext context)
        {
            context.Request.Headers.TryGetValue(TokenKeyName, out StringValues vs);
            return vs.FirstOrDefault();
        }

        protected async Task HandleUnauthenticatedRequest(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            await response.WriteAsync(
                JsonConvert.SerializeObject(new ApiActionResult
                {
                    Message = "会话过期，请重新登录！",
                    Code = 1,
                    IsSucceed = false,
                    HttpStatusCode = HttpStatusCode.Unauthorized
                })).ConfigureAwait(false);
        }

        protected bool IsAuthenticated(string token, HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                //var user = RedisHelper.ClusterInstance.Get<UserInfo>(string.Format(Constant.AdminUserKey, token));
                UserInfo user = null;
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
