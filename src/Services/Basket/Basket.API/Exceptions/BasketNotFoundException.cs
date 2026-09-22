namespace Basket.API.Exceptions;

using BuildingBlocks.Exceptions;

public class BasketNotFoundException : NotFoundExceptions
{
    public BasketNotFoundException(string userName) : base("Basket", userName)
    {
        
    }
}
