using System;
using System.Collections.Generic;

namespace MarketPlace.Entities;

public partial class DeliveryType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
