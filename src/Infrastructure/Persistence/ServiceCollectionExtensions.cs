using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración del DbContext de EF Core
            services.AddDbContext<AutomovilDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Aquí solo registramos infraestructura
            // NO registrar servicios de Application (IAutomovilService) en Infrastructure

            return services;
        }
    }
}