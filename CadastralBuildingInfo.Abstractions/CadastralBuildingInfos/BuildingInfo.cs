namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public class BuildingInfo
{
    public string? FormattedAddress { get; init; }
    public string RegionCode { get; init; }
    public Organization? Municipality { get; init; }
    public Organization? Management { get; init; }
    public string RawJsonBase64 { get; init; }
}