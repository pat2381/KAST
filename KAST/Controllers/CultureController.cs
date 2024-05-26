using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace KAST.Controllers
{
    [Route("[controller]/[action]")]
    public class CultureController : Controller
    {
        public IActionResult Set(string culture, string redirectUri)
        {
            if(culture != null)
            {
                var requestCulture = new RequestCulture(culture, culture);
                var cookieName = CookieRequestCultureProvider.DefaultCookieName;
                var cookiValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);


                HttpContext.Response.Cookies.Append(cookieName, cookiValue);
            }

            return LocalRedirect(redirectUri);
        }
    }
}
