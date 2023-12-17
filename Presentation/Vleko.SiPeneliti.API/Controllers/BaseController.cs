using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using MediatR;
using AutoMapper;
using System.Security.Claims;
using Vleko.Bayarind.Core.Helper;
using Vleko.Bayarind.Core.Attributes;

namespace Vleko.Bayarind.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController<T> : Controller
    {
        private IMediator _mediatorInstance;
        private ILogger<T> _loggerInstance;
        private IMapper _mapperInstance;
        private ITokenHelper _tokenInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();
        protected ITokenHelper _token => _tokenInstance ??= HttpContext.RequestServices.GetService<ITokenHelper>();
        protected IActionResult Wrapper<TT>(TT val)
        {
            dynamic result = val!;
            int code = result.Code;
            return this.StatusCode(code, val);
        }

        protected TokenObject Token
        {
            get
            {
                var result = new TokenObject();
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var requestKey))
                {
                    if (requestKey.Count > 0)
                    {
                        var key = requestKey.First().Split(' ');
                        if (key.Length == 2 && key[0].ToLower().Trim() == "bearer")
                        {
                            var decode_token = _token.DecodeToken(key[1]);
                            if (decode_token.Succeeded)
                                result = decode_token.Data;
                        }
                    }
                }
                return result;
            }
        }
        protected string Inputer
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                string name = identity.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value;
                return !string.IsNullOrWhiteSpace(name) ?name:"SYSTEM";
            }
        }
    }

}
