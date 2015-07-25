using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace WebAPI.Models
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokens = request.Headers.Authorization;
            if (tokens != null)
            {
                string authValue = request.Headers.Authorization.Parameter;
                string[] tokensValues = Encoding.ASCII.GetString(Convert.FromBase64String(authValue)).Split(new[] { ':' });
                AuthenticationUser ObjUser = new CredentialChecker().CheckCredential(tokensValues[0], tokensValues[1]);// kt username & password
                if (ObjUser != null)
                {
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(ObjUser.userName), ObjUser.role.Split(','));
                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                }

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}