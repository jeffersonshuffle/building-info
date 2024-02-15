namespace Gosuslugi.WebApiContracts.BuildingInfos;

public class BuildingRequest
{
    public static BuildingRequest From(Guid regionID, string cadastralNumber) =>
        new BuildingRequest
        {
            RegionCode = regionID.ToString(),
            CadastreNumber = cadastralNumber,
            Statuses = new List<string> { "APPROVED"  },
            CalcCount = true
        };   
    public string RegionCode { get; set; }
    public object FiasHouseCodeList { get; set; }
    public object EstStatus { get; set; }
    public object StrStatus { get; set; }
    public bool? CalcCount { get; set; }
    public object HouseConditionRefList { get; set; }
    public object HouseTypeRefList { get; set; }
    public object HouseManagementTypeRefList { get; set; }
    public string CadastreNumber { get; set; }
    public object Oktmo { get; set; }
    public List<string> Statuses { get; set; }
    public object RegionProperty { get; set; }
    public object MunicipalProperty { get; set; }
    public object HostelTypeCodes { get; set; }
}
