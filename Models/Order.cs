using System;
using System.Collections.Generic;

namespace NewCompicStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public string NameClient { get; set; } = null!;

    public string SurnameClient { get; set; } = null!;

    public decimal FinalPrice { get; set; }

    public string? Description { get; set; }

    public DateTime DataOrder { get; set; }

    public decimal PhoneNumber { get; set; }

    public string Status { get; set; } = null!;
}
