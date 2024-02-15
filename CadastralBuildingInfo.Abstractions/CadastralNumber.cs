using System.Text.RegularExpressions;

namespace CadastralBuildingInfo.Abstractions;

public sealed class CadastralNumber
{
    public static CadastralNumber From(string cadastralStr)
    {
        if (!Validate(cadastralStr)) throw new ArgumentException();

        return new(cadastralStr);
    }

    private static Regex Pattern = new(@"\d{2}:\d{2}:\d{6,7}:\d{3,4}");

    public static bool Validate(string cadastralStr)
        => !string.IsNullOrEmpty(cadastralStr) && Pattern.IsMatch(cadastralStr);
    
    public string Value {get; private set; }
    public string GetRegionSection() => Value.Substring(0,2);

    private CadastralNumber(string cadastralStr) => Value = cadastralStr;
}
