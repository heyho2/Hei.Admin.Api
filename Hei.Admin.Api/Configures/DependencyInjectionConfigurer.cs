using Hei.Admin.Core;
using Hei.Admin.Repository;
using Hei.Admin.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Hei.Admin.Api.Configures
{
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class DependencyInjectionConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration Configuration)
        {
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
        }
    }
}
