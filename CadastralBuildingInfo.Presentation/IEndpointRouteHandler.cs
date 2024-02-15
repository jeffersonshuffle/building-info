using Microsoft.AspNetCore.Routing;

namespace CadastralBuildingInfo.Presentation;

public interface IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app);
}