using CompetencePlatform.Application.Models.WeatherForecast;

namespace CompetencePlatform.Application.Services;

public interface IWeatherForecastService
{
    public Task<IEnumerable<WeatherForecastResponseModel>> GetAsync();
}
