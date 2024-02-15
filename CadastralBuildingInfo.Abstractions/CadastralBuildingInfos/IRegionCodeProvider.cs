namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public interface IRegionCodeProvider
{
    Task<RegionCodeRecord?> GetRegionCodeAsync(CadastralNumber cadastralNumber, CancellationToken cancellationToken = default);
}