
namespace Catalog.API.Products.GetProducts
{
    public record GetProductQuery(int? PageNumber = 10, int? PageSize = 10) : IQuery<GetProductsResult>;
   public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session) :
        IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery Query, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>()
                .ToPagedListAsync(Query.PageNumber??1,Query.PageSize??10,cancellationToken);

            return new GetProductsResult(product);
        }
    }
}
