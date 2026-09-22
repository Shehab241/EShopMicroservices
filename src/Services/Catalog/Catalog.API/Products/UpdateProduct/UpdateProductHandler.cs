using Catalog.API.Exceptions;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .Length(2,150).WithMessage("Name must be between 2 and 150 characters");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be GreaterThan 0");
        }
    }
    public class UpdateProductHandler(IDocumentSession session) :
        ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand query, CancellationToken cancellationToken)
        {
            var product= await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null) {
                throw new ProductNotFoundExeption(query.Id);
            }
            product.Name=query.Name;
            product.Category=query.Category;
            product.Description=query.Description;
            product.ImageFile=query.ImageFile;
            product.Price=query.Price;
            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
    }
}
