using OpenWeatherMapAPI.Models.AirPollution;
using OpenWeatherMapAPI.Models.Shared;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.AirPollution
{
	public interface IAirPollutionService
	{
		Task<AirPollutionResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request);
	}
}