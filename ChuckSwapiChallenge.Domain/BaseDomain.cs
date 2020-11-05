using ChuckSwapiChallenge.Models.Errors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChuckSwapiChallenge.Domain
{
    public class BaseDomain
	{
		/// <summary>
		/// The application configurations
		/// </summary>
		protected readonly IConfiguration _config;

		public BaseDomain(IConfiguration config)
		{
			_config = config;
		}
		/// <summary>
		/// Makes an asynchronous call to external Chuck Norris and Star Wars API .
		/// </summary>
		/// <returns>
		/// The response from the api the gets called.
		/// </returns>
		/// <exception cref="ApiException">Thrown when the api is retuning an error of some sort.</exception>
		/// <param name="apiUrl">The url of the rest api that will get connected.</param>
		public async Task<T> GetApiData<T>(string apiUrl)
		{
			var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };

			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
			if (!response.IsSuccessStatusCode)
			{
				var exception = await JsonSerializer.DeserializeAsync<ApiError>(await response.Content.ReadAsStreamAsync());
				throw new ApiException($"[URL: { apiUrl }]: { exception.Message }", response.StatusCode);
			}
			var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
			return result;
		}
	}
}
