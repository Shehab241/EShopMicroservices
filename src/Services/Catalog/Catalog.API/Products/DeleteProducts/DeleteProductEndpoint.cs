using Catalog.API.Exceptions;
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProducts
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }
    public class DeleteProductCommandEndpoint(IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {

        public async Task<DeleteProductResult> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
        {

            /*session.Delete<Product>(query.Id);
            session.SaveChangesAsync(cancellationToken);*/
            var product= await session.LoadAsync<Product>(query.Id,cancellationToken);
            if (product is null) { 
                throw new ProductNotFoundExeption(query.Id);
            }
            session.Delete(product);
            session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
