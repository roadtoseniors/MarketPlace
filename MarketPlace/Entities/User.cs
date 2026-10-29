using System;
using System.Collections.Generic;

namespace MarketPlace.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role Role { get; set; } = null!;
}
