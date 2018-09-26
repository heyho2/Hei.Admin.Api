using Hei.Admin.Api.MiddleWare;
using Hei.Admin.Api.SwaggerExtensions;
using Hei.Admin.Core;
using Hei.Admin.IRepository;
using Hei.Admin.IRepository.Basic;
using Hei.Admin.Repository;
using Hei.Admin.Repository.Basic;
using Hei.Admin.Service;
using Hei.Admin.Service.Basic;
using Hei.Admin.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hei.Admin.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // 此方法由运行时调用。 使用此方法可以调用容器的服务。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());//JSON首字母小写解决

            var connection = Configuration.GetConnectionString("SqlServer");
            services.AddDbContext<HuachDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<DbContext, HuachDbContext>();
            //1.批量注册Service
            {
                Assembly assembly = Assembly.LoadFrom($"{ System.AppDomain.CurrentDomain.BaseDirectory}{typeof(BaseService<>).Assembly.GetName().Name}.dll");
                foreach (var item in assembly.GetTypes().Where(a => typeof(IService).IsAssignableFrom(a) && a != typeof(BaseService<>)))
                {
                    services.AddTransient(item);
                }
            }
            {
                //1.批量注册Repository
                Assembly assembly1 = Assembly.LoadFrom($"{ System.AppDomain.CurrentDomain.BaseDirectory}{typeof(BaseRepository<>).Assembly.GetName().Name}.dll");
                foreach (var item in assembly1.GetTypes().Where(a => typeof(IService).IsAssignableFrom(a) && a != typeof(BaseRepository<>)))
                {
                    //var @interface = item.GetInterface($"I{item.Name}");
                    var @interfaces = item.GetInterfaces()?.Where(a => typeof(IService).IsAssignableFrom(a) && a != typeof(IService));
                    foreach (var @interface in @interfaces)
                    {
                        services.AddTransient(@interface, item);
                    }
                }
            }


            AuthConfigurer.Configure(services, Configuration);
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


            services.AddMvc();
        }

        // 运行时调用此方法。 使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HuachDbContext dbContext)
        {
            dbContext.Database.GetPendingMigrations();
            dbContext.Database.Migrate();
            //dbContext.Database.GetPendingMigrations();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMiddleware(typeof(ExceptionMiddleWare));
            //app.UseMiddleware(typeof(AuthorizeMiddleWare));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hey.Ho API V1");
                //c.InjectJavascript($"{Assembly.GetExecutingAssembly().GetName().Name}.Static.js.swagger_lang.js");
            });

            app.UseMvc();
        }
    }
}
