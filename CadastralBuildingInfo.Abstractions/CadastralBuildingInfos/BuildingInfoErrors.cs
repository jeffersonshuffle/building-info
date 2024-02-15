namespace CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;

public static class BuildingInfoErrors
{
    public static readonly ErrorDetails WrongCadastralNumber = new ErrorDetails(Code: "ArgumentException.Error", "Invalid cadastral number");
    public static readonly ErrorDetails NotFound = new ErrorDetails(Code: "NotFound.Error", "Building not found");
}
