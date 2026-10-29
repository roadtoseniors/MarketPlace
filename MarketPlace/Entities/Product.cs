using System;
using System.Collections.Generic;

namespace MarketPlace.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public string? Photo { get; set; }

    public int? CountInPack { get; set; }

    public int Count { get; set; }

    public bool IsAvailable { get; set; }

    public virtual ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
