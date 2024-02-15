using AutoMapper;
using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using CadastralBuildingInfo.WebApi.Contracts.CadastralBuildingInfos;

namespace CadastralBuildingInfo.Presentation.CadastralBuildingInfos;

internal class BuildingInfoProfile: Profile
{
    public BuildingInfoProfile()
    {
        CreateMap<BuildingInfo, BuildingInfoModel>();
        CreateMap<Organization, OrganizationModel>();
    }
}
