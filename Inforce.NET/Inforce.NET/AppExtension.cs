using Inforce.NET.BLL;
using Inforce.NET.BLL.MappingProfiles;
using Inforce.NET.BLL.Services;
using Inforce.NET.Common.AuxiliaryModels.Options;
using Inforce.NET.DAL;
using Inforce.NET.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Inforce.NET
{
    public static class AppExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterMappingProfiles()
                .ConnectDatabase(configuration)
                .ConfigureJwt(configuration);

            services
                .AddTransient<TestService>()
                .AddTransient<AuthService>()
                .AddTransient<UserService>();
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

        private static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = signingKey,
                };
            });

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
