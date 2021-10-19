using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.AirPollution;
using OpenWeatherMapAPI.Services.CurrentWeatherData;

namespace OpenWeatherMapAPI.APIClient
{
	public class OpenWeatherMapAPIClient : IOpenWeatherMapAPIClient
	{
		public OpenWeatherMapAPIClient()
		{
			CurrentWeatherData = new CurrentWeatherDataService();
			AirPollution = new AirPollutionService();
		}

		public ICurrentWeatherDataService CurrentWeatherData { get; set; }
		public IAirPollutionService AirPollution { get; set; }
	}
}
