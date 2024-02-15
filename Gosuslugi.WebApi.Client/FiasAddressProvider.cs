using CadastralBuildingInfo.Abstractions;
using CadastralBuildingInfo.Abstractions.CadastralBuildingInfos;
using Gosuslugi.WebApiContracts.v4.Regions;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace Gosuslugi.WebApi.Client;

internal sealed class FiasAddressProvider : IRegionCodeProvider
{
    private const string FiasRegions = "FiasRegions";
    private const int CacheTTLMinutes = 42;
    private readonly IMemoryCache _cache;
    private readonly HttpClient _httpClient;
    public FiasAddressProvider(IMemoryCache cache, HttpClient httpClient)
    {
        _cache = cache;
        _httpClient = httpClient;
    }

    public async Task<RegionCodeRecord?> GetRegionCodeAsync(CadastralNumber cadastralNumber, CancellationToken cancellationToken = default)
    {
        var regionNumber = cadastralNumber.GetRegionSection();
        if (TryReadFromCache(regionNumber, out var region) && region is not null) return region;

        return FindFrom(await ReadFromSourceAsync(cancellationToken), x => x.RegionCode == regionNumber);
    }

    private async Task<FiasAddress[]> ReadFromSourceAsync(CancellationToken cancellationToken = default)
    {
        var addresses = await _httpClient.GetFromJsonAsync<FiasAddress[]>("regions", cancellationToken);
        if (addresses is null || addresses.Length == 0) return Array.Empty<FiasAddress>();
        return _cache.Set(FiasRegions, addresses, TimeSpan.FromMinutes(CacheTTLMinutes));
    }

    private bool TryReadFromCache(string regionNumber, out RegionCodeRecord? region)
    {
        region = default;
        if (!_cache.TryGetValue<FiasAddress[]>(FiasRegions, out var addresses)) return false;
        if (addresses is null || addresses.Length == 0) return false;
        region = FindFrom(addresses, x => x.RegionCode == regionNumber);
        return region != default;
    }

    private RegionCodeRecord? FindFrom(FiasAddress[] addresses, Func<FiasAddress, bool> predicate)
            => addresses
                .Where(predicate)
                .Select(x => new RegionCodeRecord(x.RegionCode, x.FormalName, x.AoGuid.Value))
                .FirstOrDefault();
}
