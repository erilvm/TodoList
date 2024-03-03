using Microsoft.Extensions.Logging;

using TodoList.Pages;
using TodoList.Services;
using TodoList.ViewModel;

namespace TodoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            //Inyeccion de dependencias
           
            builder.Services.AddSingleton<IDataService,FakeTaskService>();

            //Base de datos
            builder.Services.AddSingleton<IDataService, FirebaseDataService>();

            builder.Services.AddTransient<RegistroTareaPage>();
            builder.Services.AddTransient<RegistroTareaViewModel>();
            builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<TodoViewModel>();

            builder.Services.AddTransient<RegistroEncuestaPage>();
            builder.Services.AddTransient<RegistroEncuestaViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
