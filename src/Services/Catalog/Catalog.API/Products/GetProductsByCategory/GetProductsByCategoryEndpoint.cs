using Catalog.API.Products.GetProductsById;

namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryRequest();
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{Category}", async ( string Category,ISender sender)=>{
                var result= await sender.Send(new GetProductByCategoryQuery(Category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);

            }).WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
        }
    }
}
