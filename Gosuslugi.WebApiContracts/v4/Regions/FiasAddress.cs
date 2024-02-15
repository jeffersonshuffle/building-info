namespace Gosuslugi.WebApiContracts.v4.Regions;

public class FiasAddress
{
    public string ClassType { get; init; }
    public Guid Guid { get; init; }
    public bool? Actual { get; init; }
    public string Code { get; init; }
    public Guid? RootEntityGuid { get; init; }
    public DateTime? LastUpdateDate { get; init; }
    public DateTime? CreateDate { get; init; }
    public Guid? AoGuid { get; init; }
    public int? AoLevel { get; init; }
    public string PostalCode { get; init; }
    public string FormalName { get; init; }
    public string OffName { get; init; }
    public string ShortName { get; init; }
    public Guid? ParentGuid { get; init; }
    public object? Oktmo { get; init; }
    public string RegionCode { get; init; }
    public string AutoCode { get; init; }
    public string AreaCode { get; init; }
    public string CityCode { get; init; }
    public string CtarCode { get; init; }
    public string PlaceCode { get; init; }
    public string PlanCode { get; init; }
    public string StreetCode { get; init; }
    public string ExtrCode { get; init; }
    public string SextCode { get; init; }
    public DateTime? UpdateDate { get; init; }
    public bool? IsAddedManually { get; init; }
    public bool? OnApproval { get; init; }
    public Guid? FiasAddrobjGuid { get; init; }
    public bool? SubjectCity { get; init; }
}

