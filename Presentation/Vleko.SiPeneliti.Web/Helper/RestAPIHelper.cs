using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Vleko.Bayarind.Web.Models;
using System.Text;

namespace Vleko.Bayarind.Web.Helper
{
	public interface IRestAPIHelper
	{
		#region Identity
		Task<ObjectResponse<TokenModel>> Login(string username, string password);
		Task<ObjectResponse<TokenModel>> RefreshToken();
		Task<StatusResponse> Logoff();
		Task<dynamic> DoRequest(string url, string method, string body, bool isAnnonymous);
		#endregion
	}
	public class RestAPIHelper : IRestAPIHelper
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ILogger<RestAPIHelper> _logger;
		private string BASE_URL = "";
		private string VERSIONING = "v1";
		public RestAPIHelper(IHttpContextAccessor httpContextAccessor, ILogger<RestAPIHelper> logger, IConfiguration configuration)
		{
			_httpContextAccessor = httpContextAccessor;
			_logger = logger;
			BASE_URL = configuration.GetValue<string>("APIBaseUrl");
		}

		#region Identity
		public async Task<ObjectResponse<TokenModel>> Login(string username, string password)
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/login";
			var body = new { username, password };
			return await DoRequest<ObjectResponse<TokenModel>>(url, HttpMethod.Post, body, true);
		}
		public async Task<ObjectResponse<TokenModel>> RefreshToken()
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/refresh_token";
			return await DoRequest<ObjectResponse<TokenModel>>(url, HttpMethod.Post, null, false);
		}
		public async Task<StatusResponse> Logoff()
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/logoff";
			return await DoRequest<StatusResponse>(url, HttpMethod.Post, null, false);
		}
		#endregion

		#region Do Request Utility
		private async Task<ObjectResponse<string>> Request(string url, HttpMethod httpMethod, string json_body, bool isAnnonymous)
		{
			ObjectResponse<string> result = new ObjectResponse<string>();
			try
			{
				using (var client = new HttpClient())
				{
					client.Timeout = TimeSpan.FromMinutes(30);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

					if (!isAnnonymous && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
					{
						string token = _httpContextAccessor.HttpContext.User.Identities.First().Claims?.FirstOrDefault(x => x.Type.Equals("token"))?.Value;
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					}

					var request = new HttpRequestMessage(httpMethod, $"{url}");

					if ((httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put) && !string.IsNullOrWhiteSpace(json_body))
					{
						request.Content = new StringContent(json_body, Encoding.UTF8, "application/json");
					}

					var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
					var content = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrEmpty(content))
					{
						result.BadRequest("Something Went Wrong!");
						result.Code = (int)response.StatusCode;
						result.Message = response.StatusCode.ToString();
					}
					else
					{
						result.Data = content;
						result.OK();
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed Do Request", url);
				result.Error("Failed Request", ex.Message);
			}
			return result;
		}

		private async Task<T> DoRequest<T>(string url, HttpMethod method, object body, bool isAnnonymous) where T : class
		{
			var request = await Request(url, method, body != null ? JsonConvert.SerializeObject(body) : null, isAnnonymous);
			if (request.Succeeded)
			{
				return JsonConvert.DeserializeObject<T>(request.Data);
			}
			else
			{
				return null;
			}
		}
		public async Task<dynamic> DoRequest(string url, string method, string body, bool isAnnonymous)
		{
			HttpMethod _method = new HttpMethod(method);
			//string reqBody = "";
			//if (!string.IsNullOrWhiteSpace(body))
			//    reqBody = JsonConvert.DeserializeObject<dynamic>(body);

			var request = await Request($"{BASE_URL}{url}", _method, body, isAnnonymous);
			if (request.Succeeded)
			{
				return JsonConvert.DeserializeObject<dynamic>(request.Data);
			}
			else
			{
				return new
				{
					code = request.Code,
					succeeded = request.Succeeded,
					message = request.Message,
					description = request.Description
				};
			}
		}
		#endregion

	}
}
