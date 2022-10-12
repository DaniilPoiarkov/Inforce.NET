using Inforce.NET.BLL.MappingProfiles;

namespace Inforce.NET
{
    public static class AppExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services
                .RegisterMappingProfiles()
                .ConfigureJwt();
        }

        public static IServiceCollection RegisterMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ShortedUrlProfile>();
                cfg.AddProfile<UserProfile>();
            });

            return services;
        }

        public static IServiceCollection ConfigureJwt(this IServiceCollection services)
        {
            return services;
        }
    }
}
