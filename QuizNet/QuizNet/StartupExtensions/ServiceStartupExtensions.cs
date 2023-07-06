using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace QuizNet.StartupExtensions
{
    public static class ServiceStartupExtensions
    {
        public static IServiceCollection ConfigureAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ShipmentDb");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            }, ServiceLifetime.Scoped);


            return services;
        }

        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {

            // Repositories
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<IShipmentItemRepository, ShipmentItemRepository>();

            return services;
        }
    }
}
