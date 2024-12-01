using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

internal class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdHandler.Handler called with {Query}", request);

        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        return product is null ? throw new ProductNotFoundException() : new GetProductByIdResult(product);
    }
}
