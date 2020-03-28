using Prism.DryIoc;
using Prism.Ioc;

namespace ShinyPrismBLE_Trial
{
    public partial class App : PrismApplication
    {
        protected override IContainerExtension CreateContainerExtension() => PrismContainerExtension.Current;

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register your services like normal
            containerRegistry.RegisterForNavigation<Views.MainPage>();
        }
    }
}
