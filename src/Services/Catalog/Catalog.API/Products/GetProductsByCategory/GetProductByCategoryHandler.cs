using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductsByCategoryResult>
    {

        public async Task<GetProductsByCategoryResult> Handle(GetProductByCategoryQuery query , CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>()
                .Where(p=>p.Category.Contains(query.Category))
                .ToListAsync(cancellationToken);

            return new GetProductsByCategoryResult(product);
        }
    }
}

