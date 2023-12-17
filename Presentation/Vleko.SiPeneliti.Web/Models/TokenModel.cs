using Vleko.Result;

namespace Vleko.Bayarind.Web.Models
{
    public class TokenModel
    {
        public TokenUserModel User { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string RawToken { get; set; }
        public string RefreshToken { get; set; }
    }
    public class TokenUserModel
    {
        public Guid Id { get; set; }
        public ReferensiStringObject Role { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
