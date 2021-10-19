using OpenWeatherMapAPI.Models.AirPollution;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.AirPollution
{
	public class AirPollutionService : APIGateway, IAirPollutionService
	{
		/// <summary>
		/// API key. More at: https://openweathermap.org/appid
		/// </summary>
		private readonly string _apiKey;


		public AirPollutionService(string apiKey, string apiUrl = Constants.APIUrl_Ver2_5)
			: base(apiUrl, Constants.Endpoint_AirPollution)
		{
			_apiKey = apiKey;
		}

		public async Task<AirPollutionResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request)
		{
			var res = await ExecuteGetAsync<AirPollutionResponse>(new
			{
				lat = request.Latitude,
				lon = request.Longitude,
				appid = _apiKey
			});
			return res;
		}
	}
}
