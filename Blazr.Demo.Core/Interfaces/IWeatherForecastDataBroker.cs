/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace $safeprojectname$
{
    /// <summary>
    /// The data broker interface abstracts the interface between the logic layer and the data layer.
    /// </summary>
    public interface IWeatherForecastDataBroker
    {
        public Task<bool> AddForecastAsync(WeatherForecast record);

        public Task<bool> DeleteForecastAsync(Guid Id);

        public Task<List<WeatherForecast>> GetWeatherForecastsAsync();

    }
}
