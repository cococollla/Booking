using Booking.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Application
{
    /// <summary>
    /// Регистрация Application слоя.
    /// </summary>
    public static class RegisterApplication
    {
        /// <summary>
        /// Регистрация сервисов.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped<BookingService>();

            return services;
        }
    }
}
