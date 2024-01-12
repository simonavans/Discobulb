using Discobulb.Services.AppNavigation;
using Discobulb.Services.Hue;
using Discobulb.View;
using Discobulb.ViewModel;
using Microsoft.Extensions.Logging;

namespace Discobulb
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IHueService>(new HueServiceImpl());
            builder.Services.AddSingleton<LightsPageViewModel>();
            builder.Services.AddSingleton<LightsPage>();
            builder.Services.AddSingleton<IAppNavigationService, AppNavigationService>();

            return builder.Build();
        }
    }
}
