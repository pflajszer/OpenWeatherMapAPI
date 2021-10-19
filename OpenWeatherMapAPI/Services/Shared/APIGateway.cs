using Flurl;
using Flurl.Http;
using OpenWeatherMapAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.Shared
{
	public class APIGateway
	{

		/// <summary>
		/// Endpoint for the current API
		/// </summary>
		private readonly string _endpoint;

		public APIGateway(string endpoint)
		{
			_endpoint = endpoint;
		}

		public async Task<T> ExecuteGetAsync<T>(object queryParams)
		{
			try
			{
				var url =
					OpenWeatherMapAPIClientConfiguration.APIURL +
					OpenWeatherMapAPIClientConfiguration.APIVersion
					.AppendPathSegment(_endpoint)
					.SetQueryParams(queryParams);

				var res = await url.GetJsonAsync<T>();
				return res;
			}
			catch (FlurlHttpException ex)
			{

				throw ex;
			}
		}
	}
}
