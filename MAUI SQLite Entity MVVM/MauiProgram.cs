using MAUI_SQLite_Entity_MVVM.Repositories;
using MAUI_SQLite_Entity_MVVM.Services;
using MAUI_SQLite_Entity_MVVM.ViewModels;
using MAUI_SQLite_Entity_MVVM.Views.Pages;
using Microsoft.Extensions.Logging;

namespace MAUI_SQLite_Entity_MVVM
{
    public static class MauiProgram
    {
        static MauiAppBuilder builder = MauiApp.CreateBuilder();
        public static MauiApp CreateMauiApp()
        {
            builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DatabaseRepository>();
            RegisterServices();
            RegisterViewModels();
            RegisterPages();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
        private static void RegisterServices()
        {
            builder.Services.AddSingleton<TemplateService>();
        }

        private static void RegisterPages()
        {
            builder.Services.AddTransient<TemplateListPage>();
        }

        private static void RegisterViewModels()
        {
            builder.Services.AddTransient<TemplateListViewModel>();
        }
    }
}
