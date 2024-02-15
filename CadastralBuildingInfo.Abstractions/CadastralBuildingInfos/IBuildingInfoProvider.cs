namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public interface IBuildingInfoProvider
{
    Task<BuildingInfo?> GetInfoAsync(CadastralNumber cadastralNumber, CancellationToken cancellationToken = default);
}