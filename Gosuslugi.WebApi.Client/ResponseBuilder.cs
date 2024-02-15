using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using System.Text.Json;

namespace Gosuslugi.WebApi.Client;

internal static class BuildingInfoResponseBuilder
{
    public static BuildingInfo? BuildFrom(string jsonStr, string regionCode)
    {
        if (string.IsNullOrEmpty(jsonStr)) return default;

        using JsonDocument document = JsonDocument.Parse(jsonStr);
        var items = document.RootElement.GetProperty("items");

        var element = items.EnumerateArray().First();
        var opt = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        var managementOrganizationStr = element.GetProperty("managementOrganization").GetRawText();
        var managementOrganization = JsonSerializer.Deserialize(managementOrganizationStr, typeof(Organization), opt);
        var municipalityOrganizationStr = element.GetProperty("municipalityOrganization").GetRawText();
        var municipalityOrganization = JsonSerializer.Deserialize(municipalityOrganizationStr, typeof(Organization), opt);
        var formattedAddress = element.GetProperty("address").GetProperty("formattedAddress").GetString();
        return new BuildingInfo
        {
            FormattedAddress = formattedAddress,
            RegionCode = regionCode,
            Management = managementOrganization as Organization,
            Municipality = municipalityOrganization as Organization,
            RawJsonBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(document.RootElement.GetRawText()))
        };
    }
}
