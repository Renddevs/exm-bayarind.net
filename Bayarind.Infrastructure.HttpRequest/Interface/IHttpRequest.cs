using Bayarind.Infrastructure.HttpRequest.Object;

namespace Bayarind.Infrastructure.HttpRequest.Interface
{
    public interface IHttpRequest
    {
        Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequestData<T>(HttpMethod httpMethod, string token, EnumHttpRequest token_type, string url, object paramBody, Dictionary<string, string> additionalHeaders = null) where T : class;
        Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequestDataWithoutContent<T>(HttpMethod httpMethod, string token, string url, object paramBody, Dictionary<string, string> additionalHeaders = null) where T : class;
    }
}
