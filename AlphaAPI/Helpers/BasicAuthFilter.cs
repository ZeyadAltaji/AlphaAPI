using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace AlphaAPI.BasicAuth
{

    public class BasicAuthFilter : IAuthorizationFilter
    {
        private readonly string _realm;

        public BasicAuthFilter(string realm)
        {
            _realm = realm;
            if (string.IsNullOrWhiteSpace(_realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
            }
        }

        private static byte[] HashHMAC(byte[] method, byte[] ip)
        {
            var hash = new HMACSHA256(method);
            return hash.ComputeHash(ip);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string method = context.HttpContext.Request.Path.Value.ToString().Replace("/", "");
            byte[] Ipbytes = Encoding.ASCII.GetBytes(ip);
            byte[] Methodbytes = Encoding.ASCII.GetBytes(method);
            string str = Encoding.ASCII.GetString(HashHMAC(Methodbytes, Ipbytes));
            List<string> wl = new List<string>()
            {
                "getfilesx","getfilex","getapi","wfcr","getimage","wfnotify","notify", "updater","alert","conversat5ions" ,"updatedatabase", "test"
            };

            try
            {
                var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
                if (descriptor != null)
                    if (wl.Contains(descriptor.ActionName.ToString().ToLower()))
                        return;

                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8
                                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 2);
                        if (credentials.Length == 2)
                        {
                            if (IsAuthorized(context, credentials[0], credentials[1]))
                            {
                                return;
                            }
                        }
                    }
                }
                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(AuthorizationFilterContext context, string username, string password)
        {
            if (username.Trim() == "Powered-By" && password.Trim() == "Hasan Abu Ghalyoun")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }
    }
    public class VoltBasicAuthFilter : IAuthorizationFilter
    {
        private readonly string _realm;

        public VoltBasicAuthFilter(string realm)
        {
            _realm = realm;
            if (string.IsNullOrWhiteSpace(_realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
            }
        }

        private static byte[] HashHMAC(byte[] method, byte[] ip)
        {
            var hash = new HMACSHA256(method);
            return hash.ComputeHash(ip);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string method = context.HttpContext.Request.Path.Value.ToString().Replace("/", "");
            byte[] Ipbytes = Encoding.ASCII.GetBytes(ip);
            byte[] Methodbytes = Encoding.ASCII.GetBytes(method);
            string str = Encoding.ASCII.GetString(HashHMAC(Methodbytes, Ipbytes));
            List<string> wl = new List<string>()
            {
                "getfilesx","getfilex","getapi","wfcr","getimage","wfnotify","notify", "updater","alert","conversat5ions" ,"updatedatabase", "test"
            };

            try
            {
                var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
                if (descriptor != null)
                    if (wl.Contains(descriptor.ActionName.ToString().ToLower()))
                        return;

                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8
                                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 2);
                        if (credentials.Length == 2)
                        {
                            if (IsAuthorized(context, credentials[0], credentials[1]))
                            {
                                return;
                            }
                        }
                    }
                }
                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(AuthorizationFilterContext context, string username, string password)
        {
            if (username.Trim() == "Powered-By" && password.Trim() == "Hasan Abu Ghalyoun")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }
    }
}
