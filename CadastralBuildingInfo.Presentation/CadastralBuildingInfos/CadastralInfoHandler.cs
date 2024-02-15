using AutoMapper;
using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using CadastralBuildingInfo.WebApi.Contracts.CadastralBuildingInfos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;

namespace CadastralBuildingInfo.Presentation.CadastralBuildingInfos;

public class CadastralInfoHandler: IEndpointRouteHandler
{ 
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/building-info/{cadastralNumber}", async (
            [FromRoute]string cadastralNumber,
            ISender sender,
            IMapper mapper,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetBuildingInfo(cadastralNumber), cancellationToken);

            return result.IsSucces ? Results.Ok(mapper.Map<BuildingInfoModel>(result.Value)) : Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Bad Request",
                type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                extensions: new Dictionary<string, object?>
                {
                    { "errors", new[]{ result.Error} }
                });
        })
        .Produces(statusCode: StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .RequireRateLimiting("fixed")
        .CacheOutput();
    }
}
