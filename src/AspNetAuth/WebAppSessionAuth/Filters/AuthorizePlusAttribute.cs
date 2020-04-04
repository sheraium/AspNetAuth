using System;
using System.Web.Mvc;

namespace WebAppSessionAuth.Filters
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {
                // 驗證成功
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}