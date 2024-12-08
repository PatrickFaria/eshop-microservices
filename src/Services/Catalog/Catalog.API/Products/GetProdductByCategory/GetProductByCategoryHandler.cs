namespace Catalog.API.Products.GetProdductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Product);

internal class GetProductByCategoryHandler(IDocumentSession session) : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var product = await session.Query<Product>().Where(p => p.Category.Contains(request.Category)).ToListAsync();

        return product is null ? throw new ProductNotFoundException() : new GetProductByCategoryResult(product);
    }
}
