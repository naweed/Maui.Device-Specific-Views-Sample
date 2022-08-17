namespace DeviceSpecificSample.Services;

public static class ViewServices
{
    private static IServiceCollection Services;

    public static MauiAppBuilder UseViewServices(this MauiAppBuilder builder)
    {
        Services = builder.Services;
        return builder;
    }

    public static ContentPage ResolvePage<TService>(params object[] inputParameters)
    {
        var implementationType = Services
                                .Where(service => service.ServiceType == typeof(TService) && service.ImplementationType != null)
                                .Select(service => service.ImplementationType)
                                .First();

        return (Activator.CreateInstance(implementationType, inputParameters)) as ContentPage;
    }
}

