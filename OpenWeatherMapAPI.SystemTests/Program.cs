using Flurl.Http;
using Newtonsoft.Json;
using OpenWeatherMapAPI.APIClient;
using OpenWeatherMapAPI.TestResources;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.SystemTests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sut = new OpenWeatherMapAPIClient(BaseConstants.APIkey);
			CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult(sut).Wait();
			CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(sut).Wait();
			AirPolutionService_ByGeographicCoordinatesAsync_CanGetResult(sut).Wait();
			AirPolutionService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(sut).Wait();
		}

		#region CurrentWeatherDataService
		private static async Task CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult)}");
			var sut = client.CurrentWeatherData;
			var result = await sut.ByGeographicCoordinatesAsync(Requests.ByGeographicCoordinatesRequest_Valid);
			Console.WriteLine(JsonConvert.SerializeObject(result));
			ReportSuccess();
		}

		private static void ReportSuccess()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("SUCCESS");
			Console.ResetColor();
		}

		private static async Task CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput)}");
			var sut = client.CurrentWeatherData;
			try
			{
				var result = await sut.ByGeographicCoordinatesAsync(Requests.ByGeographicCoordinatesRequest_Invalid);
			}
			catch (FlurlHttpException ex)
			{
				if (ex.StatusCode == 400)
				{
					ReportSuccess();
				}
				else
				{
					ReportFailure(ex);
				};
			}
		}

		private static void ReportFailure(FlurlHttpException ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ERROR - UNEXPECTED EXCEPTION");
			Console.WriteLine(JsonConvert.SerializeObject(ex));
			Console.ResetColor();
		}
		#endregion

		#region AirPolutionService
		private static async Task AirPolutionService_ByGeographicCoordinatesAsync_CanGetResult(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(AirPolutionService_ByGeographicCoordinatesAsync_CanGetResult)}");
			var sut = client.AirPolution;
			var result = await sut.ByGeographicCoordinatesAsync(Requests.ByGeographicCoordinatesRequest_Valid);
			Console.WriteLine(JsonConvert.SerializeObject(result));
			ReportSuccess();
		}

		private static async Task AirPolutionService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(AirPolutionService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput)}");
			var sut = client.AirPolution;
			try
			{
				var result = await sut.ByGeographicCoordinatesAsync(Requests.ByGeographicCoordinatesRequest_Invalid);
			}
			catch (FlurlHttpException ex)
			{
				if (ex.StatusCode == 400)
				{
					ReportSuccess();
				}
				else
				{
					ReportFailure(ex);
				};
			}
		}
		#endregion
	}
}
