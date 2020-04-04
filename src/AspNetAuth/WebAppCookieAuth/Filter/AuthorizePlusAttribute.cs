using System;
using System.Web.Mvc;

namespace WebAppCookieAuth.Filter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var token = Convert.ToString(filterContext.HttpContext.Request.Cookies["mvcAuth"].Value);

            if (string.IsNullOrWhiteSpace(token))
            {
                base.HandleUnauthorizedRequest(filterContext);
            }

            var loginTime = Convert.ToDateTime(filterContext.HttpContext.Application[token]);

            if (loginTime > DateTime.UtcNow)
            {
                // 驗證通過
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}