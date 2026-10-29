namespace MarketPlace.Entities.Dtos;

public class CreateOrderDto
{
    public int DeliveryTypeId {get; init;}
    public string? Address {get; init;}
    public int? PointID {get; init;}
    
    public int? ProductId {get; init;}
    public int Count { get; init; } = 1;
}