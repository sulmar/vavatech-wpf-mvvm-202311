using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public abstract partial class Item : BaseEntity
{
    public string Name { get; set; }
    public string ShortName => $"{Name.Substring(0, 5)}...";

    [ObservableProperty]
    private decimal price;



}

public class Product : Item
{
    public float Weight { get; set; }
    public string Color { get; set; }
    public bool IsRemoved { get; set; }


}

public class Service : Item
{
    public TimeSpan Duration { get; set; }
}

