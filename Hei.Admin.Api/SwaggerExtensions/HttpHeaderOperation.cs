using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hei.Admin.Api.SwaggerExtensions
{
    public class HttpHeaderOperation : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            if (context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {

                var authorized = methodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
                if (authorized == null)//提供action都没有权限特性标记，检查控制器有没有
                {
                    operation.Parameters.Add(new NonBodyParameter()
                    {
                        Description = "权限认证，请相登陆，获取token",
                        Name = "Authorization",  //添加Authorization头部参数
                        In = "header",
                        Type = "apiKey",
                        //Required = true
                    });
                }
            }
        }
    }
}
