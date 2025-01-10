using Business.Interface;
using Business.Services;
using MauiApp1.Pages;
using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiApp1
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

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<AddPage>();

            builder.Services.AddTransient<ListPage>();


            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IContactService, ContactService>();


    		builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
