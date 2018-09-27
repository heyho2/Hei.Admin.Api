using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hei.Admin.Api.SwaggerExtensions;
using Hei.Admin.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Hei.Admin.Api.Configures
{
    /// <summary>
    /// Swagger配置
    /// </summary>
    public static class SwaggerConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Hei API",
                    Contact = new Contact
                    {
                        Name = "Hey.Ho",
                        Email = "752645265@qq.com",
                    }
                });
                //确定应用程序的基本路径。
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //设置swagger json和ui的注释路径。
                options.IncludeXmlComments(Path.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                options.IncludeXmlComments(Path.Combine(basePath, $"{typeof(ApiActionResult).Assembly.GetName().Name}.xml"));
                options.OperationFilter<HttpHeaderOperation>();
            });
        }
    }
}
