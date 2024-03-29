using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests.Brands;
using Hermes.Catalog.API.Responses;

namespace Hermes.Catalog.API.Mappings;

public static class BrandMappings
{
    public static BrandGetResponse ToBrandGetResponse(this Brand brand) =>
        new()
        {
            Id = brand.Id,
            Name = brand.Name
        };

    public static Brand ToBrandEntity(this BrandPostRequest request) =>
        new()
        {
            Name = request.Name
        };

    public static BrandPatchRequest ToBrandPatchRequest(this Brand brand) =>
        new()
        {
            Name = brand.Name
        };

    public static void Patch(this Brand brand, BrandPatchRequest patch)
    {
        brand.Name = patch.Name;
    }
}