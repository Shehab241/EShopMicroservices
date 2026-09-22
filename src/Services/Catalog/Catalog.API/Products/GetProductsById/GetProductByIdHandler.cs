using Catalog.API.Exceptions;
using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductsById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductsByIdResult>;
    public record GetProductsByIdResult(Product Product);

    internal class GetProductByIdQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByIdQuery, GetProductsByIdResult>
    {
        public async Task<GetProductsByIdResult> Handle(GetProductByIdQuery Query, CancellationToken cancellationToken)
        {
            var product= await session.LoadAsync<Product>(Query.Id,cancellationToken);
            if (product is null) {
                throw new ProductNotFoundExeption(Query.Id);


            }
            return new GetProductsByIdResult(product);
        }
        
    }
}
