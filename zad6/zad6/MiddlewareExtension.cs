using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad6
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder )
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
