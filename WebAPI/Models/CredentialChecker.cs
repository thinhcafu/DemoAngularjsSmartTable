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
    public class CredentialChecker
    {
        public AuthenticationUser CheckCredential(string username, string password)
        {
            if (username == "thinhcafu" && password == "1234")
                return new AuthenticationUser() { userName="thinhcafu", passWord="1234",role="admin"};
            return null;
        }
    }
}