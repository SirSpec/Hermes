namespace Hermes.Client.Web.Options;

public class CatalogApiOptions
{
    public required string BaseAddress { get; init; }
    public required string ItemsEndpointPath { get; init; }
}