namespace Gosuslugi.WebApi.Client;

public class HeaderNameAttribute: Attribute
{
    public HeaderNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

public class BuildingInfoWebApiSettings
{
    public const string Section = "BuildingInfoWebApiSettings";

    public string BaseAddress { get; init; }
    [HeaderName("Accept")]
    public string Accept { get; init; }       
    /// <summary>
    ///   Host
    /// </summary>
    [HeaderName("Host")]
    public string Host { get; init; }
    /// <summary>
    ///   Origin
    /// </summary>
    [HeaderName("Origin")]
    public string Origin { get; init; }
    /// <summary>
    ///    Referer
    /// </summary>
    [HeaderName("Referer")]
    public string Referer { get; init; }
    /// <summary>
    ///   Request-GUID
    /// </summary>
    [HeaderName("Request-GUID")]
    public string RequestGUID { get; init; }
    /// <summary>
    ///    Sec-Fetch-Dest
    /// </summary>
    [HeaderName("Sec-Fetch-Dest")]
    public string SecFetchDest { get; init; }
    /// <summary>
    ///    Sec-Fetch-Mode
    /// </summary>
    [HeaderName("Sec-Fetch-Mode")]
    public string SecFetchMode { get; init; }
    /// <summary>
    ///    Sec-Fetch-Site
    /// </summary>
    [HeaderName("Sec-Fetch-Site")]
    public string SecFetchSite { get; init; }
    /// <summary>
    ///   Session-GUID
    /// </summary>
    [HeaderName("Session-GUID")]
    public string SessionGUID { get; init; }
    /// <summary>
    ///    State-GUID
    /// </summary>
    [HeaderName("State-GUID")]
    public string StateGUID { get; init; }

}
