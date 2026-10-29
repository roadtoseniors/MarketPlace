using System;
using System.Collections.Generic;

namespace MarketPlace.Entities;

public partial class ProductRating
{
    public int? ProductId { get; set; }

    public decimal? AvgRating { get; set; }

    public long? ReviewsCount { get; set; }
}
