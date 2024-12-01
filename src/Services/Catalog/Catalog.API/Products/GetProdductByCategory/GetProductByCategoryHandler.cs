using Catalog.API.Models;

namespace Catalog.API.Products.GetProdductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Product);

internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdHandler.Handler called with {Query}", request);

        var product = await session.Query<Product>().Where(p => p.Category.Contains(request.Category)).ToListAsync();

        return product is null ? throw new ProductNotFoundException() : new GetProductByCategoryResult(product);
    }
}
