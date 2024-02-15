using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using Gosuslugi.WebApi.Client;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddFiasClients(this IServiceCollection services)
    {
        services.AddOptions<FiasWebApiSettings>().BindConfiguration(FiasWebApiSettings.Section);
        services.AddOptions<BuildingInfoWebApiSettings>().BindConfiguration(BuildingInfoWebApiSettings.Section);

        services.AddHttpClient<FiasAddressProvider>((serviceProvider, httpClient) => 
        {
            var settings = serviceProvider.GetRequiredService<IOptions<FiasWebApiSettings>>().Value;

            httpClient.BaseAddress = new(settings.BaseAddress);            
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler 
            {
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
            };
        });
        services.AddHttpClient<BuildingInfoProvider>((serviceProvider, httpClient) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<BuildingInfoWebApiSettings>>().Value;

            httpClient.BaseAddress = new(settings.BaseAddress);

            foreach (var p in typeof(BuildingInfoWebApiSettings)
                    .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .Where(prop => prop.IsDefined(typeof(HeaderNameAttribute), false))) 
            {
                var attr = p.GetCustomAttribute(typeof(HeaderNameAttribute)) as HeaderNameAttribute;
                if (attr is null) continue;

                httpClient.DefaultRequestHeaders.Add(attr.Name, p.GetValue(settings).ToString());
            };
            httpClient.DefaultRequestHeaders.Add("Cookie", "route_rest=08458811535f29823d9f1f6a49c808aa");
            
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
            };
        });
        services.AddTransient<IRegionCodeProvider, FiasAddressProvider>(
            serviceProvider => serviceProvider.GetRequiredService<FiasAddressProvider>());
        services.AddTransient<IBuildingInfoProvider, BuildingInfoProvider>(
            serviceProvider => serviceProvider.GetRequiredService<BuildingInfoProvider>());

        return services;
    }
}
