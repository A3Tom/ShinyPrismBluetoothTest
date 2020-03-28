using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Shiny.Prism;

namespace ShinyPrismBLE_Trial
{
    public class ShinyAppStartup : PrismStartup
    {
        public ShinyAppStartup() : base(PrismContainerExtension.Current)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            //services.UseGps<LocationDelegate>();
        }
    }
}
