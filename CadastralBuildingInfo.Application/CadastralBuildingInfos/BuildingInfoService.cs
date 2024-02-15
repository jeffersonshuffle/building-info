using CadastralBuildingInfo.Abstractions;
using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using CadastralBuildingInfo.Abstractions.Messaging;

namespace CadastralBuildingInfo.Application.CadastralBuildingInfos;

internal class BuildingInfoService : IQueryHandler<GetBuildingInfo, BuildingInfo>
{
    private readonly IBuildingInfoProvider _infoProvider;

    public BuildingInfoService(IBuildingInfoProvider infoProvider)
    {
        _infoProvider = infoProvider;
    }

    public async Task<Result<BuildingInfo>> Handle(GetBuildingInfo request, CancellationToken cancellationToken = default)
    {
        if (request is null || !CadastralNumber.Validate(request.CadastralNumber))
        {
            return Result<BuildingInfo>.Failure(BuildingInfoErrors.WrongCadastralNumber);
        }

        var result = await _infoProvider.GetInfoAsync(CadastralNumber.From(request.CadastralNumber), cancellationToken);
      
        return result is not null ? Result<BuildingInfo>.Succes(result) 
            : Result<BuildingInfo>.Failure(BuildingInfoErrors.NotFound);
    }
}
