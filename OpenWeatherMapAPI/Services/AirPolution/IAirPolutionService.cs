using OpenWeatherMapAPI.Models.AirPolution;
using OpenWeatherMapAPI.Models.Shared;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.AirPolution
{
	public interface IAirPolutionService
	{
		Task<AirPolutionResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request);
	}
}