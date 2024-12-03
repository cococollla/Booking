using Booking.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.DAL
{
    /// <summary>
    /// Класс регистрации инфраструктурного слоя.
    /// </summary>
    public static class RegisterInfrastructure
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
