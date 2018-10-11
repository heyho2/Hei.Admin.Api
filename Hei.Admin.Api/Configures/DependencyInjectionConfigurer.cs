using Hei.Admin.Core;
using Hei.Admin.Core.Redis;
using Hei.Admin.Repository.Mysql;
using Hei.Admin.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace Hei.Admin.Api.Configures
{
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class DependencyInjectionConfigurer
    {
        private static ILoggerFactory Mlogger => new LoggerFactory()
            .AddDebug((categoryName, logLevel) => (logLevel == LogLevel.Information) && (categoryName == DbLoggerCategory.Database.Command.Name))
            .AddConsole((categoryName, logLevel) => (logLevel == LogLevel.Information) && (categoryName == DbLoggerCategory.Database.Command.Name));

        public static void Configure(IServiceCollection services, IConfiguration Configuration)
        {
            //var connection = Configuration.GetConnectionString("SqlServer");
            //services.AddDbContext<HuachDbContext>(options => options.UseSqlServer(connection).UseLoggerFactory(Mlogger));
            //services.AddTransient<DbContext, HuachDbContext>();
            var connection = Configuration.GetConnectionString("Mysql");
            if (connection == null)
            {
                throw new System.Exception("无法读取配置文件");
            }
            services.AddDbContext<HuachMysqlDbContext>(options => options.UseMySql(connection).UseLoggerFactory(Mlogger));
            services.AddTransient<DbContext, HuachMysqlDbContext>();
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
            services.AddTransient<RedisSetService>();
            services.AddTransient<RedisStringService>();

        }
    }
}
