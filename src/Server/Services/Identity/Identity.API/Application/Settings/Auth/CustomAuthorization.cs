using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Application.Settings.Auth
{
    public class CustomAuthorization
    {
        public static bool ClainsUserisValidation(HttpContext httpContext, string clainName,
            string clainValue) => httpContext.User.Identity.IsAuthenticated && httpContext.User.Claims.Any(c => c.Type == clainName && c.Value.Split(",").Contains(clainValue));
    }
}
