using OpenWeatherMapAPI.Models.AirPolution;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.AirPolution
{
	public class AirPolutionService : APIGateway, IAirPolutionService
	{
		/// <summary>
		/// API key. More at: https://openweathermap.org/appid
		/// </summary>
		private readonly string _apiKey;


		public AirPolutionService(string apiKey, string apiUrl = Constants.APIUrl_Ver2_5)
			: base(apiUrl, Constants.Endpoint_AirPolution)
		{
			_apiKey = apiKey;
		}

		public async Task<AirPolutionResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request)
		{
			var res = await ExecuteGetAsync<AirPolutionResponse>(new
			{
				lat = request.Latitude,
				lon = request.Longitude,
				appid = _apiKey
			});
			return res;
		}
	}
}
