using Vleko.Bayarind.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Vleko.Bayarind.Web.Controllers 
{
    public class BaseController<T> : Controller
    {
        private ILogger<T> _loggerInstance;
        private IRestAPIHelper _apiRequestInstance;
        private ITokenHelper _tokenHelperInstance;
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IRestAPIHelper _apiRequest => _apiRequestInstance ??= HttpContext.RequestServices.GetService<IRestAPIHelper>();
        protected ITokenHelper _tokenHelper => _tokenHelperInstance ??= HttpContext.RequestServices.GetService<ITokenHelper>();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool is_admin = false;
            if (User.Identity.IsAuthenticated)
            {
                var token = _tokenHelper.DecodeToken(HttpContext);
                if (token.Success)
                {
                    ViewBag.Token = token.Token;
                    is_admin = token.Token.User.Role.Id == "ADM";
                }
            }
            if(RouteData.Values["controller"].ToString().ToLower() == "admin" && !is_admin)
            {
                context.Result = RedirectToAction("Forbidden", "Home");
                return;
            }
        }


    }
}