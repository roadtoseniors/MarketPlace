using System;
using System.Collections.Generic;

namespace MarketPlace.Entities.Dtos;

public class OrderDto
{
    public int Id { get; init; }
    public DateTime CreateDateTime {get; init;}
    
    public int UserId {get; init;}
    public string UserLogin { get; init; } = "";
    
    public int StatusId {get; init;}
    public string StatusName { get; init; } = "";
    
    public int DeliveryTypeId {get; init;}
    public string DeliveryTypeName { get; init; } = "";
    public string? Address  {get; init;}
    public int? PointID {get; init;}
    public string? PointName {get; init;}
    public string? PointAddress {get; init;}
    
    public decimal TotalPrice {get; init;}
    public List<OrderItemDto> Items {get; init;}
}