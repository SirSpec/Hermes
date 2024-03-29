using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Frameworks.Functional.Results;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Services;

public class CatalogService : ICatalogService
{
    private readonly CatalogApiOptions catalogApiOptions;
    private readonly IHttpClientFactory httpClientFactory;

    public CatalogService(
        IOptions<CatalogApiOptions> catalogApiOptions,
        IHttpClientFactory httpClientFactory)
    {
        this.catalogApiOptions = catalogApiOptions.Value;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IResult<PageResponse<ItemGetResponse>>> GetPageAsync(int pageIndex)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClients.CatalogApi);
        var response = await httpClient.GetAsync(GetUri(pageIndex));

        return
            response.IsSuccessStatusCode &&
            await response.Content.ReadFromJsonAsync<PageResponse<ItemGetResponse>>() is PageResponse<ItemGetResponse> page
                ? page.ToSuccess()
                : Result.Failure<PageResponse<ItemGetResponse>>(
                    ErrorCodes.Catalog.GetPageFailed,
                    (nameof(response.StatusCode), response.StatusCode));
    }

    private Uri GetUri(int pageIndex)
    {
        var queryString = GetQueryString(pageIndex);
        var uri = catalogApiOptions.ItemsEndpointPath + queryString;

        return new Uri(uri, UriKind.Relative);
    }

    private static QueryString GetQueryString(int pageIndex)
    {
        var queryString = new QueryBuilder
        {
            { "index", pageIndex.ToString() },
            { "size", "12" },
            { "sorting", "name" }
        };

        return queryString.ToQueryString();
    }
}