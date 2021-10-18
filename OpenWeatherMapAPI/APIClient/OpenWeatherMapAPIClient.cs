using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.AirPolution;
using OpenWeatherMapAPI.Services.CurrentWeatherData;

namespace OpenWeatherMapAPI.APIClient
{
	public class OpenWeatherMapAPIClient : IOpenWeatherMapAPIClient
	{
		public OpenWeatherMapAPIClient(string apiKey, string APIUrl = Constants.APIUrl_Ver2_5)
		{
			CurrentWeatherData = new CurrentWeatherDataService(apiKey, APIUrl);
			AirPolution = new AirPolutionService(apiKey, APIUrl);
		}

		public ICurrentWeatherDataService CurrentWeatherData { get; set; }
		public IAirPolutionService AirPolution { get; set; }
	}
}
