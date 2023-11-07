using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public abstract class Item : BaseEntity, INotifyPropertyChanged
{
    public string Name { get; set; }
    public string ShortName => $"{Name.Substring(0, 5)}...";

    private decimal price;
    public decimal Price
    {
        get => price;
        set  
        {
            price = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
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

