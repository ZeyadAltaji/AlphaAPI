using AlphaAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlphaAPI.BasicAuth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(string realm = @"Do you have permission to enter?") : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IntegrationAuthAttribute : TypeFilterAttribute
    {
        public IntegrationAuthAttribute(string realm = @"Do you have permission to enter?") : base(typeof(IntegrationAuth))
        {
            Arguments = new object[] { realm };
        }
    }
    public class VoltAuth : TypeFilterAttribute
    {
        public VoltAuth(string realm = @"Do you have permission to enter?") : base(typeof(VoltBasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }

}
