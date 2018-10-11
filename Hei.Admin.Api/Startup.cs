using Hei.Admin.Api.Configures;
using Hei.Admin.Api.Filters;
using Hei.Admin.Repository;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Configuration;
using System.IO;
using System.Reflection;

namespace Hei.Admin.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var connection = Configuration.GetConnectionString("Mysql");
            //var connection2 = configuration["Authentication:JwtBearer:IsEnabled"];
            //throw new System.Exception(connection ?? "尼玛 是空的3");
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
        }
        // 此方法由运行时调用。 使用此方法可以调用容器的服务。
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();

            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(AuthorizeFilterAttribute));
                option.Filters.Add(typeof(ValidateModelFilterAttribute));
                option.Filters.Add(typeof(CustomExceptionFilterAttribute));
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());//JSON首字母小写解决

            DependencyInjectionConfigurer.Configure(services, Configuration);

            AuthConfigurer.Configure(services, Configuration);

            SwaggerConfigurer.Configure(services, Configuration);

            services.AddMvc();


        }

        // 运行时调用此方法。 使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseAuthentication();

            //app.UseMiddleware(typeof(ExceptionMiddleWare));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hey.Ho API V1");
                //c.InjectJavascript($"{Assembly.GetExecutingAssembly().GetName().Name}.Static.js.swagger_lang.js");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc();
        }
    }
}
