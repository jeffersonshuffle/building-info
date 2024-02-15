namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public class Organization
{
    public Guid Guid { get; init; }
    public string FullName { get; init; }
    public string ShortName { get; init; }
    public string OrgAddress { get; init; }
    public string Phone { get; init; }
    public string Url { get; init; }
}
