using MAUI_App.Services;
using MAUI_App.Views.Pages;
using MAUI_Core.Models;
using MAUI_Core.Repositories;
using MAUI_Core.Services;
using MAUI_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MAUI_App
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
            builder.Services.AddSingleton<INavigationService<Template>,NavigationService<Template>>();
            builder.Services.AddSingleton<DatabaseRepository<Template>>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");
                options.UseSqlite($"Filename={dbPath}");
            });

            builder.Services.AddScoped(typeof(IDatabaseRepository<>), typeof(DatabaseRepository<>));
            builder.Services.AddScoped<IDatabaseService<Template>, DatabaseService<Template>>();
            var serviceProvider = builder.Services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreatedAsync();
        }

        private static void RegisterPages()
        {
            builder.Services.AddTransient<TemplateListPage>();
        }

        private static void RegisterViewModels()
        {
            builder.Services.AddTransient<TemplateListViewModel>();
            builder.Services.AddTransient<TemplateDetailsViewModel>();
        }
    }
}
