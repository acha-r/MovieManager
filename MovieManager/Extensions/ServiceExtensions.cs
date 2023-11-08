using Microsoft.EntityFrameworkCore;
using MovieManager.Data.Context;
using MovieManager.Data.Implementation;
using MovieManager.Data.Interface;
using MovieManager.Services.MovieServices;
using MovieManager.Services.ServiceFactory;

namespace MovieManager.Extensions
{
    public static class ServiceExtension
    {
        public static void AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConn")
         ));
        }
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddTransient<IServiceFactory, ServiceFactory>();
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
