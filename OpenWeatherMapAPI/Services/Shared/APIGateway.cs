using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.Shared
{
	public class APIGateway
	{
		/// <summary>
		/// Base API URL
		/// </summary>
		private readonly string _apiUrl;

		/// <summary>
		/// Endpoint for the current API
		/// </summary>
		private readonly string _endpoint;

		public APIGateway(string apiUrl, string endpoint)
		{
			_apiUrl = apiUrl;
			_endpoint = endpoint;
		}

		public async Task<T> ExecuteGetAsync<T>(object queryParams)
		{
			try
			{
				var url =
					_apiUrl
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
