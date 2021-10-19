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
		public CurrentWeatherDataService()
			: base(Constants.Endpoint_CurrentWeatherData)
		{
		}

		public async Task<CurrentWeatherDataResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request)
		{
			var res = await ExecuteGetAsync<CurrentWeatherDataResponse>(new
			{
				lat = request.Latitude,
				lon = request.Longitude,
				appid = OpenWeatherMapAPIClientConfiguration.APIKey
			});
			return res;
		}
	}
}
