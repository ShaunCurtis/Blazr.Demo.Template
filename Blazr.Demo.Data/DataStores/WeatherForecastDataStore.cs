/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using $ext_projectname$.Core;

namespace $safeprojectname$
{
    public class WeatherForecastDataStore
    {
        private int _recordsToGet = 5;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<WeatherForecast> _records;

        public WeatherForecastDataStore()
            =>
            _records = GetForecasts();

        private List<WeatherForecast> GetForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, _recordsToGet).Select(index => new WeatherForecast
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }

        public Task<bool> AddForecastAsync(WeatherForecast record)
        {
            _records.Add(record);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteForecastAsync(Guid Id)
        {
            var deleted = false;
            var record = _records.FirstOrDefault(item => item.Id == Id);
            if (record != null)
            {
                _records.Remove(record);
                deleted = true;
            }
            return Task.FromResult(deleted);
        }

        public Task<List<WeatherForecast>> GetWeatherForecastsAsync()
        {
            var list = new List<WeatherForecast>();
            _records
                .ForEach(item => list.Add(item with { }));
            return Task.FromResult(list);
        }
    }
}
