using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace Surfbreak
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GetDateMiddleware
    {
        private readonly RequestDelegate _next;

        public GetDateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var getDate =  DateTime.Now.ToString("dd-MM-yyyy");
            await httpContext.Response.WriteAsync(getDate);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGetDateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GetDateMiddleware>();
        }
    }
}
