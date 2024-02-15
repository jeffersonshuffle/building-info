namespace Gosuslugi.WebApi.Client;

public class FiasWebApiSettings
{
    public const string Section = "FiasWebApiSettings";

    public string BaseAddress { get; init; } 
    public string ContentType { get; init; }
}
