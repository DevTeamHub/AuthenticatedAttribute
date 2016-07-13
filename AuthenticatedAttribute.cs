using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DevTeam.AuthenticatedAttribute
{
    public class AuthenticatedAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var context = actionContext.Request.GetOwinContext();
            if (!context.Authentication.User.Identity.IsAuthenticated)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}
