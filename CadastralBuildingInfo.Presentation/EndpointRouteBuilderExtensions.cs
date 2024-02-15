using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace CadastralBuildingInfo.Presentation;

public static class EndpointRouteBuilderExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {        
        var endpointRouteHandlerInterfaceType = typeof(IEndpointRouteHandler);
        var assembly = Assembly.GetAssembly(endpointRouteHandlerInterfaceType);
        var endpointRouteHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType
                    && t.GetConstructor(Type.EmptyTypes) != null
                    && endpointRouteHandlerInterfaceType.IsAssignableFrom(t));
        foreach (var endpointRouteHandlerType in endpointRouteHandlerTypes)
        {
            var instantiatedType = (IEndpointRouteHandler)Activator.CreateInstance(endpointRouteHandlerType)!;
            instantiatedType.MapEndpoints(app);
        }
    }
}
