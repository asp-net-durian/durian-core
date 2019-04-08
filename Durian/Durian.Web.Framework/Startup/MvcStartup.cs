using Durian.Core.Common;
using Durian.Web.Framework.Startup.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Durian.Web.Framework.Startup
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class DurianMvcStartup : IDurianStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add MiniProfiler services
            services.AddNopMiniProfiler();

            //add and configure MVC feature
            services.AddNopMvc();

            //add custom redirect result executor
            services.AddNopRedirectResultExecutor();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //add MiniProfiler
            //@todo
            //application.UseMiniProfiler();

            //MVC routing
            application.UseNopMvc();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //MVC should be loaded last
            get { return 1000; }
        }
    }
}