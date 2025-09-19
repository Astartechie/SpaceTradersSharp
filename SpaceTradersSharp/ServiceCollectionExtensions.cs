using MediateSharp;
using Microsoft.Extensions.DependencyInjection;

namespace SpaceTradersSharp;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpaceTraders(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();

        serviceCollection.AddMediateSharp(typeof(ServiceCollectionExtensions).Assembly);

        serviceCollection.AddTransient<IClient, Client>();

        return serviceCollection;
    }
}