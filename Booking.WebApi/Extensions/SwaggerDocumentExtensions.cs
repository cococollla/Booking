using System.Reflection;

namespace Booking.WebApi.Extensions
{
    /// <summary>
    /// Класс расширения для swagger документации.
    /// </summary>
    public static class SwaggerDocumentExtensions
    {
        /// <summary>
        /// Настройка генерации swagger документации с комментариям.
        /// </summary>
        /// <param name="services">Коллекция серверов.</param>        
        public static IServiceCollection SwaggerDocumentationGenerat(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

                option.IncludeXmlComments(filePath);
            });

            return services;
        }

        /// <summary>
        /// Регистрации и настройка промежуточного ПО для Swagger UI.
        /// </summary>
        /// <param name="builder">Конвейер настройки приложения</param>
        public static IApplicationBuilder UseSwaggerWithUi(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                option.RoutePrefix = string.Empty;
            });

            return builder;
        }
    }
}