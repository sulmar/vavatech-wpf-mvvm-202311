using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public abstract class Item : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Product : Item
{
    public float Weight { get; set; }
    public string Color { get; set; }
}

public class Service : Item
{
    public TimeSpan Duration { get; set; }
}

