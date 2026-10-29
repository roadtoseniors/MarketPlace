using System;

namespace MarketPlace.Entities.Dtos;

public class OrderShortDto
{
    public int Id {get; init;}
    public DateTime CreatedAt {get; init;}
    public string StatusName {get; init;}
    public decimal TotalPrice {get; init;}
    public int ItemsCount {get; init;}
}