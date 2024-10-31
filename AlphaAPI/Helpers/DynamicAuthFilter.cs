using AlphaAPI.Controllers;
using AlphaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace AlphaAPI.DynamicAuth
{
    public class DynamicAuthFilter : IAuthorizationFilter
    {
        private IMemoryCache cache;
        private readonly string _realm;
        public DynamicAuthFilter(string realm, IMemoryCache memoryCache)
        {
            cache = memoryCache;
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

            try
            {
                var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
                if (descriptor != null)
                {
                    if (descriptor.ActionName == "wfcr")
                    {

                        return;
                    }
                }
                string Key = context.HttpContext.Request.Headers["Key"];
                string Hash = context.HttpContext.Request.Headers["Hash"];
                if (Key != null && Hash != null)
                {
                    if (IsAuthorized(Key, Hash, ip))
                        return;
                }
                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(string Key, string Hash, string ip)
        {
            if (IPs.Where(x => x.UserID == Key && x.connection == ip).Count() > 0)
            {
                cache.Remove(ip);
                cache.Set(ip, "IPs-" + Key);
                return false;
            }
            else
            {
                cache.Set(ip, "IPs-" + Key);
            }
            try
            {
                AESCryp.Key = Key;
                var Decrypted = AESCryp.Decrypt(Hash);
                if (Decrypted == "coolAPI")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {

                return false;
            }

        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }

        private List<SignalRUser> IPs
        {
            get
            {
                var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(cache) as dynamic;
                List<SignalRUser> x = new List<SignalRUser>();
                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    x.Add(
                        new SignalRUser()
                        {
                            Type = cacheItemValue.Value.ToString().Split('-')[0],
                            UserID = cacheItemValue.Value.ToString().Split('-')[1],
                            connection = cacheItemValue.Key.ToString(),
                        });
                }
                return x.Where(c => c.Type == "IPs").ToList();
            }
        }


    }

}
