namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));
        services.AddAutoMapper(typeof(DependencyInjectionExtensions).Assembly);
        return services;
    }
}
