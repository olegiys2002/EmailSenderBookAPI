using EmailSender.Core.Services;

namespace EmailSender.API.ServicesConfiguration
{
    public static class AutoMapperExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
