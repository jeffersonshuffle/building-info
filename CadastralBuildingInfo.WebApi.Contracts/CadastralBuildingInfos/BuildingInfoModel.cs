namespace CadastralBuildingInfo.WebApi.Contracts.CadastralBuildingInfos;

public class BuildingInfoModel
{
    public string? FormattedAddress { get; init; }
    public string RegionCode { get; init; }
    public OrganizationModel? Municipality { get; init; }
    public OrganizationModel? Management { get; init; }
    public string RawJsonBase64 { get; init; }
}