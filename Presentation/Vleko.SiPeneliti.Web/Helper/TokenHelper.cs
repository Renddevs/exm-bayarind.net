using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Vleko.Bayarind.Web.Models;

namespace Vleko.Bayarind.Web.Helper
{
    public interface ITokenHelper
    {
        (ClaimsPrincipal principal, AuthenticationProperties properties) CreateToken(TokenModel request);
        (bool Success, TokenModel Token) DecodeToken(HttpContext context);
    }
    public class TokenHelper : ITokenHelper
    {
        private readonly ILogger _logger;
        public TokenHelper(IConfiguration configuration,
            ILogger<TokenHelper> logger
            )
        {
            _logger = logger;
        }

        #region Create
        public (ClaimsPrincipal principal, AuthenticationProperties properties) CreateToken(TokenModel request)
        {
            try
            {
                var claims = new List<Claim>()
                    {
                        new Claim("user_id", request.User.Id.ToString()),
                        new Claim("username", request.User.Username),
                        new Claim("given_name", request.User.FullName),
                        new Claim(ClaimTypes.Email, request.User.Mail),
                        new Claim(ClaimTypes.MobilePhone, request.User.Phone),
                        new Claim("token", request.RawToken),
                        new Claim("refresh",request.RefreshToken),
                        new Claim("role_id",request.User.Role.Id),
                        new Claim("role_name",request.User.Role.Nama)
                    };
                var identity = new ClaimsIdentity(claims, "Bayarind");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.Now.ToUniversalTime(),
                    ExpiresUtc = request.ExpiredAt
                };
                return (principal, properties);
            }
            catch (Exception)
            {
                return (null, null);
            }
        }
        #endregion

        #region Decode
        public (bool Success, TokenModel Token) DecodeToken(HttpContext context)
        {
            try
            {
                var claims = context.User.Identities?.First().Claims.ToList();
                if (claims != null && claims.Count() > 0)
                {
                    var token = new TokenModel()
                    {
                        RawToken = claims?.FirstOrDefault(x => x.Type.Equals("token"))?.Value,
                        RefreshToken = claims?.FirstOrDefault(x => x.Type.Equals("refresh"))?.Value,
                        User = new TokenUserModel()
                        {
                            Id = Guid.Parse(claims?.FirstOrDefault(x => x.Type.Equals("user_id"))?.Value),
                            FullName = claims?.FirstOrDefault(x => x.Type.Equals("given_name"))?.Value,
                            Username = claims?.FirstOrDefault(x => x.Type.Equals("username"))?.Value,
                            Mail = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value,
                            Phone = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.MobilePhone))?.Value,
                            Role = new Result.ReferensiStringObject()
                            {
                                Id = claims?.FirstOrDefault(x => x.Type.Equals("role_id"))?.Value,
                                Nama = claims?.FirstOrDefault(x => x.Type.Equals("role_name"))?.Value,
                            }
                        }
                    };
                    return (true, token);
                }
                else
                    return (false, null);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }
        #endregion
    }
}