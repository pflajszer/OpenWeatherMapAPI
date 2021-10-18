using OpenWeatherMapAPI.Services.CurrentWeatherData;

namespace OpenWeatherMapAPI.APIClient
{
	public interface IOpenWeatherMapAPIClient
	{
		ICurrentWeatherDataService CurrentWeatherData { get; set; }
	}
}