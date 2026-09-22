




namespace Basket.API.Basket.GetBasket
{
    //public record GetBasketRequest(string UserName);
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(username));
                var respones = result.Adapt<GetBasketResponse>();
                return Results.Ok(respones);
            }).WithName("GetProductById")
              .Produces<GetBasketResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Id")
              .WithDescription("Get Product By Id");
        }
    }
}
