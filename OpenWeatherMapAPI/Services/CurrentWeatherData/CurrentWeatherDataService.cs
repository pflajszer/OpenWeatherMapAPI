using Flurl;
using Flurl.Http;
using OpenWeatherMapAPI.Models.CurrentWeatherData;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.Shared;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.CurrentWeatherData
{
	public class CurrentWeatherDataService : APIGateway, ICurrentWeatherDataService
	{
		/// <summary>
		/// API key. More at: https://openweathermap.org/appid
		/// </summary>
		private readonly string _apiKey;


		public CurrentWeatherDataService(string apiKey, string apiUrl = Constants.APIUrl_Ver2_5)
			: base(apiUrl, Constants.Endpoint_CurrentWeatherData)
		{
			_apiKey = apiKey;
		}

		public async Task<CurrentWeatherDataResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request)
		{
			var res = await ExecuteGetAsync<CurrentWeatherDataResponse>(new
			{
				lat = request.Latitude,
				lon = request.Longitude,
				appid = _apiKey
			});
			return res;
		}
	}
}
