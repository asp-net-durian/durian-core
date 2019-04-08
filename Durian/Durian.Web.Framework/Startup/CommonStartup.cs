using Durian.Core.Common;
using Durian.Web.Framework.Startup.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Durian.Web.Framework.Startup
{
    /// <summary>
    /// Represents object for the configuring common features and middleware on application startup
    /// </summary>
    public class NopCommonStartup : IDurianStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //compression
            //@todo
            //services.AddResponseCompression();

            //add options feature
            services.AddOptions();

            //add memory cache
            services.AddMemoryCache();

            //add distributed memory cache
            services.AddDistributedMemoryCache();

            //add HTTP sesion state feature
            services.AddHttpSession();

            //add anti-forgery
            services.AddAntiForgery();

            //add theme support
            services.AddThemes();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //use static files feature
            application.UseStaticFiles();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //common services should be loaded after error handlers
            get { return 100; }
        }
    }
}