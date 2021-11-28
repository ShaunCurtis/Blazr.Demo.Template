/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace $safeprojectname$
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWASMApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastDataBroker, WeatherForecastAPIDataBroker>();
            AddCommonServices(services);
            return services;
        }

        public static IServiceCollection AddServerApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
            AddCommonServices(services);
            return services;
        }

        public static IServiceCollection AddWASMServerApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
            return services;
        }

        private static void AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddScoped<WeatherForecastViewService>();
        }
    }
}
