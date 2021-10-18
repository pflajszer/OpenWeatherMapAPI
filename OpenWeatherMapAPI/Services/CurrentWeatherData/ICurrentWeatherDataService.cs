using OpenWeatherMapAPI.Models.CurrentWeatherData;
using OpenWeatherMapAPI.Models.Shared;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.CurrentWeatherData
{
	public interface ICurrentWeatherDataService
	{
		Task<CurrentWeatherDataResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request);
	}
}