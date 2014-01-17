using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Xunmei.XPM.Business;

namespace Xunmei.XPM.Site.Web
{
    /// <summary>
    /// 通过数据库查询用户权限进行认证。
    /// </summary>
    class AclAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool allow = false;
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            string controller = (string)httpContext.Request.RequestContext.RouteData.Values["controller"];
            string action = (string)httpContext.Request.RequestContext.RouteData.Values["action"];
            allow = AuthorizationManager.CanAccess(httpContext.User.Identity.Name, controller, action);

            return allow;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectResult(SiteUrls.Login);
        }
    }
}

