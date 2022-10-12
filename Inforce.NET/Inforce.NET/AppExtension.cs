using Inforce.NET.BLL;
using Inforce.NET.BLL.MappingProfiles;
using Inforce.NET.DAL;
using Inforce.NET.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Inforce.NET
{
    public static class AppExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterMappingProfiles()
                .ConnectDatabase(configuration)
                .ConfigureJwt();

            services.AddTransient<TestService>();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }

        private static IServiceCollection RegisterMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ShortedUrlProfile>();
                cfg.AddProfile<UserProfile>();
            });

            return services;
        }

        private static IServiceCollection ConfigureJwt(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection ConnectDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings:Inforce"]);
            });
            return services;
        }
    }
}
