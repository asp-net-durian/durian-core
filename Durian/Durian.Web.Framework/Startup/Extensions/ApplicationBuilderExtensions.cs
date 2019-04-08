using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;

namespace Durian.Web.Framework.Startup.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds a special handler that checks for responses with the 404 status code that do not have a body
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UsePageNotFound(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(async context =>
            {
                //handle 404 Not Found
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    //get original path and query
                    var originalPath = context.HttpContext.Request.Path;
                    var originalQueryString = context.HttpContext.Request.QueryString;

                    //get new path
                    context.HttpContext.Request.Path = "/page-not-found";
                    context.HttpContext.Request.QueryString = QueryString.Empty;

                    try
                    {
                        //re-execute request with new path
                        await context.Next(context.HttpContext);
                    }
                    finally
                    {
                        //return original path to request
                        context.HttpContext.Request.QueryString = originalQueryString;
                        context.HttpContext.Request.Path = originalPath;
                        context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(null);
                    }
                }
            });
        }

    }
}