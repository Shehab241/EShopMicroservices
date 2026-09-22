using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundExeption:NotFoundExceptions
{
    public ProductNotFoundExeption(Guid Id) : base("Product", Id)
    {
    }
}
