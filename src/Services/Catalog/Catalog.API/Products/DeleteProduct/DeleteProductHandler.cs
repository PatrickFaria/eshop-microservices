namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Product ID is required");
    }
}

public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
