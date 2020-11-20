using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace NbSites.Web.Demo.Configs
{
    public static class FooOptionsExtensions
    {
        public static void AddFooOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //using the options pattern: bind the options section and add it to the dependency injection service container.
            services.Configure<FooOptions>(configuration.GetSection(FooOptions.SectionName));

            //this allowed inject the options instance to app code directly
            services.AddTransient(sp => sp.GetService<IOptionsSnapshot<FooOptions>>().Value); //ok => use "IOptionsSnapshot<>" instead of "IOptions<>" will auto load after changed
        }
    }
}