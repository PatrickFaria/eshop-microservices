using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if(await session.Query<Product>().AnyAsync())
        {
            return;
        }

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() =>
        [
            new Product()
            {
                Id = Guid.Parse("a2945f3e-bc80-4009-94b6-63bf3e01e568"),
                Name = "IphoneX",
                Description = "Description1",
                ImageFile = "product-1.png",
                Price= 951,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = Guid.Parse("3d847489-5ac1-454e-bfc6-bc4591d90631"),
                Name = "IphoneX2",
                Description = "Description2",
                ImageFile = "product-2.png",
                Price= 952,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = Guid.Parse("07effd1a-bafb-4fed-adf7-8ca900ff974c"),
                Name = "IphoneX3",
                Description = "Description3",
                ImageFile = "product-3.png",
                Price= 953,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = Guid.Parse("d148c2a4-9e7d-4275-b74b-34225393a95d"),
                Name = "IphoneX4",
                Description = "Description4",
                ImageFile = "product-4.png",
                Price= 954,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = Guid.Parse("ce32953c-28f0-4aa5-be10-32eb12640ad1"),
                Name = "IphoneX5",
                Description = "Description5",
                ImageFile = "product-5.png",
                Price= 955,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = Guid.Parse("06f3db94-1128-46a8-a15d-88e70496a001"),
                Name = "IphoneX6",
                Description = "Description6",
                ImageFile = "product-6.png",
                Price= 956,
                Category = ["Smart Phone"]
            }
        ];
}
