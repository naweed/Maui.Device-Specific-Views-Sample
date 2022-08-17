namespace DeviceSpecificSample;

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
			})
            .UseViewServices();

#if ANDROID || IOS
        builder.Services.AddSingleton<IStartPage, MobileStartPage>();
        builder.Services.AddTransient<ISecondPage, MobileSecondPage>();
#else
        builder.Services.AddSingleton<IStartPage, DesktopStartPage>();
        builder.Services.AddTransient<ISecondPage, DesktopSecondPage>();
#endif

        return builder.Build();
	}
}

