namespace MarketPlace.Entities.Dtos;

public class OrderItemDto
{
    public int ProductId {get; init;}
    public string ProductName { get; init; } = "";
    public string? Photo {get; init;}
    public int Count {get; init;}
    public decimal Price {get; init;}
    public decimal Sum => Price *  Count;
}