/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace $safeprojectname$
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastDataBroker _dataBroker;

        public WeatherForecastController(IWeatherForecastDataBroker weatherForecastDataBroker)
            => _dataBroker = weatherForecastDataBroker;

        [Route("/api/weatherforecast/GetRecordsAsync")]
        [HttpGet]
        public async Task<List<WeatherForecast>> GetRecordsAsync() 
            => await _dataBroker.GetRecordsAsync();

        [Route("/api/weatherforecast/GetPagedRecordsAsync")]
        [HttpPost]
        public async Task<List<WeatherForecast>> GetPagedRecordsAsync([FromBody] PagingData pagingData) 
            => await _dataBroker.GetPagedRecordsAsync(pagingData);

        [Route("/api/weatherforecast/GetRecordCountAsync")]
        [HttpGet]
        public async Task<int> GetRecordCountAsync() 
            => await _dataBroker.GetRecordCountAsync();
    }
}
