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
    public class AuthenticationUser
    {
        public string userName { get; set; }

        public string passWord { get; set; }

        public string role { get; set; }
    }
}