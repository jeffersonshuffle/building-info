namespace CadastralBuildingInfo.Abstractions;

public record ErrorDetails(string Code, string? Description = default) 
{
    public static readonly ErrorDetails None = new(string.Empty);
}
