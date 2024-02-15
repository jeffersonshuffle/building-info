using CadastralBuildingInfo.Abstractions.Messaging;

namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public sealed record GetBuildingInfo(string CadastralNumber): IQuery<BuildingInfo>
{
}
