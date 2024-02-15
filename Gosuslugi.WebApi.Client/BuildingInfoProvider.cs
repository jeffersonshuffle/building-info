using CadastralBuildingInfo.Abstractions;
using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using Gosuslugi.WebApiContracts.BuildingInfos;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Unicode;
using System.Net;

namespace Gosuslugi.WebApi.Client;

internal sealed class BuildingInfoProvider : IBuildingInfoProvider
{
    private readonly HttpClient _httpClient;
    private readonly IRegionCodeProvider _regionCodeProvider;
    public BuildingInfoProvider(HttpClient httpClient, IRegionCodeProvider regionCodeProvider)
    {
        _httpClient = httpClient;
        _regionCodeProvider = regionCodeProvider;
    }

    public async Task<BuildingInfo?> GetInfoAsync(CadastralNumber cadastralNumber, CancellationToken cancellationToken = default)
    {
        var region = await _regionCodeProvider.GetRegionCodeAsync(cadastralNumber, cancellationToken);
        if (region is null) return default;

        var request = BuildingRequest.From(region.ID, cadastralNumber.Value);

        var resultStr = await GetInfoAsync(request, cancellationToken); 

        return BuildingInfoResponseBuilder.BuildFrom(resultStr, cadastralNumber.GetRegionSection());
    }

    private async Task<string> GetInfoAsync(BuildingRequest request, CancellationToken cancellationToken = default)
    {
        var opts = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        var content = new StringContent(JsonSerializer.Serialize(request, opts));
        content.Headers.Remove("Content-Type");
        content.Headers.Add("Content-Type", "application/json; charset=utf-8");
        var response = await _httpClient.PostAsync("?pageIndex=1&elementsPerPage=1", content, cancellationToken);

        if (!response.IsSuccessStatusCode) return string.Empty;

        return await response.Content.ReadAsStringAsync();
    }
}
