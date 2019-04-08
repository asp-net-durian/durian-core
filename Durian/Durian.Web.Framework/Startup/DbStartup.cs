using Durian.Core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Durian.Web.Framework.Startup
{
    /// <summary>
    /// Represents object for the configuring DB context on application startup
    /// </summary>
    public class NopDbStartup : IDurianStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add object context
            services.AddDurianObjectContext();

            //add EF services
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {            
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            get { return 10; }
        }
    }
}