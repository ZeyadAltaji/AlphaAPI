using Microsoft.AspNetCore.Mvc;
using System;

namespace AlphaAPI.DynamicAuth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DynamicAuthAttribute : TypeFilterAttribute
    {
        public DynamicAuthAttribute(string realm = @"Do you have permission to enter?") : base(typeof(DynamicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}

