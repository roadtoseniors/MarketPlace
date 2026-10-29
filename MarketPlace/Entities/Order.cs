using System;
using System.Collections.Generic;

namespace MarketPlace.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateTime { get; set; }

    public decimal TotalPrice { get; set; }

    public int DeliveryTypeId { get; set; }

    public string? Address { get; set; }

    public int? PointId { get; set; }

    public int StatusId { get; set; }

    public virtual DeliveryType DeliveryType { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Point? Point { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
